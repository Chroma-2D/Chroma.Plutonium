using System.Runtime.InteropServices;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_set_min_row_height(nk_context* ctx, float height);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_reset_min_row_height(nk_context* ctx);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern nk_rect nk_layout_widget_bounds(nk_context* ctx);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern float nk_layout_ratio_from_pixel(nk_context* ctx, float pixel_width);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_dynamic(nk_context* ctx, float height, int cols);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_static(nk_context* ctx, float height, int item_width, int cols);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_begin(nk_context* ctx, nk_layout_format fmt, float row_height, int cols);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_push(nk_context* ctx, float val);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_end(nk_context* ctx);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row(nk_context* ctx, nk_layout_format fmt, float height, int cols, float* ratio);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_template_begin(nk_context* ctx, float row_height);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_template_push_dynamic(nk_context* ctx);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_template_push_variable(nk_context* ctx, float min_width);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_template_push_static(nk_context* ctx, float width);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_row_template_end(nk_context* ctx);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_space_begin(nk_context* ctx, nk_layout_format fmt, float height, int widget_count);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_space_push(nk_context* ctx, nk_rect rect);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void nk_layout_space_end(nk_context* ctx);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern nk_rect nk_layout_space_bounds(nk_context* ctx);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern nk_vec2 nk_layout_space_to_screen(nk_context* ctx, nk_vec2 v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern nk_vec2 nk_layout_space_to_local(nk_context* ctx, nk_vec2 v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern nk_rect nk_layout_space_rect_to_screen(nk_context* ctx, nk_rect r);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public static extern nk_rect nk_layout_space_rect_to_local(nk_context* ctx, nk_rect r);
    }
}