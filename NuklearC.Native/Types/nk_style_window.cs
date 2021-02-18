using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_window {
        public nk_style_window_header header;
        public nk_style_item fixed_background;
        public nk_color background;

        public nk_color border_color;
        public nk_color popup_border_color;
        public nk_color combo_border_color;
        public nk_color contextual_border_color;
        public nk_color menu_border_color;
        public nk_color group_border_color;
        public nk_color tooltip_border_color;
        public nk_style_item scaler;

        public float border;
        public float combo_border;
        public float contextual_border;
        public float menu_border;
        public float group_border;
        public float tooltip_border;
        public float popup_border;
        public float min_row_height_padding;

        public float rounding;
        public nk_vec2 spacing;
        public nk_vec2 scrollbar_size;
        public nk_vec2 min_size;

        public nk_vec2 padding;
        public nk_vec2 group_padding;
        public nk_vec2 popup_padding;
        public nk_vec2 combo_padding;
        public nk_vec2 contextual_padding;
        public nk_vec2 menu_padding;
        public nk_vec2 tooltip_padding;
    }
}