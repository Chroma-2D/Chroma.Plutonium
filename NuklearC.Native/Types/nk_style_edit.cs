using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_edit {
        public nk_style_item normal;
        public nk_style_item hover;
        public nk_style_item active;
        public nk_color border_color;
        public nk_style_scrollbar scrollbar;

        public nk_color cursor_normal;
        public nk_color cursor_hover;
        public nk_color cursor_text_normal;
        public nk_color cursor_text_hover;

        public nk_color text_normal;
        public nk_color text_hover;
        public nk_color text_active;

        public nk_color selected_normal;
        public nk_color selected_hover;
        public nk_color selected_text_normal;
        public nk_color selected_text_hover;

        public float border;
        public float rounding;
        public float cursor_size;
        public nk_vec2 scrollbar_size;
        public nk_vec2 padding;
        public float row_padding;
    }
}