using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_property {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;
        public nk_color border_color;

        public nk_color label_normal;
        public nk_color label_hover;
        public nk_color label_active;

        public nk_symbol_type sym_left;
        public nk_symbol_type sym_right;

        public float border;
        public float rounding;
        public nk_vec2 padding;

        public nk_style_edit edit;
        public nk_style_button inc_button;
        public nk_style_button dec_button;

        public nk_handle userdata;
        public IntPtr draw_begin_nkStyleDrawBeginEnd;
        public IntPtr draw_end_nkStyleDrawBeginEnd;
    }
}