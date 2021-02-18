using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_combo {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;
        public nk_color border_color;

        public nk_color label_normal;
        public nk_color label_hover;
        public nk_color label_active;

        public nk_color symbol_normal;
        public nk_color symbol_hover;
        public nk_color symbol_active;

        public nk_style_button button;
        public nk_symbol_type sym_normal;
        public nk_symbol_type sym_hover;
        public nk_symbol_type sym_active;

        public float border;
        public float rounding;
        public nk_vec2 content_padding;
        public nk_vec2 button_padding;
        public nk_vec2 spacing;
    }
}