using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_draw_command
    {
        public uint elem_count;
        public nk_rect clip_rect;
        public nk_handle texture;
        public nk_handle userdata;
    }
}