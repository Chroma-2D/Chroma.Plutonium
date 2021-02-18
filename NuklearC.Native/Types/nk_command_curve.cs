using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_curve
    {
        public nk_command header;
        public ushort line_thickness;
        public nk_vec2i begin;
        public nk_vec2i end;
        public nk_vec2i ctrlA;
        public nk_vec2i ctrlB;
        public nk_color color;
    }
}