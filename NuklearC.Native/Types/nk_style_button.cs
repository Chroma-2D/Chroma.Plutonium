using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_button {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;
        public nk_color border_color;

        public nk_color text_background;
        public nk_color text_normal;
        public nk_color text_hover;
        public nk_color text_active;
        public uint text_alignment_nkflags;

        public float border;
        public float rounding;
        public nk_vec2 padding;
        public nk_vec2 image_padding;
        public nk_vec2 touch_padding;

        public nk_handle userdata;
        public IntPtr draw_begin_nkStyleDrawBeginEnd;
        public IntPtr draw_end_nkStyleDrawBeginEnd;
    }
}