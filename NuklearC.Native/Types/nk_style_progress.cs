using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_progress {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;
        public nk_color border_color;

        public nk_style_item cursor_normal;
        public nk_style_item cursor_hover;
        public nk_style_item cursor_active;
        public nk_color cursor_border_color;

        public float rounding;
        public float border;
        public float cursor_border;
        public float cursor_rounding;
        public nk_vec2 padding;

        public nk_handle userdata;
        public IntPtr draw_begin_nkStyleDrawBeginEnd;
        public IntPtr draw_end_nkStyleDrawBeginEnd;
    }
}