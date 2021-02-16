using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void FontStashAction(IntPtr Atlas);

    internal static unsafe class NuklearAPI
    {
        private static nk_context* Ctx;
        

        static nk_allocator* Allocator;
        static nk_font_atlas* FontAtlas;
        static nk_draw_null_texture* NullTexture;
        static nk_convert_config* ConvertCfg;

        static nk_buffer* Commands, Vertices, Indices;
        static byte[] LastMemory;

        static nk_draw_vertex_layout_element* VertexLayout;
        static nk_plugin_alloc_t Alloc;
        static nk_plugin_free_t Free;

        static IFrameBuffered FrameBuffered;

        internal static bool ForceUpdateQueued;
        internal static IntPtr Context;
        internal static NuklearDevice Dev;
        internal static bool Initialized;

        static IntPtr ManagedAlloc(IntPtr Size, bool ClearMem = true)
        {
            IntPtr Mem = CoreNative.Malloc(Size);

            if (ClearMem)
                CoreNative.MemSet(Mem, 0, Size);

            if (Mem == IntPtr.Zero)
                throw new Exception("Cannot allocate memory?");

            return Mem;
        }

        static IntPtr ManagedAlloc(int Size)
        {
            return ManagedAlloc(new IntPtr(Size));
        }

        static void ManagedFree(IntPtr Mem)
        {
            CoreNative.Free(Mem);
        }

        static void FontStash(FontStashAction A = null)
        {
            LibNuklear.nk_font_atlas_init(FontAtlas, Allocator);
            LibNuklear.nk_font_atlas_begin(FontAtlas);

            A?.Invoke(new IntPtr(FontAtlas));

            int W, H;
            IntPtr Image = LibNuklear.nk_font_atlas_bake(FontAtlas, &W, &H, nk_font_atlas_format.NK_FONT_ATLAS_RGBA32);
            int TexHandle = Dev.CreateTextureHandle(W, H, Image);

            LibNuklear.nk_font_atlas_end(FontAtlas, LibNuklear.nk_handle_id(TexHandle), NullTexture);

            if (FontAtlas->default_font != null)
                LibNuklear.nk_style_set_font(Ctx, &FontAtlas->default_font->handle);
        }


        static bool HandleInput()
        {
            bool HasInput = FrameBuffered == null || Dev.Events.Count > 0;

            if (HasInput)
            {
                LibNuklear.nk_input_begin(Ctx);

                while (Dev.Events.Count > 0)
                {
                    NuklearEvent E = Dev.Events.Dequeue();

                    switch (E.EvtType)
                    {
                        case NuklearEvent.EventType.MouseButton:
                            LibNuklear.nk_input_button(Ctx, (nk_buttons)E.MButton, E.X, E.Y, E.Down ? 1 : 0);
                            break;

                        case NuklearEvent.EventType.MouseMove:
                            LibNuklear.nk_input_motion(Ctx, E.X, E.Y);
                            break;

                        case NuklearEvent.EventType.Scroll:
                            LibNuklear.nk_input_scroll(Ctx, new nk_vec2() {x = E.ScrollX, y = E.ScrollY});
                            break;

                        case NuklearEvent.EventType.Text:
                            for (int i = 0; i < E.Text.Length; i++)
                            {
                                if (!char.IsControl(E.Text[i]))
                                    LibNuklear.nk_input_unicode(Ctx, E.Text[i]);
                            }

                            break;

                        case NuklearEvent.EventType.KeyboardKey:
                            LibNuklear.nk_input_key(Ctx, E.Key, E.Down ? 1 : 0);
                            break;

                        case NuklearEvent.EventType.ForceUpdate:
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }

                LibNuklear.nk_input_end(Ctx);
            }

            return HasInput;
        }

        static void Render(bool HadInput)
        {
            if (HadInput)
            {
                bool Dirty = true;

                if (FrameBuffered != null)
                {
                    Dirty = false;

                    IntPtr MemoryBuffer = LibNuklear.nk_buffer_memory(&Ctx->memory);
                    if ((int)Ctx->memory.allocated == 0)
                        Dirty = true;

                    if (!Dirty)
                    {
                        if (LastMemory == null || LastMemory.Length < (int)Ctx->memory.allocated)
                        {
                            LastMemory = new byte[(int)Ctx->memory.allocated];
                            Dirty = true;
                        }
                    }

                    if (!Dirty)
                    {
                        fixed (byte* LastMemoryPtr = LastMemory)
                            if (CoreNative.MemCmp(new IntPtr(LastMemoryPtr), MemoryBuffer, Ctx->memory.allocated) != 0)
                            {
                                Dirty = true;
                                Marshal.Copy(MemoryBuffer, LastMemory, 0, (int)Ctx->memory.allocated);
                            }
                    }
                }

                if (Dirty)
                {
                    NkConvertResult R =
                        (NkConvertResult)LibNuklear.nk_convert(Ctx, Commands, Vertices, Indices, ConvertCfg);
                    if (R != NkConvertResult.Success)
                        throw new Exception(R.ToString());

                    NkVertex[] NkVerts = new NkVertex[(int)Vertices->needed / sizeof(NkVertex)];
                    NkVertex* VertsPtr = (NkVertex*)Vertices->memory.ptr;

                    for (int i = 0; i < NkVerts.Length; i++)
                    {
                        //NkVertex* V = &VertsPtr[i];
                        //NkVerts[i] = new NkVertex() { Position = new NkVector2f() { X = (int)V->Position.X, Y = (int)V->Position.Y }, Color = V->Color, UV = V->UV };

                        NkVerts[i] = VertsPtr[i];
                    }

                    ushort[] NkIndices = new ushort[(int)Indices->needed / sizeof(ushort)];
                    ushort* IndicesPtr = (ushort*)Indices->memory.ptr;
                    for (int i = 0; i < NkIndices.Length; i++)
                        NkIndices[i] = IndicesPtr[i];

                    Dev.SetBuffer(NkVerts, NkIndices);
                    FrameBuffered?.BeginBuffering();

                    uint Offset = 0;
                    Dev.BeginRender();

                    LibNuklear.nk_draw_foreach(Ctx, Commands, (Cmd) =>
                    {
                        if (Cmd->elem_count == 0)
                            return;

                        Dev.Render(Cmd->userdata, Cmd->texture.id, Cmd->clip_rect, Offset, Cmd->elem_count);
                        Offset += Cmd->elem_count;
                    });

                    Dev.EndRender();
                    FrameBuffered?.EndBuffering();
                }

                nk_draw_list* list = &Ctx->draw_list;
                if (list != null)
                {
                    if (list->buffer != null)
                        LibNuklear.nk_buffer_clear(list->buffer);

                    if (list->vertices != null)
                        LibNuklear.nk_buffer_clear(list->vertices);

                    if (list->elements != null)
                        LibNuklear.nk_buffer_clear(list->elements);
                }

                LibNuklear.nk_clear(Ctx);
            }

            FrameBuffered?.RenderFinal();
        }

        //internal  NuklearAPI(NuklearDevice Device) {
        internal static void Init(NuklearDevice Device)
        {
            if (Initialized)
                throw new InvalidOperationException("Re-initialization is not supported.");

            Initialized = true;

            Dev = Device;
            FrameBuffered = Device as IFrameBuffered;

            // TODO: Free these later
            Ctx = (nk_context*)ManagedAlloc(sizeof(nk_context));
            Context = new IntPtr(Ctx);
            
            Allocator = (nk_allocator*)ManagedAlloc(sizeof(nk_allocator));
            FontAtlas = (nk_font_atlas*)ManagedAlloc(sizeof(nk_font_atlas));
            NullTexture = (nk_draw_null_texture*)ManagedAlloc(sizeof(nk_draw_null_texture));
            ConvertCfg = (nk_convert_config*)ManagedAlloc(sizeof(nk_convert_config));
            Commands = (nk_buffer*)ManagedAlloc(sizeof(nk_buffer));
            Vertices = (nk_buffer*)ManagedAlloc(sizeof(nk_buffer));
            Indices = (nk_buffer*)ManagedAlloc(sizeof(nk_buffer));

            VertexLayout = (nk_draw_vertex_layout_element*)ManagedAlloc(sizeof(nk_draw_vertex_layout_element) * 4);
            VertexLayout[0] = new nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute.NK_VERTEX_POSITION,
                nk_draw_vertex_layout_format.NK_FORMAT_FLOAT,
                Marshal.OffsetOf(typeof(NkVertex), nameof(NkVertex.Position)));
            VertexLayout[1] = new nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute.NK_VERTEX_TEXCOORD,
                nk_draw_vertex_layout_format.NK_FORMAT_FLOAT,
                Marshal.OffsetOf(typeof(NkVertex), nameof(NkVertex.UV)));
            VertexLayout[2] = new nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute.NK_VERTEX_COLOR,
                nk_draw_vertex_layout_format.NK_FORMAT_R8G8B8A8,
                Marshal.OffsetOf(typeof(NkVertex), nameof(NkVertex.Color)));
            VertexLayout[3] = nk_draw_vertex_layout_element.NK_VERTEX_LAYOUT_END;

            Alloc = (Handle, Old, Size) => ManagedAlloc(Size);
            Free = (Handle, Old) => ManagedFree(Old);

            //GCHandle.Alloc(Alloc);
            //GCHandle.Alloc(Free);

            Allocator->alloc_nkpluginalloct = Marshal.GetFunctionPointerForDelegate(Alloc);
            Allocator->free_nkpluginfreet = Marshal.GetFunctionPointerForDelegate(Free);

            LibNuklear.nk_init(Ctx, Allocator, null);

            Dev.Init();
            FontStash(Dev.FontStash);

            ConvertCfg->shape_AA = nk_anti_aliasing.NK_ANTI_ALIASING_ON;
            ConvertCfg->line_AA = nk_anti_aliasing.NK_ANTI_ALIASING_ON;
            ConvertCfg->vertex_layout = VertexLayout;
            ConvertCfg->vertex_size = new IntPtr(sizeof(NkVertex));
            ConvertCfg->vertex_alignment = new IntPtr(1);
            ConvertCfg->circle_segment_count = 22;
            ConvertCfg->curve_segment_count = 22;
            ConvertCfg->arc_segment_count = 22;
            ConvertCfg->global_alpha = 1.0f;
            ConvertCfg->null_tex = *NullTexture;

            LibNuklear.nk_buffer_init(Commands, Allocator, new IntPtr(4 * 1024));
            LibNuklear.nk_buffer_init(Vertices, Allocator, new IntPtr(4 * 1024));
            LibNuklear.nk_buffer_init(Indices, Allocator, new IntPtr(4 * 1024));
        }

        internal static void Frame(Action A)
        {
            if (!Initialized)
                throw new InvalidOperationException("Tried to render a GUI frame before initialization.");

            if (ForceUpdateQueued)
            {
                ForceUpdateQueued = false;

                Dev?.ForceUpdate();
            }

            bool HasInput;
            if (HasInput = HandleInput())
                A();
            Render(HasInput);
        }

        internal static void SetDeltaTime(float Delta)
        {
            if (Ctx != null)
                Ctx->delta_time_Seconds = Delta;
        }

        internal static bool Window(string Name, string Title, float X, float Y, float W, float H, NkPanelFlags Flags,
            Action A)
        {
            bool Res = true;

            if (LibNuklear.nk_begin_titled(Ctx, Name, Title, new NkRect(X, Y, W, H), (uint)Flags) != 0)
                A?.Invoke();
            else
                Res = false;

            LibNuklear.nk_end(Ctx);
            return Res;
        }

        internal static bool Window(string Title, float X, float Y, float W, float H, NkPanelFlags Flags, Action A) =>
            Window(Title, Title, X, Y, W, H, Flags, A);

        internal static bool WindowIsClosed(string Name) => LibNuklear.nk_window_is_closed(Ctx, Name) != 0;

        internal static bool WindowIsHidden(string Name) => LibNuklear.nk_window_is_hidden(Ctx, Name) != 0;

        internal static bool WindowIsCollapsed(string Name) => LibNuklear.nk_window_is_collapsed(Ctx, Name) != 0;

        internal static bool Group(string Name, string Title, NkPanelFlags Flags, Action A)
        {
            bool Res = true;

            if (LibNuklear.nk_group_begin_titled(Ctx, Name, Title, (uint)Flags) != 0)
                A?.Invoke();
            else
                Res = false;

            LibNuklear.nk_group_end(Ctx);
            return Res;
        }

        internal static bool Group(string Name, NkPanelFlags Flags, Action A) => Group(Name, Name, Flags, A);

        internal static bool ButtonLabel(string Label)
        {
            return LibNuklear.nk_button_label(Ctx, Label) != 0;
        }

        internal static bool ButtonText(string Text)
        {
            return LibNuklear.nk_button_text(Ctx, Text);
        }

        internal static bool ButtonText(char Char) => ButtonText(Char.ToString());

        internal static void LayoutRowStatic(float Height, int ItemWidth, int Cols)
        {
            LibNuklear.nk_layout_row_static(Ctx, Height, ItemWidth, Cols);
        }

        internal static void LayoutRowDynamic(float Height = 0, int Cols = 1)
        {
            LibNuklear.nk_layout_row_dynamic(Ctx, Height, Cols);
        }

        internal static void Label(string Txt, NkTextAlign TextAlign = (NkTextAlign)NkTextAlignment.NK_TEXT_LEFT)
        {
            LibNuklear.nk_label(Ctx, Txt, (uint)TextAlign);
        }

        internal static void LabelWrap(string Txt)
        {
            //Nuklear.nk_label(Ctx, Txt, (uint)TextAlign);
            LibNuklear.nk_label_wrap(Ctx, Txt);
        }

        internal static void LabelColored(string Txt, NkColor Clr,
            NkTextAlign TextAlign = (NkTextAlign)NkTextAlignment.NK_TEXT_LEFT)
        {
            LibNuklear.nk_label_colored(Ctx, Txt, (uint)TextAlign, Clr);
        }

        internal static void LabelColored(string Txt, byte R, byte G, byte B, byte A,
            NkTextAlign TextAlign = (NkTextAlign)NkTextAlignment.NK_TEXT_LEFT)
        {
            //Nuklear.nk_label_colored(Ctx, Txt, (uint)TextAlign, new NkColor() { r = R, g = G, b = B, a = A });
            LabelColored(Txt, new NkColor() {R = R, G = G, B = B, A = A}, TextAlign);
        }

        internal static void LabelColoredWrap(string Txt, NkColor Clr)
        {
            LibNuklear.nk_label_colored_wrap(Ctx, Txt, Clr);
        }

        internal static void LabelColoredWrap(string Txt, byte R, byte G, byte B, byte A)
        {
            LabelColoredWrap(Txt, new NkColor() {R = R, G = G, B = B, A = A});
        }

        internal static NkRect WindowGetBounds()
        {
            return LibNuklear.nk_window_get_bounds(Ctx);
        }

        internal static NkEditEvents EditString(NkEditTypes EditType, StringBuilder Buffer, nk_plugin_filter_t Filter)
        {
            return (NkEditEvents)LibNuklear.nk_edit_string_zero_terminated(Ctx, (uint)EditType, Buffer, Buffer.MaxCapacity,
                Filter);
        }

        internal static NkEditEvents EditString(NkEditTypes EditType, StringBuilder Buffer)
        {
            return EditString(EditType, Buffer, (ref nk_text_edit TextBox, uint Rune) => 1);
        }

        internal static bool IsKeyPressed(NkKeys Key)
        {
            //Nuklear.nk_input_is_key_pressed()
            return LibNuklear.nk_input_is_key_pressed(&Ctx->input, Key) != 0;
        }

        internal static void QueueForceUpdate()
        {
            ForceUpdateQueued = true;
        }

        internal static void WindowClose(string Name)
        {
            LibNuklear.nk_window_close(Ctx, Name);
        }

        internal static void SetClipboardCallback(Action<string> CopyFunc, Func<string> PasteFunc)
        {
            // TODO: Contains alloc and forget, don't call SetClipboardCallback too many times


            nk_plugin_copy_t NkCopyFunc = (Handle, Str, Len) =>
            {
                byte[] Bytes = new byte[Len];

                for (int i = 0; i < Bytes.Length; i++)
                    Bytes[i] = Str[i];

                CopyFunc(Encoding.UTF8.GetString(Bytes));
            };

            nk_plugin_paste_t NkPasteFunc = (NkHandle Handle, ref nk_text_edit TextEdit) =>
            {
                byte[] Bytes = Encoding.UTF8.GetBytes(PasteFunc());

                fixed (byte* BytesPtr = Bytes)
                fixed (nk_text_edit* TextEditPtr = &TextEdit)
                    LibNuklear.nk_textedit_paste(TextEditPtr, BytesPtr, Bytes.Length);
            };

            GCHandle.Alloc(CopyFunc);
            GCHandle.Alloc(PasteFunc);
            GCHandle.Alloc(NkCopyFunc);
            GCHandle.Alloc(NkPasteFunc);

            Ctx->clip.copyfun_nkPluginCopyT = Marshal.GetFunctionPointerForDelegate(NkCopyFunc);
            Ctx->clip.pastefun_nkPluginPasteT = Marshal.GetFunctionPointerForDelegate(NkPasteFunc);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NkVector2f
    {
        internal float X, Y;

        internal NkVector2f(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        public static implicit operator Vector2(NkVector2f V)
        {
            return new(V.X, V.Y);
        }

        public static implicit operator NkVector2f(Vector2 V)
        {
            return new(V.X, V.Y);
        }
    }

    /*[StructLayout(LayoutKind.Sequential)]
	internal struct NkColor {
		internal byte R, G, B, A;

		internal override string ToString() {
			return string.Format("({0}, {1}, {2}, {3})", R, G, B, A);
		}
	}*/

    [StructLayout(LayoutKind.Sequential)]
    internal struct NkVertex
    {
        internal NkVector2f Position;
        internal NkVector2f UV;
        internal NkColor Color;

        public override string ToString()
        {
            return string.Format("Position: {0}; UV: {1}; Color: {2}", Position, UV, Color);
        }
    }

    internal struct NuklearEvent
    {
        internal enum EventType
        {
            MouseButton,
            MouseMove,
            Scroll,
            Text,
            KeyboardKey,
            ForceUpdate
        }

        internal enum MouseButton
        {
            Left,
            Middle,
            Right
        }

        internal EventType EvtType;
        internal MouseButton MButton;
        internal NkKeys Key;
        internal int X, Y;
        internal bool Down;
        internal float ScrollX, ScrollY;
        internal string Text;
    }

    internal interface IFrameBuffered
    {
        void BeginBuffering();
        void EndBuffering();
        void RenderFinal();
    }

    internal unsafe abstract class NuklearDevice
    {
        internal Queue<NuklearEvent> Events;

        internal abstract void SetBuffer(NkVertex[] VertexBuffer, ushort[] IndexBuffer);
        internal abstract void Render(NkHandle Userdata, int Texture, NkRect ClipRect, uint Offset, uint Count);
        internal abstract int CreateTextureHandle(int W, int H, IntPtr Data);

        internal NuklearDevice()
        {
            Events = new Queue<NuklearEvent>();
            ForceUpdate();
        }

        internal virtual void Init()
        {
        }

        internal virtual void FontStash(IntPtr Atlas)
        {
        }

        internal virtual void BeginRender()
        {
        }

        internal virtual void EndRender()
        {
        }

        internal void OnMouseButton(NuklearEvent.MouseButton MouseButton, int X, int Y, bool Down)
        {
            Events.Enqueue(new NuklearEvent()
                {EvtType = NuklearEvent.EventType.MouseButton, MButton = MouseButton, X = X, Y = Y, Down = Down});
        }

        internal void OnMouseMove(int X, int Y)
        {
            Events.Enqueue(new NuklearEvent() {EvtType = NuklearEvent.EventType.MouseMove, X = X, Y = Y});
        }

        internal void OnScroll(float ScrollX, float ScrollY)
        {
            Events.Enqueue(new NuklearEvent()
                {EvtType = NuklearEvent.EventType.Scroll, ScrollX = ScrollX, ScrollY = ScrollY});
        }

        internal void OnText(string Txt)
        {
            Events.Enqueue(new NuklearEvent() {EvtType = NuklearEvent.EventType.Text, Text = Txt});
        }

        internal void OnKey(NkKeys Key, bool Down)
        {
            Events.Enqueue(new NuklearEvent() {EvtType = NuklearEvent.EventType.KeyboardKey, Key = Key, Down = Down});
        }

        internal void ForceUpdate()
        {
            Events.Enqueue(new NuklearEvent() {EvtType = NuklearEvent.EventType.ForceUpdate});
        }
    }

    internal unsafe abstract class NuklearDeviceTex<T> : NuklearDevice
    {
        List<T> Textures;

        internal NuklearDeviceTex()
        {
            Textures = new List<T>();
            Textures.Add(default(T)); // Start indices at 1
        }

        internal int CreateTextureHandle(T Tex)
        {
            Textures.Add(Tex);
            return Textures.Count - 1;
        }

        internal T GetTexture(int Handle)
        {
            return Textures[Handle];
        }

        internal sealed override int CreateTextureHandle(int W, int H, IntPtr Data)
        {
            T Tex = CreateTexture(W, H, Data);
            return CreateTextureHandle(Tex);
        }

        internal sealed override void Render(NkHandle Userdata, int Texture, NkRect ClipRect, uint Offset,
            uint Count) =>
            Render(Userdata, GetTexture(Texture), ClipRect, Offset, Count);

        internal abstract T CreateTexture(int W, int H, IntPtr Data);
        internal abstract void Render(NkHandle Userdata, T Texture, NkRect ClipRect, uint Offset, uint Count);
    }
}