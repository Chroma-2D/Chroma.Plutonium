using System.Runtime.InteropServices;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_begin(nk_context* context);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_motion(nk_context* context, int x, int y);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_key(nk_context* context, nk_keys keys, int down);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_button(nk_context* context, nk_buttons buttons, int x, int y, int down);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_scroll(nk_context* context, nk_vec2 val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_char(nk_context* context, byte c);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_glyph(nk_context* context, nk_glyph glyph);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_unicode(nk_context* context, uint rune);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_input_end(nk_context* context);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_has_mouse_click(nk_input* inp, nk_buttons buttons);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_has_mouse_click_in_rect(nk_input* inp, nk_buttons buttons, nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_has_mouse_click_down_in_rect(nk_input* inp, nk_buttons buttons, nk_rect r,
            int down);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_mouse_click_in_rect(nk_input* inp, nk_buttons buttons, nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_mouse_click_down_in_rect(nk_input* inp, nk_buttons id, nk_rect b,
            int down);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_any_mouse_click_in_rect(nk_input* inp, nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_mouse_prev_hovering_rect(nk_input* inp, nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_mouse_hovering_rect(nk_input* inp, nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_mouse_clicked(nk_input* inp, nk_buttons buttons, nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_mouse_down(nk_input* inp, nk_buttons buttons);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_mouse_pressed(nk_input* inp, nk_buttons buttons);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_mouse_released(nk_input* inp, nk_buttons buttons);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_key_pressed(nk_input* inp, nk_keys keys);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_key_released(nk_input* inp, nk_keys keys);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_input_is_key_down(nk_input* inp, nk_keys keys);
    }
}