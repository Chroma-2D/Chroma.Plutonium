using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_rect
    {
        public nk_command header;
        public ushort rounding;
        public ushort line_thickness;
        public short x;
        public short y;
        public ushort w;
        public ushort h;
        public nk_color color;
    }
}