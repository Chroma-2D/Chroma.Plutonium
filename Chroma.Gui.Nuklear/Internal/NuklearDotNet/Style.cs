using System;
using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet {
	internal enum nk_style_item_type {
		NK_STYLE_ITEM_COLOR,
		NK_STYLE_ITEM_IMAGE
	}

	[StructLayout(LayoutKind.Explicit)]
	internal struct nk_style_item_data {
		[FieldOffset(0)]
		internal NkColor color;

		[FieldOffset(0)]
		internal nk_image image;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_item {
		internal nk_style_item_type type;
		internal nk_style_item_data data;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_text {
		internal NkColor color;
		internal nk_vec2 padding;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void nk_style_drawbeginend(nk_command_buffer* cbuf, NkHandle userdata);

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_button {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;

		internal NkColor text_background;
		internal NkColor text_normal;
		internal NkColor text_hover;
		internal NkColor text_active;
		internal uint text_alignment_nkflags;

		internal float border;
		internal float rounding;
		internal nk_vec2 padding;
		internal nk_vec2 image_padding;
		internal nk_vec2 touch_padding;

		internal NkHandle userdata;
		internal IntPtr draw_begin_nkStyleDrawBeginEnd;
		internal IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_toggle {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;

		internal nk_style_item cursor_normal;
		internal nk_style_item cursor_hover;

		internal NkColor text_normal;
		internal NkColor text_hover;
		internal NkColor text_active;
		internal NkColor text_background;
		internal uint text_alignment_nkflags;

		internal nk_vec2 padding;
		internal nk_vec2 touch_padding;
		internal float spacing;
		internal float border;

		internal NkHandle userdata;
		internal IntPtr draw_begin_nkStyleDrawBeginEnd;
		internal IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_selectable {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item pressed;

		internal nk_style_item normal_active;
		internal nk_style_item hover_active;
		internal nk_style_item pressed_active;

		internal NkColor text_normal;
		internal NkColor text_hover;
		internal NkColor text_pressed;

		internal NkColor text_normal_active;
		internal NkColor text_hover_active;
		internal NkColor text_pressed_active;
		internal NkColor text_background;
		internal uint text_alignment_nkflags;

		internal float rounding;
		internal nk_vec2 padding;
		internal nk_vec2 touch_padding;
		internal nk_vec2 image_padding;

		internal NkHandle userdata;
		internal IntPtr draw_begin_nkStyleDrawBeginEnd;
		internal IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_slider {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;

		internal NkColor bar_normal;
		internal NkColor bar_hover;
		internal NkColor bar_active;
		internal NkColor bar_filled;

		internal nk_style_item cursor_normal;
		internal nk_style_item cursor_hover;
		internal nk_style_item cursor_active;

		internal float border;
		internal float rounding;
		internal float bar_height;
		internal nk_vec2 padding;
		internal nk_vec2 spacing;
		internal nk_vec2 cursor_size;

		internal int show_buttons;
		internal nk_style_button inc_button;
		internal nk_style_button dec_button;
		internal nk_symbol_type inc_symbol;
		internal nk_symbol_type dec_symbol;

		internal NkHandle userdata;
		internal IntPtr draw_begin_nkStyleDrawBeginEnd;
		internal IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_progress {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;

		internal nk_style_item cursor_normal;
		internal nk_style_item cursor_hover;
		internal nk_style_item cursor_active;
		internal NkColor cursor_border_color;

		internal float rounding;
		internal float border;
		internal float cursor_border;
		internal float cursor_rounding;
		internal nk_vec2 padding;

		internal NkHandle userdata;
		internal IntPtr draw_begin_nkStyleDrawBeginEnd;
		internal IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_scrollbar {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;

		internal nk_style_item cursor_normal;
		internal nk_style_item cursor_hover;
		internal nk_style_item cursor_active;
		internal NkColor cursor_border_color;

		internal float border;
		internal float rounding;
		internal float border_cursor;
		internal float rounding_cursor;
		internal nk_vec2 padding;

		internal int show_buttons;
		internal nk_style_button inc_button;
		internal nk_style_button dec_button;
		internal nk_symbol_type inc_symbol;
		internal nk_symbol_type dec_symbol;

		internal NkHandle userdata;
		internal IntPtr draw_begin_nkStyleDrawBeginEnd;
		internal IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_edit {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;
		internal nk_style_scrollbar scrollbar;

		internal NkColor cursor_normal;
		internal NkColor cursor_hover;
		internal NkColor cursor_text_normal;
		internal NkColor cursor_text_hover;

		internal NkColor text_normal;
		internal NkColor text_hover;
		internal NkColor text_active;

		internal NkColor selected_normal;
		internal NkColor selected_hover;
		internal NkColor selected_text_normal;
		internal NkColor selected_text_hover;

		internal float border;
		internal float rounding;
		internal float cursor_size;
		internal nk_vec2 scrollbar_size;
		internal nk_vec2 padding;
		internal float row_padding;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_property {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;

		internal NkColor label_normal;
		internal NkColor label_hover;
		internal NkColor label_active;

		internal nk_symbol_type sym_left;
		internal nk_symbol_type sym_right;

		internal float border;
		internal float rounding;
		internal nk_vec2 padding;

		internal nk_style_edit edit;
		internal nk_style_button inc_button;
		internal nk_style_button dec_button;

		internal NkHandle userdata;
		internal IntPtr draw_begin_nkStyleDrawBeginEnd;
		internal IntPtr draw_end_nkStyleDrawBeginEnd;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_chart {
		internal nk_style_item background;
		internal NkColor border_color;
		internal NkColor selected_color;
		internal NkColor color;

		internal float border;
		internal float rounding;
		internal nk_vec2 padding;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_combo {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;
		internal NkColor border_color;

		internal NkColor label_normal;
		internal NkColor label_hover;
		internal NkColor label_active;

		internal NkColor symbol_normal;
		internal NkColor symbol_hover;
		internal NkColor symbol_active;

		internal nk_style_button button;
		internal nk_symbol_type sym_normal;
		internal nk_symbol_type sym_hover;
		internal nk_symbol_type sym_active;

		internal float border;
		internal float rounding;
		internal nk_vec2 content_padding;
		internal nk_vec2 button_padding;
		internal nk_vec2 spacing;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_tab {
		internal nk_style_item background;
		internal NkColor border_color;
		internal NkColor text;

		internal nk_style_button tab_maximize_button;
		internal nk_style_button tab_minimize_button;
		internal nk_style_button node_maximize_button;
		internal nk_style_button node_minimize_button;
		internal nk_symbol_type sym_minimize;
		internal nk_symbol_type sym_maximize;

		internal float border;
		internal float rounding;
		internal float indent;
		internal nk_vec2 padding;
		internal nk_vec2 spacing;
	}

	internal enum nk_style_header_align {
		NK_HEADER_LEFT,
		NK_HEADER_RIGHT
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_window_header {
		internal nk_style_item normal;
		internal nk_style_item hover;
		internal nk_style_item active;

		internal nk_style_button close_button;
		internal nk_style_button minimize_button;
		internal nk_symbol_type close_symbol;
		internal nk_symbol_type minimize_symbol;
		internal nk_symbol_type maximize_symbol;

		internal NkColor label_normal;
		internal NkColor label_hover;
		internal NkColor label_active;

		internal nk_style_header_align align;
		internal nk_vec2 padding;
		internal nk_vec2 label_padding;
		internal nk_vec2 spacing;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_style_window {
		internal nk_style_window_header header;
		internal nk_style_item fixed_background;
		internal NkColor background;

		internal NkColor border_color;
		internal NkColor popup_border_color;
		internal NkColor combo_border_color;
		internal NkColor contextual_border_color;
		internal NkColor menu_border_color;
		internal NkColor group_border_color;
		internal NkColor tooltip_border_color;
		internal nk_style_item scaler;

		internal float border;
		internal float combo_border;
		internal float contextual_border;
		internal float menu_border;
		internal float group_border;
		internal float tooltip_border;
		internal float popup_border;
		internal float min_row_height_padding;

		internal float rounding;
		internal nk_vec2 spacing;
		internal nk_vec2 scrollbar_size;
		internal nk_vec2 min_size;

		internal nk_vec2 padding;
		internal nk_vec2 group_padding;
		internal nk_vec2 popup_padding;
		internal nk_vec2 combo_padding;
		internal nk_vec2 contextual_padding;
		internal nk_vec2 menu_padding;
		internal nk_vec2 tooltip_padding;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_style {
		internal nk_user_font* font;

		/* fixed nk_cursor* cursors[(int)(nk_style_cursor.NK_CURSOR_COUNT)]; */
		internal nk_cursor* cursorArrow;
		internal nk_cursor* cursorText;
		internal nk_cursor* cursorMove;
		internal nk_cursor* cursorResizeV;
		internal nk_cursor* cursorResizeH;
		internal nk_cursor* cursorResizeTLDR;
		internal nk_cursor* cursorResizeTRDL;

		internal nk_cursor* cursor_active;
		internal nk_cursor* cursor_last;
		internal int cursor_visible;

		internal nk_style_text text;
		internal nk_style_button button;
		internal nk_style_button contextual_button;
		internal nk_style_button menu_button;
		internal nk_style_toggle option;
		internal nk_style_toggle checkbox;
		internal nk_style_selectable selectable;
		internal nk_style_slider slider;
		internal nk_style_progress progress;
		internal nk_style_property property;
		internal nk_style_edit edit;
		internal nk_style_chart chart;
		internal nk_style_scrollbar scrollh;
		internal nk_style_scrollbar scrollv;
		internal nk_style_tab tab;
		internal nk_style_combo combo;
		internal nk_style_window window;
	}

	internal enum nk_style_colors {
		NK_COLOR_TEXT,
		NK_COLOR_WINDOW,
		NK_COLOR_HEADER,
		NK_COLOR_BORDER,
		NK_COLOR_BUTTON,
		NK_COLOR_BUTTON_HOVER,
		NK_COLOR_BUTTON_ACTIVE,
		NK_COLOR_TOGGLE,
		NK_COLOR_TOGGLE_HOVER,
		NK_COLOR_TOGGLE_CURSOR,
		NK_COLOR_SELECT,
		NK_COLOR_SELECT_ACTIVE,
		NK_COLOR_SLIDER,
		NK_COLOR_SLIDER_CURSOR,
		NK_COLOR_SLIDER_CURSOR_HOVER,
		NK_COLOR_SLIDER_CURSOR_ACTIVE,
		NK_COLOR_PROPERTY,
		NK_COLOR_EDIT,
		NK_COLOR_EDIT_CURSOR,
		NK_COLOR_COMBO,
		NK_COLOR_CHART,
		NK_COLOR_CHART_COLOR,
		NK_COLOR_CHART_COLOR_HIGHLIGHT,
		NK_COLOR_SCROLLBAR,
		NK_COLOR_SCROLLBAR_CURSOR,
		NK_COLOR_SCROLLBAR_CURSOR_HOVER,
		NK_COLOR_SCROLLBAR_CURSOR_ACTIVE,
		NK_COLOR_TAB_HEADER,
		NK_COLOR_COUNT
	}

	internal enum nk_style_cursor {
		NK_CURSOR_ARROW,
		NK_CURSOR_TEXT,
		NK_CURSOR_MOVE,
		NK_CURSOR_RESIZE_VERTICAL,
		NK_CURSOR_RESIZE_HORIZONTAL,
		NK_CURSOR_RESIZE_TOP_LEFT_DOWN_RIGHT,
		NK_CURSOR_RESIZE_TOP_RIGHT_DOWN_LEFT,
		NK_CURSOR_COUNT
	}

	// [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
	internal static unsafe partial class LibNuklear {
		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_style_default(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_style_from_table(nk_context* ctx, NkColor* color);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_style_load_cursor(nk_context* ctx, nk_style_cursor scur, nk_cursor* cursor);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_style_load_all_cursors(nk_context* ctx, nk_cursor* cursor);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern byte* nk_style_get_color_by_name(nk_style_colors scol);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_style_set_font(nk_context* ctx, nk_user_font* userfont);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_set_cursor(nk_context* ctx, nk_style_cursor scur);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_style_show_cursor(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_style_hide_cursor(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_push_font(nk_context* ctx, nk_user_font* userfont);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_push_float(nk_context* ctx, float* f, float g);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_push_vec2(nk_context* ctx, nk_vec2* a, nk_vec2 b);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_push_style_item(nk_context* ctx, nk_style_item* sitem, nk_style_item sitem2);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_push_flags(nk_context* ctx, uint* a_nkflags, uint b_nkflags);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_push_color(nk_context* ctx, NkColor* a, NkColor b);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_pop_font(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_pop_float(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_pop_vec2(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_pop_style_item(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_pop_flags(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_style_pop_color(nk_context* ctx);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgb(int r, int g, int b);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgb_iv(int* rgb);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgb_bv(byte* rgb);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgb_f(float r, float g, float b);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgb_fv(float* rgb);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgb_hex(byte* rgb);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgba(int r, int g, int b, int a);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgba_u32(uint rgba);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgba_iv(int* rgba);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgba_bv(byte* rgba);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgba_f(float r, float g, float b, float a);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgba_fv(float* rgba);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_rgba_hex(float* hsv);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_hsva(int h, int s, int v, int a);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_hsva_iv(int* hsva);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_hsva_bv(byte* hsva);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_hsva_f(float h, float s, float v, float a);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern NkColor nk_hsva_fv(float* hsva);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_f(out float r, out float g, out float b, out float a, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_fv(float* rgba_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_d(out double r, out double g, out double b, out double a, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_dv(double* rgba_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern uint nk_color_u32(NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hex_rgba(byte* output, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hex_rgb(byte* output, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsv_i(out int h, out int s, out int v, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsv_b(out byte h, out byte s, out byte v, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsv_iv(int* hsv_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsv_bv(byte* hsv_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsv_f(out float h, out float s, out float v, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsv_fv(float* hsv_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsva_i(out int h, out int s, out int v, out int a, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsva_b(out byte h, out byte s, out byte v, out byte a, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsva_iv(int* hsva_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsva_bv(byte* hsva_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsva_f(out float h, out float s, out float v, out float a, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_color_hsva_fv(float* hsva_out, NkColor src);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_style_item nk_style_item_image(nk_image img);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_style_item nk_style_item_color(NkColor col);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_style_item nk_style_item_hide();
	}
}
