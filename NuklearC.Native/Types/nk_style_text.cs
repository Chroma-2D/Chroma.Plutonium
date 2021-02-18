using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_text {
        public nk_color color;
        public nk_vec2 padding;
    }
}