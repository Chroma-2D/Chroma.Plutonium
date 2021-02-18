using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_slider {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;
        public nk_color border_color;

        public nk_color bar_normal;
        public nk_color bar_hover;
        public nk_color bar_active;
        public nk_color bar_filled;

        public nk_style_item cursor_normal;
        public nk_style_item cursor_hover;
        public nk_style_item cursor_active;

        public float border;
        public float rounding;
        public float bar_height;
        public nk_vec2 padding;
        public nk_vec2 spacing;
        public nk_vec2 cursor_size;

        public int show_buttons;
        public nk_style_button inc_button;
        public nk_style_button dec_button;
        public nk_symbol_type inc_symbol;
        public nk_symbol_type dec_symbol;

        public nk_handle userdata;
        public IntPtr draw_begin_nkStyleDrawBeginEnd;
        public IntPtr draw_end_nkStyleDrawBeginEnd;
    }
}