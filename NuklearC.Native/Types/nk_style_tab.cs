using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_tab {
        public nk_style_item background;
        public nk_color border_color;
        public nk_color text;

        public nk_style_button tab_maximize_button;
        public nk_style_button tab_minimize_button;
        public nk_style_button node_maximize_button;
        public nk_style_button node_minimize_button;
        public nk_symbol_type sym_minimize;
        public nk_symbol_type sym_maximize;

        public float border;
        public float rounding;
        public float indent;
        public nk_vec2 padding;
        public nk_vec2 spacing;
    }
}