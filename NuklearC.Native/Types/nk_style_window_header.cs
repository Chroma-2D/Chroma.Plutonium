using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_window_header {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;

        public nk_style_button close_button;
        public nk_style_button minimize_button;
        public nk_symbol_type close_symbol;
        public nk_symbol_type minimize_symbol;
        public nk_symbol_type maximize_symbol;

        public nk_color label_normal;
        public nk_color label_hover;
        public nk_color label_active;

        public nk_style_header_align align;
        public nk_vec2 padding;
        public nk_vec2 label_padding;
        public nk_vec2 spacing;
    }
}