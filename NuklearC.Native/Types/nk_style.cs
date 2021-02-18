using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_style {
        public nk_user_font* font;

        /* fixed nk_cursor* cursors[(int)(nk_style_cursor.NK_CURSOR_COUNT)]; */
        public nk_cursor* cursorArrow;
        public nk_cursor* cursorText;
        public nk_cursor* cursorMove;
        public nk_cursor* cursorResizeV;
        public nk_cursor* cursorResizeH;
        public nk_cursor* cursorResizeTLDR;
        public nk_cursor* cursorResizeTRDL;

        public nk_cursor* cursor_active;
        public nk_cursor* cursor_last;
        public int cursor_visible;

        public nk_style_text text;
        public nk_style_button button;
        public nk_style_button contextual_button;
        public nk_style_button menu_button;
        public nk_style_toggle option;
        public nk_style_toggle checkbox;
        public nk_style_selectable selectable;
        public nk_style_slider slider;
        public nk_style_progress progress;
        public nk_style_property property;
        public nk_style_edit edit;
        public nk_style_chart chart;
        public nk_style_scrollbar scrollh;
        public nk_style_scrollbar scrollv;
        public nk_style_tab tab;
        public nk_style_combo combo;
        public nk_style_window window;
    }
}