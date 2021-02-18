using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_polygon_filled
    {
        public nk_command header;
        public nk_color color;
        public ushort point_count;
        public nk_vec2i firstPoint;
    }
}