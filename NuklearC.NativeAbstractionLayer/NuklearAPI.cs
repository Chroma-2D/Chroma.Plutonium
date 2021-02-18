using System;
using System.Runtime.InteropServices;
using System.Text;
using NuklearC.Native;
using NuklearC.Native.Types;

namespace NuklearC.NativeAbstractionLayer
{
    public static unsafe class NuklearAPI
    {
        private static nk_context* _nuklearContext;
        private static nk_allocator* _allocator;
        private static nk_font_atlas* _fontAtlas;
        private static nk_draw_null_texture* _nullTexture;
        private static nk_convert_config* _convertConfig;

        private static nk_buffer* _commands;
        private static nk_buffer* _vertices;
        private static nk_buffer* _indices;
        private static byte[] _lastMemory;

        private static nk_draw_vertex_layout_element* _vertexLayout;
        private static nk_plugin_alloc_t _alloc;
        private static nk_plugin_free_t _free;

        private static IFrameBuffered _frameBuffered;

        private static Action<string> _onClipboardCopy;
        private static nk_plugin_copy_t _nkOnClipboardCopy;

        private static Func<string> _onClipboardPaste;
        private static nk_plugin_paste_t _nkOnClipboardPaste;


        public static bool ForceUpdateQueued { get; private set; }
        public static IntPtr Context { get; private set; }
        public static NuklearDevice Device { get; private set; }
        public static bool Initialized { get; private set; }

        private static IntPtr ManagedAlloc(IntPtr Size, bool ClearMem = true)
        {
            var memory = MemoryManagement.Malloc(Size);

            if (ClearMem)
                MemoryManagement.MemSet(memory, 0, Size);

            if (memory == IntPtr.Zero)
                throw new Exception("Out of memory.");

            return memory;
        }

        private static IntPtr ManagedAlloc(int size)
        {
            return ManagedAlloc(new IntPtr(size));
        }

        private static void ManagedFree(IntPtr memory)
        {
            MemoryManagement.Free(memory);
        }

        private static void FontStash(FontStashAction A = null)
        {
            Nuklear.nk_font_atlas_init(_fontAtlas, _allocator);
            Nuklear.nk_font_atlas_begin(_fontAtlas);

            A?.Invoke(new IntPtr(_fontAtlas));

            int W, H;
            var Image = Nuklear.nk_font_atlas_bake(_fontAtlas, &W, &H, nk_font_atlas_format.NK_FONT_ATLAS_RGBA32);
            var TexHandle = Device.CreateTextureHandle(W, H, Image);

            Nuklear.nk_font_atlas_end(_fontAtlas, Nuklear.nk_handle_id(TexHandle), _nullTexture);

            if (_fontAtlas->default_font != null)
                Nuklear.nk_style_set_font(_nuklearContext, &_fontAtlas->default_font->handle);
        }


        private static bool HandleInput()
        {
            var HasInput = _frameBuffered == null || Device.Events.Count > 0;

            if (HasInput)
            {
                Nuklear.nk_input_begin(_nuklearContext);

                while (Device.Events.Count > 0)
                {
                    var deviceEvent = Device.Events.Dequeue();

                    switch (deviceEvent.Type)
                    {
                        case NuklearEvent.EventType.MouseButton:
                            Nuklear.nk_input_button(_nuklearContext, (nk_buttons)deviceEvent.Button, deviceEvent.X, deviceEvent.Y,
                                deviceEvent.Down ? 1 : 0);
                            break;

                        case NuklearEvent.EventType.MouseMove:
                            Nuklear.nk_input_motion(_nuklearContext, deviceEvent.X, deviceEvent.Y);
                            break;

                        case NuklearEvent.EventType.Scroll:
                            Nuklear.nk_input_scroll(_nuklearContext, new nk_vec2() {x = deviceEvent.ScrollX, y = deviceEvent.ScrollY});
                            break;

                        case NuklearEvent.EventType.Text:
                            for (var i = 0; i < deviceEvent.Text.Length; i++)
                            {
                                if (!char.IsControl(deviceEvent.Text[i]))
                                    Nuklear.nk_input_unicode(_nuklearContext, deviceEvent.Text[i]);
                            }

                            break;

                        case NuklearEvent.EventType.KeyboardKey:
                            Nuklear.nk_input_key(_nuklearContext, deviceEvent.Key, deviceEvent.Down ? 1 : 0);
                            break;

                        case NuklearEvent.EventType.ForceUpdate:
                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }

                Nuklear.nk_input_end(_nuklearContext);
            }

            return HasInput;
        }

        private static void Render(bool HadInput)
        {
            if (HadInput)
            {
                var Dirty = true;

                if (_frameBuffered != null)
                {
                    Dirty = false;

                    var MemoryBuffer = Nuklear.nk_buffer_memory(&_nuklearContext->memory);
                    if ((int)_nuklearContext->memory.allocated == 0)
                        Dirty = true;

                    if (!Dirty)
                    {
                        if (_lastMemory == null || _lastMemory.Length < (int)_nuklearContext->memory.allocated)
                        {
                            _lastMemory = new byte[(int)_nuklearContext->memory.allocated];
                            Dirty = true;
                        }
                    }

                    if (!Dirty)
                    {
                        fixed (byte* LastMemoryPtr = _lastMemory)
                            if (MemoryManagement.MemCmp(new IntPtr(LastMemoryPtr), MemoryBuffer,
                                _nuklearContext->memory.allocated) != 0)
                            {
                                Dirty = true;
                                Marshal.Copy(MemoryBuffer, _lastMemory, 0, (int)_nuklearContext->memory.allocated);
                            }
                    }
                }

                if (Dirty)
                {
                    var convertResult = (nk_convert_result)Nuklear.nk_convert(
                        _nuklearContext,
                        _commands,
                        _vertices,
                        _indices,
                        _convertConfig
                    );

                    if (convertResult != nk_convert_result.Success)
                        throw new Exception(convertResult.ToString());

                    var nkVertices = new nk_vertex[(int)_vertices->needed / sizeof(nk_vertex)];
                    var verticesPtr = (nk_vertex*)_vertices->memory.ptr;

                    if (verticesPtr == null)
                        throw new Exception("Vertex buffer pointer invalid.");

                    for (var i = 0; i < nkVertices.Length; i++)
                        nkVertices[i] = verticesPtr[i];

                    var nkIndices = new ushort[(int)_indices->needed / sizeof(ushort)];
                    var indicesPtr = (ushort*)_indices->memory.ptr;

                    if (indicesPtr == null)
                        throw new Exception("Index buffer pointer invalid.");

                    for (var i = 0; i < nkIndices.Length; i++)
                        nkIndices[i] = indicesPtr[i];

                    Device.SetBuffer(nkVertices, nkIndices);
                    _frameBuffered?.BeginBuffering();

                    uint Offset = 0;
                    Device.BeginRender();

                    Nuklear.nk_draw_foreach(_nuklearContext, _commands, (command) =>
                    {
                        if (command->elem_count == 0)
                            return;

                        Device.Render(
                            command->userdata,
                            command->texture.id,
                            command->clip_rect,
                            Offset,
                            command->elem_count
                        );

                        Offset += command->elem_count;
                    });

                    Device.EndRender();
                    _frameBuffered?.EndBuffering();
                }

                var list = &_nuklearContext->draw_list;

                if (list->buffer != null)
                    Nuklear.nk_buffer_clear(list->buffer);

                if (list->vertices != null)
                    Nuklear.nk_buffer_clear(list->vertices);

                if (list->elements != null)
                    Nuklear.nk_buffer_clear(list->elements);

                Nuklear.nk_clear(_nuklearContext);
            }

            _frameBuffered?.RenderFinal();
        }

        public static void Init(NuklearDevice device)
        {
            if (Initialized)
                throw new InvalidOperationException("Re-initialization is not supported.");

            Initialized = true;

            Device = device;
            _frameBuffered = Device as IFrameBuffered;

            // TODO: Free these later
            _nuklearContext = (nk_context*)ManagedAlloc(sizeof(nk_context));
            Context = new IntPtr(_nuklearContext);

            _allocator = (nk_allocator*)ManagedAlloc(sizeof(nk_allocator));
            _fontAtlas = (nk_font_atlas*)ManagedAlloc(sizeof(nk_font_atlas));
            _nullTexture = (nk_draw_null_texture*)ManagedAlloc(sizeof(nk_draw_null_texture));
            _convertConfig = (nk_convert_config*)ManagedAlloc(sizeof(nk_convert_config));
            _commands = (nk_buffer*)ManagedAlloc(sizeof(nk_buffer));
            _vertices = (nk_buffer*)ManagedAlloc(sizeof(nk_buffer));
            _indices = (nk_buffer*)ManagedAlloc(sizeof(nk_buffer));

            _vertexLayout = (nk_draw_vertex_layout_element*)ManagedAlloc(sizeof(nk_draw_vertex_layout_element) * 4);
            _vertexLayout[0] = new nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute.NK_VERTEX_POSITION,
                nk_draw_vertex_layout_format.NK_FORMAT_FLOAT,
                Marshal.OffsetOf(typeof(nk_vertex), nameof(nk_vertex.position)));
            _vertexLayout[1] = new nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute.NK_VERTEX_TEXCOORD,
                nk_draw_vertex_layout_format.NK_FORMAT_FLOAT,
                Marshal.OffsetOf(typeof(nk_vertex), nameof(nk_vertex.uv)));
            _vertexLayout[2] = new nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute.NK_VERTEX_COLOR,
                nk_draw_vertex_layout_format.NK_FORMAT_R8G8B8A8,
                Marshal.OffsetOf(typeof(nk_vertex), nameof(nk_vertex.color)));
            _vertexLayout[3] = nk_draw_vertex_layout_element.NK_VERTEX_LAYOUT_END;

            _alloc = (_, _, size) => ManagedAlloc(size);
            _free = (_, old) => ManagedFree(old);

            _allocator->alloc_nkpluginalloct = Marshal.GetFunctionPointerForDelegate(_alloc);
            _allocator->free_nkpluginfreet = Marshal.GetFunctionPointerForDelegate(_free);

            Nuklear.nk_init(_nuklearContext, _allocator, null);

            Device.Init();
            FontStash(Device.FontStash);

            _convertConfig->shape_AA = nk_anti_aliasing.NK_ANTI_ALIASING_ON;
            _convertConfig->line_AA = nk_anti_aliasing.NK_ANTI_ALIASING_ON;
            _convertConfig->vertex_layout = _vertexLayout;
            _convertConfig->vertex_size = new IntPtr(sizeof(nk_vertex));
            _convertConfig->vertex_alignment = new IntPtr(1);
            _convertConfig->circle_segment_count = 22;
            _convertConfig->curve_segment_count = 22;
            _convertConfig->arc_segment_count = 22;
            _convertConfig->global_alpha = 1.0f;
            _convertConfig->null_tex = *_nullTexture;

            Nuklear.nk_buffer_init(_commands, _allocator, new IntPtr(4 * 1024));
            Nuklear.nk_buffer_init(_vertices, _allocator, new IntPtr(4 * 1024));
            Nuklear.nk_buffer_init(_indices, _allocator, new IntPtr(4 * 1024));
        }

        public static void Frame(Action action)
        {
            if (!Initialized)
                throw new InvalidOperationException("Tried to render a GUI frame before initialization.");

            if (ForceUpdateQueued)
            {
                ForceUpdateQueued = false;
                Device?.ForceUpdate();
            }

            var hasInput = HandleInput();

            if (hasInput)
                action();

            Render(hasInput);
        }

        public static void SetDeltaTime(float Delta)
        {
            if (_nuklearContext != null)
                _nuklearContext->delta_time_Seconds = Delta;
        }

        public static bool Window(string Name, string Title, float X, float Y, float W, float H, nk_panel_flags Flags,
            Action A)
        {
            var Res = true;

            if (Nuklear.nk_begin_titled(_nuklearContext, Name, Title, new nk_rect(X, Y, W, H), (uint)Flags) != 0)
                A?.Invoke();
            else
                Res = false;

            Nuklear.nk_end(_nuklearContext);
            return Res;
        }

        public static bool Window(string Title, float X, float Y, float W, float H, nk_panel_flags Flags, Action A) =>
            Window(Title, Title, X, Y, W, H, Flags, A);

        public static bool WindowIsClosed(string Name) => Nuklear.nk_window_is_closed(_nuklearContext, Name) != 0;

        public static bool WindowIsHidden(string Name) => Nuklear.nk_window_is_hidden(_nuklearContext, Name) != 0;

        public static bool WindowIsCollapsed(string Name) =>
            Nuklear.nk_window_is_collapsed(_nuklearContext, Name) != 0;

        public static bool Group(string Name, string Title, nk_panel_flags Flags, Action A)
        {
            var Res = true;

            if (Nuklear.nk_group_begin_titled(_nuklearContext, Name, Title, (uint)Flags) != 0)
                A?.Invoke();
            else
                Res = false;

            Nuklear.nk_group_end(_nuklearContext);
            return Res;
        }

        public static bool Group(string Name, nk_panel_flags Flags, Action A) => Group(Name, Name, Flags, A);

        public static bool ButtonLabel(string Label)
        {
            return Nuklear.nk_button_label(_nuklearContext, Label) != 0;
        }

        public static bool ButtonText(string Text)
        {
            return Nuklear.nk_button_text(_nuklearContext, Text);
        }

        public static bool ButtonText(char Char) => ButtonText(Char.ToString());

        public static void LayoutRowStatic(float Height, int ItemWidth, int Cols)
        {
            Nuklear.nk_layout_row_static(_nuklearContext, Height, ItemWidth, Cols);
        }

        public static void LayoutRowDynamic(float Height = 0, int Cols = 1)
        {
            Nuklear.nk_layout_row_dynamic(_nuklearContext, Height, Cols);
        }

        public static void Label(string Txt, nk_text_align TextAlign = (nk_text_align)nk_text_alignment.NK_TEXT_LEFT)
        {
            Nuklear.nk_label(_nuklearContext, Txt, (uint)TextAlign);
        }

        public static void LabelWrap(string Txt)
        {
            //Nuklear.nk_label(Ctx, Txt, (uint)TextAlign);
            Nuklear.nk_label_wrap(_nuklearContext, Txt);
        }

        public static void LabelColored(string Txt, nk_color Clr,
            nk_text_align TextAlign = (nk_text_align)nk_text_alignment.NK_TEXT_LEFT)
        {
            Nuklear.nk_label_colored(_nuklearContext, Txt, (uint)TextAlign, Clr);
        }

        public static void LabelColored(string Txt, byte R, byte G, byte B, byte A,
            nk_text_align TextAlign = (nk_text_align)nk_text_alignment.NK_TEXT_LEFT)
        {
            //Nuklear.nk_label_colored(Ctx, Txt, (uint)TextAlign, new nk_color() { r = R, g = G, b = B, a = A });
            LabelColored(Txt, new nk_color() {R = R, G = G, B = B, A = A}, TextAlign);
        }

        public static void LabelColoredWrap(string Txt, nk_color Clr)
        {
            Nuklear.nk_label_colored_wrap(_nuklearContext, Txt, Clr);
        }

        public static void LabelColoredWrap(string Txt, byte R, byte G, byte B, byte A)
        {
            LabelColoredWrap(Txt, new nk_color() {R = R, G = G, B = B, A = A});
        }

        public static nk_rect WindowGetBounds()
        {
            return Nuklear.nk_window_get_bounds(_nuklearContext);
        }

        public static nk_edit_events EditString(nk_edit_types EditType, StringBuilder Buffer, nk_plugin_filter_t Filter)
        {
            return (nk_edit_events)Nuklear.nk_edit_string_zero_terminated(_nuklearContext, (uint)EditType, Buffer,
                Buffer.MaxCapacity,
                Filter);
        }

        public static nk_edit_events EditString(nk_edit_types EditType, StringBuilder Buffer)
        {
            return EditString(EditType, Buffer, (ref nk_text_edit _, uint _) => 1);
        }

        public static void QueueForceUpdate()
        {
            ForceUpdateQueued = true;
        }

        public static void WindowClose(string Name)
        {
            Nuklear.nk_window_close(_nuklearContext, Name);
        }

        public static void SetClipboardCallback(Action<string> onCopy, Func<string> onPaste)
        {
            _onClipboardCopy = onCopy;
            _onClipboardPaste = onPaste;

            _nkOnClipboardCopy = (_, str, len) =>
            {
                var bytes = new byte[len];

                for (var i = 0; i < bytes.Length; i++)
                    bytes[i] = str[i];

                onCopy(Encoding.UTF8.GetString(bytes));
            };

            _nkOnClipboardPaste = (nk_handle _, ref nk_text_edit textEdit) =>
            {
                var bytes = Encoding.UTF8.GetBytes(onPaste());

                fixed (byte* BytesPtr = bytes)
                fixed (nk_text_edit* TextEditPtr = &textEdit)
                    Nuklear.nk_textedit_paste(TextEditPtr, BytesPtr, bytes.Length);
            };

            _nuklearContext->clip.copyfun_nkPluginCopyT = Marshal.GetFunctionPointerForDelegate(_nkOnClipboardCopy);
            _nuklearContext->clip.pastefun_nkPluginPasteT = Marshal.GetFunctionPointerForDelegate(_nkOnClipboardPaste);
        }
    }
}