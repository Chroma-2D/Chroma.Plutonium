using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_toggle {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;
        public nk_color border_color;

        public nk_style_item cursor_normal;
        public nk_style_item cursor_hover;

        public nk_color text_normal;
        public nk_color text_hover;
        public nk_color text_active;
        public nk_color text_background;
        public uint text_alignment_nkflags;

        public nk_vec2 padding;
        public nk_vec2 touch_padding;
        public float spacing;
        public float border;

        public nk_handle userdata;
        public IntPtr draw_begin_nkStyleDrawBeginEnd;
        public IntPtr draw_end_nkStyleDrawBeginEnd;
    }
}