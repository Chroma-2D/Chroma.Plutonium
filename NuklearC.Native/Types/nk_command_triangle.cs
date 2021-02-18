using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_triangle
    {
        public nk_command header;
        public ushort line_thickness;
        public nk_vec2i a;
        public nk_vec2i b;
        public nk_vec2i c;
        public nk_color color;
    }
}