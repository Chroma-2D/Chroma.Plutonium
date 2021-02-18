using System.Runtime.InteropServices;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_style_default(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_style_from_table(nk_context* ctx, nk_color* color);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_style_load_cursor(nk_context* ctx, nk_style_cursor scur, nk_cursor* cursor);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_style_load_all_cursors(nk_context* ctx, nk_cursor* cursor);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* nk_style_get_color_by_name(nk_style_colors scol);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_style_set_font(nk_context* ctx, nk_user_font* userfont);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_set_cursor(nk_context* ctx, nk_style_cursor scur);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_style_show_cursor(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_style_hide_cursor(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_push_font(nk_context* ctx, nk_user_font* userfont);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_push_float(nk_context* ctx, float* f, float g);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_push_vec2(nk_context* ctx, nk_vec2* a, nk_vec2 b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int
            nk_style_push_style_item(nk_context* ctx, nk_style_item* sitem, nk_style_item sitem2);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_push_flags(nk_context* ctx, uint* a_nkflags, uint b_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_push_color(nk_context* ctx, nk_color* a, nk_color b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_pop_font(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_pop_float(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_pop_vec2(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_pop_style_item(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_pop_flags(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_style_pop_color(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgb(int r, int g, int b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgb_iv(int* rgb);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgb_bv(byte* rgb);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgb_f(float r, float g, float b);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgb_fv(float* rgb);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgb_hex(byte* rgb);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgba(int r, int g, int b, int a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgba_u32(uint rgba);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgba_iv(int* rgba);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgba_bv(byte* rgba);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgba_f(float r, float g, float b, float a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgba_fv(float* rgba);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_rgba_hex(float* hsv);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_hsva(int h, int s, int v, int a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_hsva_iv(int* hsva);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_hsva_bv(byte* hsva);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_hsva_f(float h, float s, float v, float a);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_color nk_hsva_fv(float* hsva);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_f(out float r, out float g, out float b, out float a, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_fv(float* rgba_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_d(out double r, out double g, out double b, out double a, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_dv(double* rgba_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_color_u32(nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hex_rgba(byte* output, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hex_rgb(byte* output, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsv_i(out int h, out int s, out int v, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsv_b(out byte h, out byte s, out byte v, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsv_iv(int* hsv_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsv_bv(byte* hsv_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsv_f(out float h, out float s, out float v, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsv_fv(float* hsv_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsva_i(out int h, out int s, out int v, out int a, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsva_b(out byte h, out byte s, out byte v, out byte a, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsva_iv(int* hsva_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsva_bv(byte* hsva_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsva_f(out float h, out float s, out float v, out float a, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_color_hsva_fv(float* hsva_out, nk_color src);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_style_item nk_style_item_image(nk_image img);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_style_item nk_style_item_color(nk_color col);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_style_item nk_style_item_hide();
    }
}