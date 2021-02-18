using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_rect_filled
    {
        public nk_command header;
        public ushort rounding;
        public short x;
        public short y;
        public ushort w;
        public ushort h;
        public nk_color color;
    }
}