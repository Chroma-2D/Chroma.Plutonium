using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_draw_list
    {
        public nk_rect clip_rect;
        public fixed long circle_vtx_CastMeToVec2[12];
        public nk_convert_config config;

        public nk_buffer* buffer;
        public nk_buffer* vertices;
        public nk_buffer* elements;

        public uint element_count;
        public uint vertex_count;
        public uint cmd_count;
        public IntPtr cmd_offset_nksize;

        public uint path_count;
        public uint path_offset;

        public nk_anti_aliasing line_AA;
        public nk_anti_aliasing shape_AA;

        public nk_handle userdata;
    }
}