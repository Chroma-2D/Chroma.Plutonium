using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_selectable {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item pressed;

        public nk_style_item normal_active;
        public nk_style_item hover_active;
        public nk_style_item pressed_active;

        public nk_color text_normal;
        public nk_color text_hover;
        public nk_color text_pressed;

        public nk_color text_normal_active;
        public nk_color text_hover_active;
        public nk_color text_pressed_active;
        public nk_color text_background;
        public uint text_alignment_nkflags;

        public float rounding;
        public nk_vec2 padding;
        public nk_vec2 touch_padding;
        public nk_vec2 image_padding;

        public nk_handle userdata;
        public IntPtr draw_begin_nkStyleDrawBeginEnd;
        public IntPtr draw_end_nkStyleDrawBeginEnd;
    }
}