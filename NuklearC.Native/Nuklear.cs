using System;
using System.Runtime.InteropServices;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        private const string LibraryName = "nuklear";
        public const int NK_INPUT_MAX = 512;

        public static void nk_foreach(nk_context* ctx, nk_foreach_action action)
        {
            nk_command* cmd;

            for (cmd = nk__begin(ctx); cmd != null; cmd = nk__next(ctx, cmd))
                action(cmd);
        }

        public static void nk_draw_foreach(nk_context* ctx, nk_buffer* b, nk_draw_foreach_action action)
        {
            nk_draw_command* cmd;

            for (cmd = nk__draw_begin(ctx, b); cmd != null; cmd = nk__draw_next(cmd, b, ctx))
                action(cmd);
        }

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_handle nk_handle_ptr(IntPtr ptr);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_handle nk_handle_id(int id);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_image nk_image_handle(nk_handle handle);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_image nk_image_ptr(IntPtr ptr);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_image nk_image_id(int id);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_image_is_subimage(nk_image* img);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_image nk_subimage_ptr(IntPtr ptr, ushort w, ushort h, nk_rect sub_region);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_image nk_subimage_id(int id, ushort w, ushort h, nk_rect sub_region);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_image nk_subimage_handle(nk_handle handle, ushort w, ushort h, nk_rect sub_region);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_murmur_hash(IntPtr key, int len, uint seed);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_triangle_from_direction(
            nk_vec2* result,
            nk_rect r,
            float pad_x,
            float pad_y,
            nk_heading heading
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_vec2i(int x, int y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_vec2v(float* xy);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_vec2iv(int* xy);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_get_null_rect();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_recti(int x, int y, int w, int h);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_recta(nk_vec2 pos, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_rectv(float* xywh);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_rectiv(int* xywh);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_rect_pos(nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_rect_size(nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_init_fixed(
            nk_context* context,
            IntPtr memory,
            IntPtr size,
            nk_user_font* userfont
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_init(nk_context* context, nk_allocator* allocator, nk_user_font* userfont);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_init_custom(
            nk_context* context,
            nk_buffer* cmds,
            nk_buffer* pool,
            nk_user_font* userfont
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_clear(nk_context* context);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_set_user_data(nk_context* context, nk_handle handle);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_init(nk_buffer* buffer, nk_allocator* allocator, IntPtr size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_init_fixed(nk_buffer* buffer, IntPtr memory, IntPtr size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_info(nk_memory_status* status, nk_buffer* buffer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_push(
            nk_buffer* buffer,
            nk_buffer_allocation_type atype,
            IntPtr memory,
            IntPtr size,
            IntPtr align
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_mark(nk_buffer* buffer, nk_buffer_allocation_type atype);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_reset(nk_buffer* buffer, nk_buffer_allocation_type atype);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_clear(nk_buffer* buffer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_buffer_free(nk_buffer* buffer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nk_buffer_memory(nk_buffer* buffer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nk_buffer_memory_const(nk_buffer* buffer);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nk_buffer_total(nk_buffer* buffer);
    }
}