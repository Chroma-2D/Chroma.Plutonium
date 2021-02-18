using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_command_arc_filled
    {
        public nk_command header;
        public short cx;
        public short cy;
        public ushort r;
        public fixed float a[2];
        public nk_color color;
    }
}