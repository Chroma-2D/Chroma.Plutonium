using System;
using System.Runtime.InteropServices;
using System.Text;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_window* nk_window_find(nk_context* ctx, byte* name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_window_get_bounds(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_window_get_position(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_window_get_size(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float nk_window_get_width(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float nk_window_get_height(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_panel* nk_window_get_panel(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_window_get_content_region(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_window_get_content_region_min(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_window_get_content_region_max(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_window_get_content_region_size(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_command_buffer* nk_window_get_canvas(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_has_focus(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_collapsed(nk_context* ctx, byte* name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_collapsed(nk_context* ctx, string name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_closed(nk_context* ctx, byte* name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_closed(nk_context* ctx, string name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_hidden(nk_context* ctx, byte* name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_hidden(nk_context* ctx, string name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_active(nk_context* ctx, byte* name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_hovered(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_window_is_any_hovered(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_item_is_any_active(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_set_bounds(nk_context* ctx, byte* name, nk_rect bounds);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_set_position(nk_context* ctx, byte* name, nk_vec2 pos);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_set_size(nk_context* ctx, byte* name, nk_vec2 sz);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_set_focus(nk_context* ctx, byte* name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_close(nk_context* ctx, byte* name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_close(nk_context* ctx, string name);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_collapse(nk_context* ctx, byte* name, nk_collapse_states state);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_collapse_if(
            nk_context* ctx,
            byte* name,
            nk_collapse_states state,
            int cond
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_show(nk_context* ctx, byte* name, nk_show_states state);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_window_show_if(nk_context* ctx, byte* name, nk_show_states state, int cond);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_group_begin(nk_context* ctx, byte* title, uint nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_group_begin(nk_context* ctx, string title, uint nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_group_begin_titled(nk_context* ctx, string id, string title, nk_panel_flags flags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_group_scrolled_offset_begin(
            nk_context* ctx,
            ref uint x_offset,
            ref uint y_offset,
            string title,
            nk_panel_flags flags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_group_scrolled_begin(
            nk_context* ctx,
            nk_scroll* scroll,
            string title,
            nk_panel_flags nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_group_scrolled_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_group_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_list_view_begin(
            nk_context* ctx,
            nk_list_view* nlv_out,
            string id,
            uint nkflags,
            int row_height,
            int row_count
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_list_view_end(nk_list_view* nlv);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_tree_push_hashed(
            nk_context* ctx,
            nk_tree_type tree_type,
            byte* title,
            nk_collapse_states initial_state,
            byte* hash,
            int len,
            int seed
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_tree_image_push_hashed(
            nk_context* ctx,
            nk_tree_type tree_type,
            nk_image img,
            byte* title,
            nk_collapse_states initial_state,
            byte* hash,
            int len,
            int seed
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_tree_pop(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_tree_state_push(
            nk_context* ctx,
            nk_tree_type tree_type,
            byte* title,
            nk_collapse_states* state
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_tree_state_image_push(
            nk_context* ctx,
            nk_tree_type tree_type,
            nk_image img,
            byte* title,
            nk_collapse_states* state
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_tree_state_pop(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_widget_layout_states nk_widget(nk_rect* r, nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_widget_layout_states nk_widget_fitting(nk_rect* r, nk_context* ctx, nk_vec2 v);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_rect nk_widget_bounds(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_widget_position(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_vec2 nk_widget_size(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float nk_widget_width(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float nk_widget_height(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_widget_is_hovered(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_widget_is_mouse_clicked(nk_context* ctx, nk_buttons buttons);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_widget_has_mouse_click_down(nk_context* ctx, nk_buttons buttons, int down);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_spacing(nk_context* ctx, int cols);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_text(nk_context* ctx, byte* s, int i, uint flags_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_text_colored(
            nk_context* ctx,
            byte* s,
            int i,
            uint nkflags,
            nk_color color
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_text_wrap(nk_context* ctx, byte* s, int i);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_text_wrap_colored(nk_context* ctx, byte* s, int i, nk_color color);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_label(nk_context* ctx, byte* s, uint align_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_label(nk_context* ctx, string s, uint align_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_label_colored(
            nk_context* ctx,
            string s,
            nk_text_align align_nkflags,
            nk_color color
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_label_wrap(nk_context* ctx, string s);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_label_colored_wrap(nk_context* ctx, string s, nk_color color);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_image(nk_context* ctx, nk_image img);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_text(nk_context* ctx, string title, int len);

        public static bool nk_button_text(nk_context* ctx, string title)
            => nk_button_text(ctx, title, title.Length) != 0;

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_label(nk_context* ctx, string title);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_color(nk_context* ctx, nk_color color);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_symbol(nk_context* ctx, nk_symbol_type symtype);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_image(nk_context* ctx, nk_image img);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_symbol_label(
            nk_context* ctx,
            nk_symbol_type stype,
            string text,
            nk_text_alignment text_alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_symbol_text(
            nk_context* ctx,
            nk_symbol_type stype,
            string text,
            int length,
            nk_text_align alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_image_label(
            nk_context* ctx,
            nk_image img,
            byte* s,
            uint text_alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_image_text(
            nk_context* ctx,
            nk_image img,
            byte* s,
            int i,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_text_styled(
            nk_context* ctx,
            nk_style_button* bstyle,
            byte* title,
            int len
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_label_styled(
            nk_context* ctx,
            nk_style_button* bstyle,
            byte* title
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_symbol_styled(
            nk_context* ctx,
            nk_style_button* bstyle,
            nk_symbol_type stype
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_image_styled(nk_context* ctx, nk_style_button* bstyle, nk_image img);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_symbol_text_styled(
            nk_context* ctx,
            nk_style_button* bstyle,
            nk_symbol_type stype,
            byte* s,
            int i,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_symbol_label_styled(
            nk_context* ctx,
            nk_style_button* bstyle,
            nk_symbol_type stype,
            byte* title,
            uint align_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_image_label_styled(
            nk_context* ctx,
            nk_style_button* bstyle,
            nk_image img,
            byte* s,
            uint text_alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_image_text_styled(
            nk_context* ctx,
            nk_style_button* bstyle,
            nk_image img,
            byte* s,
            int i,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_button_set_behavior(nk_context* ctx, nk_button_behavior behavior);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_push_behavior(nk_context* ctx, nk_button_behavior behavior);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_button_pop_behavior(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_check_label(nk_context* ctx, byte* s, int active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_check_text(nk_context* ctx, byte* s, int i, int active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_check_flags_label(nk_context* ctx, byte* s, uint flags, uint val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_check_flags_text(nk_context* ctx, byte* s, int i, uint flags, uint val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_checkbox_label(nk_context* ctx, byte* s, int* active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_checkbox_text(nk_context* ctx, byte* s, int i, int* active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_checkbox_flags_label(nk_context* ctx, byte* s, uint* flags, uint val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_checkbox_flags_text(nk_context* ctx, byte* s, int i, uint* flags, uint val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_radio_label(nk_context* ctx, byte* s, int* active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_radio_text(nk_context* ctx, byte* s, int i, int* active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_option_label(nk_context* ctx, byte* s, int active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_option_text(nk_context* ctx, byte* s, int i, int active);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_selectable_label(nk_context* ctx, byte* s, uint align_nkflags, int* val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_selectable_text(nk_context* ctx, byte* s, int i, uint align_nkflags, int* val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_selectable_image_label(
            nk_context* ctx,
            nk_image img,
            byte* s,
            uint align_nkflags,
            int* val
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_selectable_image_text(
            nk_context* ctx,
            nk_image img,
            byte* s,
            int i,
            uint align_nkflags,
            int* val
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_select_label(nk_context* ctx, byte* s, uint align_nkflags, int val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_select_text(nk_context* ctx, byte* s, int i, uint align_nkflags, int val);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_select_image_label(
            nk_context* ctx,
            nk_image img,
            byte* s,
            uint align_nkflags,
            int val
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_select_image_text(
            nk_context* ctx,
            nk_image img,
            byte* s,
            int i,
            uint align_nkflags,
            int val
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float nk_slide_float(nk_context* ctx, float min, float val, float max, float step);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_slide_int(nk_context* ctx, int min, int val, int max, int step);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_slider_float(nk_context* ctx, float min, float* val, float max, float step);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_slider_int(nk_context* ctx, int min, int* val, int max, int step);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_progress(nk_context* ctx, IntPtr* cur_nksize, IntPtr max_nksize, int modifyable);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nk_prog(nk_context* ctx, IntPtr cur_nksize, IntPtr max_nksize, int modifyable);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_colorf nk_color_picker(nk_context* ctx, nk_colorf color, nk_color_format cfmt);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_color_pick(nk_context* ctx, nk_colorf* color, nk_color_format cfmt);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_property_int(
            nk_context* ctx,
            byte* name,
            int min,
            int* val,
            int max,
            int step,
            float inc_per_pixel
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_property_float(
            nk_context* ctx,
            byte* name,
            float min,
            float* val,
            float max,
            float step,
            float inc_per_pixel
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_property_double(
            nk_context* ctx,
            byte* name,
            double min,
            double* val,
            double max,
            double step,
            float inc_per_pixel
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_propertyi(
            nk_context* ctx,
            byte* name,
            int min,
            int val,
            int max,
            int step,
            float inc_per_pixel
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float nk_propertyf(
            nk_context* ctx,
            byte* name,
            float min,
            float val,
            float max,
            float step,
            float inc_per_pixel
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern double nk_propertyd(
            nk_context* ctx,
            byte* name,
            double min,
            double val,
            double max,
            double step,
            float inc_per_pixel
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_edit_string(
            nk_context* ctx,
            uint flags_nkflags,
            byte* buffer,
            int* len,
            int max,
            nk_plugin_filter_t filterfun
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_edit_string(
            nk_context* ctx,
            uint flags_nkflags,
            StringBuilder buffer,
            int* len,
            int max,
            nk_plugin_filter_t filterfun
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_edit_string_zero_terminated(
            nk_context* ctx,
            uint flags_nkflags,
            byte* buffer,
            int max,
            nk_plugin_filter_t filterfun
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_edit_string_zero_terminated(
            nk_context* ctx,
            uint flags_nkflags,
            StringBuilder buffer,
            int max,
            nk_plugin_filter_t filterfun
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_edit_buffer(
            nk_context* ctx,
            uint flags_nkflags,
            nk_text_edit* textedit,
            nk_plugin_filter_t filterfun
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_edit_focus(nk_context* ctx, uint flags_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_edit_unfocus(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_chart_begin(
            nk_context* ctx,
            nk_chart_type chart_type,
            int num,
            float min,
            float max
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_chart_begin_colored(
            nk_context* ctx,
            nk_chart_type chart_type,
            nk_color color,
            nk_color active,
            int num,
            float min,
            float max
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_chart_add_slot(
            nk_context* ctx,
            nk_chart_type chart_type,
            int count,
            float min_value,
            float max_value
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_chart_add_slot_colored(
            nk_context* ctx,
            nk_chart_type chart_type,
            nk_color color,
            nk_color active,
            int count,
            float min_value,
            float max_value
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_chart_push(nk_context* ctx, float f);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_chart_push_slot(nk_context* ctx, float f, int i);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_chart_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_plot(
            nk_context* ctx,
            nk_chart_type chart_type,
            float* values,
            int count,
            int offset
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_plot_function(
            nk_context* ctx,
            nk_chart_type chart_type,
            IntPtr userdata,
            nk_value_getter_fun getterfun,
            int count,
            int offset
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_popup_begin(
            nk_context* ctx,
            nk_popup_type type,
            byte* s,
            uint flags_nkflags,
            nk_rect bounds
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_popup_close(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_popup_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo(
            nk_context* ctx,
            byte** items,
            int count,
            int selected,
            int item_height,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_separator(nk_context* ctx, byte* items_separated_by_separator,
            int separator, int selected, int count, int item_height, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_string(nk_context* ctx, byte* items_separated_by_zeros, int selected,
            int count, int item_height, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_callback(
            nk_context* ctx,
            nk_item_getter_fun getterfun,
            IntPtr userdata,
            int selected,
            int count,
            int item_height,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_combobox(
            nk_context* ctx,
            byte** items,
            int count,
            int* selected,
            int item_height,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_combobox_string(
            nk_context* ctx,
            byte* items_separated_by_zeros,
            int* selected,
            int count,
            int item_height,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_combobox_separator(
            nk_context* ctx,
            byte* items_separated_by_separator,
            int separator,
            int* selected,
            int count,
            int item_height,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_combobox_callback(
            nk_context* ctx,
            nk_item_getter_fun getterfun,
            IntPtr userdata,
            int* selected,
            int count,
            int item_height,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_text(nk_context* ctx, char* selected, int i, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_label(nk_context* ctx, char* selected, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_color(nk_context* ctx, nk_color color, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_symbol(nk_context* ctx, nk_symbol_type stype, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_symbol_label(
            nk_context* ctx,
            char* selected, nk_symbol_type stype,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_symbol_text(
            nk_context* ctx,
            char* selected,
            int i,
            nk_symbol_type stype,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_image(nk_context* ctx, nk_image img, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_image_label(
            nk_context* ctx,
            char* selected,
            nk_image img,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_begin_image_text(
            nk_context* ctx,
            char* selected,
            int i,
            nk_image img,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_item_label(nk_context* ctx, byte* s, uint alignment_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_item_text(nk_context* ctx, byte* s, int i, uint alignment_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_item_image_label(
            nk_context* ctx,
            nk_image img,
            byte* s,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_item_image_text(
            nk_context* ctx,
            nk_image img,
            byte* s,
            int i,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_item_symbol_label(
            nk_context* ctx,
            nk_symbol_type stype,
            byte* s,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_combo_item_symbol_text(
            nk_context* ctx,
            nk_symbol_type stype,
            byte* s,
            int i,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_combo_close(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_combo_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_contextual_begin(
            nk_context* ctx,
            uint flags_nkflags,
            nk_vec2 v,
            nk_rect trigger_bounds
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_contextual_item_text(nk_context* ctx, byte* s, int i, uint align_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_contextual_item_label(nk_context* ctx, byte* s, uint align_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_contextual_item_image_label(
            nk_context* ctx,
            nk_image img,
            byte* s,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_contextual_item_image_text(
            nk_context* ctx,
            nk_image img,
            byte* s,
            int len,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_contextual_item_symbol_label(
            nk_context* ctx,
            nk_symbol_type stype,
            byte* s,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_contextual_item_symbol_text(
            nk_context* ctx,
            nk_symbol_type stype,
            byte* s,
            int i,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_contextual_close(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_contextual_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_tooltip(nk_context* ctx, byte* s);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_tooltip_begin(nk_context* ctx, float width);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_tooltip_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_menubar_begin(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_menubar_end(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_text(
            nk_context* ctx,
            byte* title,
            int title_len,
            uint align_nkflags,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_label(nk_context* ctx, byte* s, uint align_nkflags, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_image(nk_context* ctx, byte* s, nk_image img, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_image_text(
            nk_context* ctx,
            byte* s,
            int slen,
            uint align_nkflags,
            nk_image img,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_image_label(
            nk_context* ctx,
            byte* s,
            uint align_nkflags,
            nk_image img,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_symbol(nk_context* ctx, byte* s, nk_symbol_type stype, nk_vec2 size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_symbol_text(
            nk_context* ctx,
            byte* s,
            int slen,
            uint align_nkflags,
            nk_symbol_type stype,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_begin_symbol_label(
            nk_context* ctx,
            byte* s,
            uint align_nkflags,
            nk_symbol_type stype,
            nk_vec2 size
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_item_text(nk_context* ctx, byte* s, int slen, uint align_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_item_label(nk_context* ctx, byte* s, uint alignment_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_item_image_label(
            nk_context* ctx,
            nk_image img,
            byte* s,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_item_image_text(
            nk_context* ctx,
            nk_image img,
            byte* s,
            int slen,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_item_symbol_text(
            nk_context* ctx,
            nk_symbol_type stype,
            byte* s,
            int slen,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_menu_item_symbol_label(
            nk_context* ctx,
            nk_symbol_type stype,
            byte* s,
            uint alignment_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_menu_close(nk_context* ctx);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_menu_end(nk_context* ctx);
    }
}