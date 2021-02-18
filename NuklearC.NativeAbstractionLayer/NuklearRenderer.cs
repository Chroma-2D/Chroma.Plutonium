using System;
using System.Runtime.InteropServices;
using NuklearC.Native;
using NuklearC.Native.Types;

namespace NuklearC.NativeAbstractionLayer
{
    public unsafe class NuklearRenderer : IDisposable
    {
        private nk_context* _nuklearContext;
        private nk_allocator* _allocator;
        private nk_font_atlas* _fontAtlas;
        private nk_draw_null_texture* _nullTexture;
        private nk_convert_config* _convertConfig;

        private nk_buffer* _commands;
        private nk_buffer* _vertices;
        private nk_buffer* _indices;
        private byte[] _lastMemory;

        private nk_draw_vertex_layout_element* _vertexLayout;
        private nk_plugin_alloc_t _alloc;
        private nk_plugin_free_t _free;

        private IFrameBuffered _frameBuffered;

        public bool ForceUpdateQueued { get; private set; }
        public NuklearDevice Device { get; private set; }

        public NuklearRenderer(NuklearDevice device)
        {
            Device = device;
            _frameBuffered = Device as IFrameBuffered;

            _nuklearContext = (nk_context*)ManagedAlloc(sizeof(nk_context));
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

            NuklearUI.InitializeContext(_nuklearContext);
        }

        public void QueueForceUpdate()
        {
            ForceUpdateQueued = true;
        }

        public void SetDeltaTime(float Delta)
        {
            if (_nuklearContext != null)
                _nuklearContext->delta_time_Seconds = Delta;
        }

        public void Frame(Action action)
        {
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

        private IntPtr ManagedAlloc(int size, bool zeroMemory = true)
        {
            var memory = MemoryManagement.Malloc(new IntPtr(size));

            if (zeroMemory)
                MemoryManagement.MemSet(memory, 0, new IntPtr(size));

            if (memory == IntPtr.Zero)
                throw new Exception("Out of memory.");

            return memory;
        }

        private void ManagedFree(IntPtr memory)
            => MemoryManagement.Free(memory);

        private void ManagedFree(void* memory)
            => MemoryManagement.Free(new IntPtr(memory));

        private void FontStash(FontStashAction stashAction = null)
        {
            Nuklear.nk_font_atlas_init(_fontAtlas, _allocator);
            Nuklear.nk_font_atlas_begin(_fontAtlas);

            stashAction?.Invoke(new IntPtr(_fontAtlas));

            int W, H;
            var Image = Nuklear.nk_font_atlas_bake(_fontAtlas, &W, &H, nk_font_atlas_format.NK_FONT_ATLAS_RGBA32);
            var TexHandle = Device.CreateTextureHandle(W, H, Image);

            Nuklear.nk_font_atlas_end(_fontAtlas, Nuklear.nk_handle_id(TexHandle), _nullTexture);

            if (_fontAtlas->default_font != null)
                Nuklear.nk_style_set_font(_nuklearContext, &_fontAtlas->default_font->handle);
        }

        private bool HandleInput()
        {
            var hasInput = _frameBuffered == null || Device.Events.Count > 0;

            if (hasInput)
            {
                Nuklear.nk_input_begin(_nuklearContext);

                while (Device.Events.Count > 0)
                {
                    var deviceEvent = Device.Events.Dequeue();

                    switch (deviceEvent.Type)
                    {
                        case NuklearEvent.EventType.MouseButton:
                            Nuklear.nk_input_button(
                                _nuklearContext,
                                (nk_buttons)deviceEvent.Button,
                                deviceEvent.X,
                                deviceEvent.Y,
                                deviceEvent.IsDown ? 1 : 0
                            );
                            break;

                        case NuklearEvent.EventType.MouseMove:
                            Nuklear.nk_input_motion(_nuklearContext, deviceEvent.X, deviceEvent.Y);
                            break;

                        case NuklearEvent.EventType.Scroll:
                            Nuklear.nk_input_scroll(
                                _nuklearContext,
                                new nk_vec2
                                {
                                    x = deviceEvent.ScrollX,
                                    y = deviceEvent.ScrollY
                                }
                            );
                            break;

                        case NuklearEvent.EventType.Text:
                            for (var i = 0; i < deviceEvent.Text.Length; i++)
                            {
                                if (!char.IsControl(deviceEvent.Text[i]))
                                    Nuklear.nk_input_unicode(_nuklearContext, deviceEvent.Text[i]);
                            }

                            break;

                        case NuklearEvent.EventType.KeyboardKey:
                            Nuklear.nk_input_key(_nuklearContext, deviceEvent.Key, deviceEvent.IsDown ? 1 : 0);
                            break;

                        case NuklearEvent.EventType.ForceUpdate:
                            break;

                        default:
                            throw new NotSupportedException("This event type is not supported.");
                    }
                }

                Nuklear.nk_input_end(_nuklearContext);
            }

            return hasInput;
        }

        private void Render(bool HadInput)
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

        private void ReleaseUnmanagedResources()
        {
            ManagedFree(_convertConfig);
            ManagedFree(_nullTexture);
            ManagedFree(_fontAtlas);
            ManagedFree(_allocator);
            ManagedFree(_nuklearContext);
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~NuklearRenderer()
        {
            ReleaseUnmanagedResources();
        }
    }
}