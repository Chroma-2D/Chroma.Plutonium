using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_rect_multi_color
    {
        public nk_command header;
        public short x;
        public short y;
        public ushort w;
        public ushort h;
        public nk_color left;
        public nk_color top;
        public nk_color bottom;
        public nk_color right;
    }
}