using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_chart {
        public nk_style_item background;
        public nk_color border_color;
        public nk_color selected_color;
        public nk_color color;

        public float border;
        public float rounding;
        public nk_vec2 padding;
    }
}