using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_convert_config
    {
        public float global_alpha;
        public nk_anti_aliasing line_AA;
        public nk_anti_aliasing shape_AA;
        public uint circle_segment_count;
        public uint arc_segment_count;
        public uint curve_segment_count;
        public nk_draw_null_texture null_tex;
        public nk_draw_vertex_layout_element* vertex_layout;
        public IntPtr vertex_size;
        public IntPtr vertex_alignment;
    }
}