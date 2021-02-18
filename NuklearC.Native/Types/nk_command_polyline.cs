using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_polyline
    {
        public nk_command header;
        public nk_color color;
        public ushort line_thickness;
        public ushort point_count;
        public nk_vec2i firstPoint;
    }
}