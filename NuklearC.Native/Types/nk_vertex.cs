using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_vertex
    {
        public nk_vec2 position;
        public nk_vec2 uv;
        public nk_color color;

        public override string ToString()
        {
            return string.Format("Position: {0}; UV: {1}; Color: {2}", position, uv, color);
        }
    }
}