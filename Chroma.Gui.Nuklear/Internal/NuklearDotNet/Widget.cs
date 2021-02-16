﻿using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet
{
    [Flags]
    internal enum NkPanelFlags : uint
    {
        // nk_panel_flags, NK_WINDOW_*
        Border = (1 << (0)),
        Movable = (1 << (1)),
        Scalable = (1 << (2)),
        Closable = (1 << (3)),
        Minimizable = (1 << (4)),
        NoScrollbar = (1 << (5)),
        Title = (1 << (6)),
        ScrollAutoHide = (1 << (7)),
        Background = (1 << (8)),
        ScaleLeft = (1 << (9)),
        NoInput = (1 << (10)),

        BorderTitle = Border | Title,
        ClosableMinimizable = Closable | Minimizable,
        MovableScalable = Movable | Scalable
    }

    [Flags]
    internal enum nk_panel_type : uint
    {
        NK_PANEL_WINDOW = (1 << (0)),
        NK_PANEL_GROUP = (1 << (1)),
        NK_PANEL_POPUP = (1 << (2)),
        NK_PANEL_CONTEXTUAL = (1 << (4)),
        NK_PANEL_COMBO = (1 << (5)),
        NK_PANEL_MENU = (1 << (6)),
        NK_PANEL_TOOLTIP = (1 << (7))
    }

    internal enum nk_panel_set : uint
    {
        NK_PANEL_SET_NONBLOCK = nk_panel_type.NK_PANEL_CONTEXTUAL | nk_panel_type.NK_PANEL_COMBO |
                                nk_panel_type.NK_PANEL_MENU | nk_panel_type.NK_PANEL_TOOLTIP,
        NK_PANEL_SET_POPUP = NK_PANEL_SET_NONBLOCK | nk_panel_type.NK_PANEL_POPUP,
        NK_PANEL_SET_SUB = NK_PANEL_SET_POPUP | nk_panel_type.NK_PANEL_GROUP
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_chart_slot
    {
        internal nk_chart_type type;
        internal NkColor color;
        internal NkColor highlight;
        internal float min;
        internal float max;
        internal float range;
        internal int count;
        internal nk_vec2 last;
        internal int index;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_chart
    {
        internal int slot;
        internal float x;
        internal float y;
        internal float w;
        internal float h;
        internal nk_chart_slot slot0;
        internal nk_chart_slot slot1;
        internal nk_chart_slot slot2;
        internal nk_chart_slot slot3;
    }

    internal enum nk_panel_row_layout_type
    {
        NK_LAYOUT_DYNAMIC_FIXED = 0,
        NK_LAYOUT_DYNAMIC_ROW,
        NK_LAYOUT_DYNAMIC_FREE,
        NK_LAYOUT_DYNAMIC,
        NK_LAYOUT_STATIC_FIXED,
        NK_LAYOUT_STATIC_ROW,
        NK_LAYOUT_STATIC_FREE,
        NK_LAYOUT_STATIC,
        NK_LAYOUT_TEMPLATE,
        NK_LAYOUT_COUNT
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_row_layout
    {
        internal nk_panel_row_layout_type type;
        internal int index;
        internal float height;
        internal float min_height;
        internal int columns;
        internal float* ratio;
        internal float item_width;
        internal float item_height;
        internal float item_offset;
        internal float filled;
        internal NkRect item;
        internal int tree_depth;
        internal fixed float templates[16];
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_popup_buffer
    {
        internal IntPtr begin_nksize;
        internal IntPtr parent_nksize;
        internal IntPtr last_nksize;
        internal IntPtr end_nksize;
        internal int active;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_menu_state
    {
        internal float x;
        internal float y;
        internal float w;
        internal float h;
        internal nk_scroll offset;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_panel
    {
        internal nk_panel_type type;
        internal uint flags_nkflags;
        internal NkRect bounds;
        internal uint* offset_x;
        internal uint* offset_y;
        internal float at_x;
        internal float at_y;
        internal float max_x;
        internal float footer_height;
        internal float header_height;
        internal float border;
        internal uint has_scrolling;
        internal NkRect clip;
        internal nk_menu_state menu;
        internal nk_row_layout row;
        internal nk_chart chart;
        internal nk_command_buffer* buffer;
        internal nk_panel* parent;
    }

    [Flags]
    internal enum nk_window_flags : uint
    {
        NK_WINDOW_PRIVATE = (1 << (11)),
        NK_WINDOW_DYNAMIC = NK_WINDOW_PRIVATE,
        NK_WINDOW_ROM = (1 << (12)),
        NK_WINDOW_NOT_INTERACTIVE = NK_WINDOW_ROM | NkPanelFlags.NoInput,
        NK_WINDOW_HIDDEN = (1 << (13)),
        NK_WINDOW_CLOSED = (1 << (14)),
        NK_WINDOW_MINIMIZED = (1 << (15)),
        NK_WINDOW_REMOVE_ROM = (1 << (16))
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_popup_state
    {
        internal nk_window* win;
        internal nk_panel_type type;
        internal nk_popup_buffer buf;
        internal uint name_nkhash;
        internal int active;
        internal uint combo_count;
        internal uint con_count;
        internal uint con_old;
        internal uint active_con;
        internal NkRect header;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_edit_state
    {
        internal uint name_nkhash;
        internal uint seq;
        internal uint old;
        internal int active;
        internal int prev;
        internal int cursor;
        internal int sel_start;
        internal int sel_end;
        internal nk_scroll scrollbar;
        internal byte mode;
        internal byte single_line;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_property_state
    {
        internal int active;
        internal int prev;
        internal fixed byte buffer[64];
        internal int length;
        internal int cursor;
        internal int select_start;
        internal int select_end;
        internal uint name_nkhash;
        internal uint seq;
        internal uint old;
        internal int state;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_window
    {
        internal uint seq;
        internal uint name_nkhash;
        internal fixed byte name_string[64];
        internal uint flags_nkflags;

        internal NkRect bounds;
        internal nk_scroll scrollbar;
        internal nk_command_buffer buffer;
        internal nk_panel* layout;
        internal float scrollbar_hiding_timer;

        internal nk_property_state property;
        internal nk_popup_state popup;
        internal nk_edit_state edit;
        internal uint scrolled;

        internal nk_table* tables;
        internal uint table_count;

        internal nk_window* next;
        internal nk_window* prev;
        internal nk_window* parent;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_list_view
    {
        internal int begin;
        internal int end;
        internal int count;

        internal int total_height;
        internal nk_context* ctx;
        internal uint* scroll_pointer;
        internal uint scroll_value;
    }

    internal enum nk_widget_layout_states
    {
        NK_WIDGET_INVALID,
        NK_WIDGET_VALID,
        NK_WIDGET_ROM
    }

    [Flags]
    internal enum nk_widget_states
    {
        NK_WIDGET_STATE_MODIFIED = (1 << (1)),
        NK_WIDGET_STATE_INACTIVE = (1 << (2)),
        NK_WIDGET_STATE_ENTERED = (1 << (3)),
        NK_WIDGET_STATE_HOVER = (1 << (4)),
        NK_WIDGET_STATE_ACTIVED = (1 << (5)),
        NK_WIDGET_STATE_LEFT = (1 << (6)),
        NK_WIDGET_STATE_HOVERED = NK_WIDGET_STATE_HOVER | NK_WIDGET_STATE_MODIFIED,
        NK_WIDGET_STATE_ACTIVE = NK_WIDGET_STATE_ACTIVED | NK_WIDGET_STATE_MODIFIED
    }

    [Flags]
    internal enum NkTextAlign
    {
        NK_TEXT_ALIGN_LEFT = 0x01,
        NK_TEXT_ALIGN_CENTERED = 0x02,
        NK_TEXT_ALIGN_RIGHT = 0x04,
        NK_TEXT_ALIGN_TOP = 0x08,
        NK_TEXT_ALIGN_MIDDLE = 0x10,
        NK_TEXT_ALIGN_BOTTOM = 0x20
    }

    internal enum NkTextAlignment
    {
        NK_TEXT_LEFT = NkTextAlign.NK_TEXT_ALIGN_MIDDLE | NkTextAlign.NK_TEXT_ALIGN_LEFT,
        NK_TEXT_CENTERED = NkTextAlign.NK_TEXT_ALIGN_MIDDLE | NkTextAlign.NK_TEXT_ALIGN_CENTERED,
        NK_TEXT_RIGHT = NkTextAlign.NK_TEXT_ALIGN_MIDDLE | NkTextAlign.NK_TEXT_ALIGN_RIGHT
    }

    [Flags]
    internal enum NkEditFlags
    {
        // nk_edit_flags
        Default = 0,
        ReadOnly = (1 << (0)),
        AutoSelect = (1 << (1)),
        SigEnter = (1 << (2)),
        AllowTab = (1 << (3)),
        NoCursor = (1 << (4)),
        Selectable = (1 << (5)),
        Clipboard = (1 << (6)),
        CtrlEnterNewLine = (1 << (7)),
        NoHorizontalScroll = (1 << (8)),
        AlwaysInsertMode = (1 << (9)),
        Multiline = (1 << (10)),
        GotoEndOnActivate = (1 << (11))
    }

    internal enum NkEditTypes
    {
        // nk_edit_types
        Simple = NkEditFlags.AlwaysInsertMode,
        Field = Simple | NkEditFlags.Selectable | NkEditFlags.Clipboard,

        Box = NkEditFlags.AlwaysInsertMode | NkEditFlags.Selectable | NkEditFlags.Multiline | NkEditFlags.AllowTab |
              NkEditFlags.Clipboard,
        Editor = NkEditFlags.Selectable | NkEditFlags.Multiline | NkEditFlags.AllowTab | NkEditFlags.Clipboard,

        ReadOnlyEditor = NkEditFlags.Selectable | NkEditFlags.Multiline | NkEditFlags.AllowTab | NkEditFlags.Clipboard |
                         NkEditFlags.ReadOnly
    }

    [Flags]
    internal enum NkEditEvents
    {
        Active = (1 << (0)),
        Inactive = (1 << (1)),
        Activated = (1 << (2)),
        Deactivated = (1 << (3)),
        Commited = (1 << (4))
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate float nk_value_getter_fun(IntPtr user, int index);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal unsafe delegate void nk_item_getter_fun(IntPtr user, int i, byte** idk);

    // [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
    internal static unsafe partial class LibNuklear
    {
        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_window* nk_window_find(nk_context* ctx, byte* name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_window_get_bounds(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_window_get_position(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_window_get_size(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern float nk_window_get_width(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern float nk_window_get_height(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_panel* nk_window_get_panel(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_window_get_content_region(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_window_get_content_region_min(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_window_get_content_region_max(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_window_get_content_region_size(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_command_buffer* nk_window_get_canvas(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_has_focus(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_collapsed(nk_context* ctx, byte* name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_collapsed(nk_context* ctx, string name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_closed(nk_context* ctx, byte* name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_closed(nk_context* ctx, string name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_hidden(nk_context* ctx, byte* name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_hidden(nk_context* ctx, string name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_active(nk_context* ctx, byte* name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_hovered(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_window_is_any_hovered(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_item_is_any_active(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_set_bounds(nk_context* ctx, byte* name, NkRect bounds);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_set_position(nk_context* ctx, byte* name, nk_vec2 pos);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_set_size(nk_context* ctx, byte* name, nk_vec2 sz);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_set_focus(nk_context* ctx, byte* name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_close(nk_context* ctx, byte* name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_close(nk_context* ctx, string name);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_collapse(nk_context* ctx, byte* name, nk_collapse_states state);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_collapse_if(nk_context* ctx, byte* name, nk_collapse_states state,
            int cond);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_show(nk_context* ctx, byte* name, nk_show_states state);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_window_show_if(nk_context* ctx, byte* name, nk_show_states state, int cond);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_group_begin(nk_context* ctx, byte* title, uint nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_group_begin(nk_context* ctx, string title, uint nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_group_begin_titled(nk_context* ctx, byte* id, byte* title, uint nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_group_begin_titled(nk_context* ctx, string id, string title, uint nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_group_scrolled_offset_begin(nk_context* ctx, uint* x_offset, uint* y_offset,
            byte* s, uint nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_group_scrolled_begin(nk_context* ctx, nk_scroll* scroll, byte* title,
            uint nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_group_scrolled_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_group_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_list_view_begin(nk_context* ctx, nk_list_view* nlv_out, byte* id, uint nkflags,
            int row_height, int row_count);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_list_view_end(nk_list_view* nlv);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_tree_push_hashed(nk_context* ctx, nk_tree_type tree_type, byte* title,
            nk_collapse_states initial_state, byte* hash, int len, int seed);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_tree_image_push_hashed(nk_context* ctx, nk_tree_type tree_type, nk_image img,
            byte* title, nk_collapse_states initial_state, byte* hash, int len, int seed);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_tree_pop(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_tree_state_push(nk_context* ctx, nk_tree_type tree_type, byte* title,
            nk_collapse_states* state);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_tree_state_image_push(nk_context* ctx, nk_tree_type tree_type, nk_image img,
            byte* title, nk_collapse_states* state);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_tree_state_pop(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_widget_layout_states nk_widget(NkRect* r, nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_widget_layout_states nk_widget_fitting(NkRect* r, nk_context* ctx, nk_vec2 v);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_widget_bounds(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_widget_position(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_widget_size(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern float nk_widget_width(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern float nk_widget_height(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_widget_is_hovered(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_widget_is_mouse_clicked(nk_context* ctx, nk_buttons buttons);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_widget_has_mouse_click_down(nk_context* ctx, nk_buttons buttons, int down);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_spacing(nk_context* ctx, int cols);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_text(nk_context* ctx, byte* s, int i, uint flags_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_text_colored(nk_context* ctx, byte* s, int i, uint flags_nkflags, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_text_wrap(nk_context* ctx, byte* s, int i);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_text_wrap_colored(nk_context* ctx, byte* s, int i, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label(nk_context* ctx, byte* s, uint align_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label(nk_context* ctx, string s, uint align_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label_colored(nk_context* ctx, byte* s, uint align_nkflags, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label_colored(nk_context* ctx, string s, uint align_nkflags, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label_wrap(nk_context* ctx, byte* s);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label_wrap(nk_context* ctx, string s);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label_colored_wrap(nk_context* ctx, byte* s, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_label_colored_wrap(nk_context* ctx, string s, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_image(nk_context* ctx, nk_image img);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_text(nk_context* ctx, byte* title, int len);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_text(nk_context* ctx, string title, int len);

        internal static bool nk_button_text(nk_context* ctx, string title) =>
            nk_button_text(ctx, title, title.Length) != 0;

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_label(nk_context* ctx, byte* title);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_label(nk_context* ctx, string title);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_color(nk_context* ctx, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_symbol(nk_context* ctx, nk_symbol_type symtype);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_image(nk_context* ctx, nk_image img);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s,
            uint text_alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int i,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_image_label(nk_context* ctx, nk_image img, byte* s,
            uint text_alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_image_text(nk_context* ctx, nk_image img, byte* s, int i,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int
            nk_button_text_styled(nk_context* ctx, nk_style_button* bstyle, byte* title, int len);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_label_styled(nk_context* ctx, nk_style_button* bstyle, byte* title);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_symbol_styled(nk_context* ctx, nk_style_button* bstyle,
            nk_symbol_type stype);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_image_styled(nk_context* ctx, nk_style_button* bstyle, nk_image img);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_symbol_text_styled(nk_context* ctx, nk_style_button* bstyle,
            nk_symbol_type stype, byte* s, int i, uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_symbol_label_styled(nk_context* ctx, nk_style_button* bstyle,
            nk_symbol_type stype, byte* title, uint align_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_image_label_styled(nk_context* ctx, nk_style_button* bstyle, nk_image img,
            byte* s, uint text_alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_image_text_styled(nk_context* ctx, nk_style_button* bstyle, nk_image img,
            byte* s, int i, uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_button_set_behavior(nk_context* ctx, nk_button_behavior behavior);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_push_behavior(nk_context* ctx, nk_button_behavior behavior);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_button_pop_behavior(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_check_label(nk_context* ctx, byte* s, int active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_check_text(nk_context* ctx, byte* s, int i, int active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_check_flags_label(nk_context* ctx, byte* s, uint flags, uint val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_check_flags_text(nk_context* ctx, byte* s, int i, uint flags, uint val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_checkbox_label(nk_context* ctx, byte* s, int* active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_checkbox_text(nk_context* ctx, byte* s, int i, int* active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_checkbox_flags_label(nk_context* ctx, byte* s, uint* flags, uint val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_checkbox_flags_text(nk_context* ctx, byte* s, int i, uint* flags, uint val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_radio_label(nk_context* ctx, byte* s, int* active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_radio_text(nk_context* ctx, byte* s, int i, int* active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_option_label(nk_context* ctx, byte* s, int active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_option_text(nk_context* ctx, byte* s, int i, int active);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_selectable_label(nk_context* ctx, byte* s, uint align_nkflags, int* val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_selectable_text(nk_context* ctx, byte* s, int i, uint align_nkflags, int* val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_selectable_image_label(nk_context* ctx, nk_image img, byte* s, uint align_nkflags,
            int* val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_selectable_image_text(nk_context* ctx, nk_image img, byte* s, int i,
            uint align_nkflags, int* val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_select_label(nk_context* ctx, byte* s, uint align_nkflags, int val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_select_text(nk_context* ctx, byte* s, int i, uint align_nkflags, int val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_select_image_label(nk_context* ctx, nk_image img, byte* s, uint align_nkflags,
            int val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_select_image_text(nk_context* ctx, nk_image img, byte* s, int i,
            uint align_nkflags, int val);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern float nk_slide_float(nk_context* ctx, float min, float val, float max, float step);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_slide_int(nk_context* ctx, int min, int val, int max, int step);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_slider_float(nk_context* ctx, float min, float* val, float max, float step);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_slider_int(nk_context* ctx, int min, int* val, int max, int step);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_progress(nk_context* ctx, IntPtr* cur_nksize, IntPtr max_nksize, int modifyable);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern IntPtr nk_prog(nk_context* ctx, IntPtr cur_nksize, IntPtr max_nksize, int modifyable);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_colorf nk_color_picker(nk_context* ctx, nk_colorf color, nk_color_format cfmt);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_color_pick(nk_context* ctx, nk_colorf* color, nk_color_format cfmt);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_property_int(nk_context* ctx, byte* name, int min, int* val, int max, int step,
            float inc_per_pixel);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_property_float(nk_context* ctx, byte* name, float min, float* val, float max,
            float step, float inc_per_pixel);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_property_double(nk_context* ctx, byte* name, double min, double* val, double max,
            double step, float inc_per_pixel);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_propertyi(nk_context* ctx, byte* name, int min, int val, int max, int step,
            float inc_per_pixel);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern float nk_propertyf(nk_context* ctx, byte* name, float min, float val, float max,
            float step, float inc_per_pixel);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern double nk_propertyd(nk_context* ctx, byte* name, double min, double val, double max,
            double step, float inc_per_pixel);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_edit_string(nk_context* ctx, uint flags_nkflags, byte* buffer, int* len, int max,
            nk_plugin_filter_t filterfun);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_edit_string(nk_context* ctx, uint flags_nkflags, StringBuilder buffer, int* len,
            int max, nk_plugin_filter_t filterfun);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_edit_string_zero_terminated(nk_context* ctx, uint flags_nkflags, byte* buffer,
            int max, nk_plugin_filter_t filterfun);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_edit_string_zero_terminated(nk_context* ctx, uint flags_nkflags,
            StringBuilder buffer, int max, nk_plugin_filter_t filterfun);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_edit_buffer(nk_context* ctx, uint flags_nkflags, nk_text_edit* textedit,
            nk_plugin_filter_t filterfun);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_edit_focus(nk_context* ctx, uint flags_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_edit_unfocus(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_chart_begin(nk_context* ctx, nk_chart_type chatype, int num, float min,
            float max);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_chart_begin_colored(nk_context* ctx, nk_chart_type chatype, NkColor color,
            NkColor active, int num, float min, float max);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_chart_add_slot(nk_context* ctx, nk_chart_type chatype, int count,
            float min_value, float max_value);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_chart_add_slot_colored(nk_context* ctx, nk_chart_type chatype, NkColor color,
            NkColor active, int count, float min_value, float max_value);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_chart_push(nk_context* ctx, float f);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_chart_push_slot(nk_context* ctx, float f, int i);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_chart_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_plot(nk_context* ctx, nk_chart_type chatype, float* values, int count,
            int offset);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_plot_function(nk_context* ctx, nk_chart_type chatype, IntPtr userdata,
            nk_value_getter_fun getterfun, int count, int offset);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_popup_begin(nk_context* ctx, nk_popup_type type, byte* s, uint flags_nkflags,
            NkRect bounds);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_popup_close(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_popup_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo(nk_context* ctx, byte** items, int count, int selected, int item_height,
            nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_separator(nk_context* ctx, byte* items_separated_by_separator,
            int separator, int selected, int count, int item_height, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_string(nk_context* ctx, byte* items_separated_by_zeros, int selected,
            int count, int item_height, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_callback(nk_context* ctx, nk_item_getter_fun getterfun, IntPtr userdata,
            int selected, int count, int item_height, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_combobox(nk_context* ctx, byte** items, int count, int* selected,
            int item_height, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_combobox_string(nk_context* ctx, byte* items_separated_by_zeros, int* selected,
            int count, int item_height, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_combobox_separator(nk_context* ctx, byte* items_separated_by_separator,
            int separator, int* selected, int count, int item_height, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_combobox_callback(nk_context* ctx, nk_item_getter_fun getterfun, IntPtr userdata,
            int* selected, int count, int item_height, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_text(nk_context* ctx, char* selected, int i, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_label(nk_context* ctx, char* selected, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_color(nk_context* ctx, NkColor color, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_symbol(nk_context* ctx, nk_symbol_type stype, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_symbol_label(nk_context* ctx, char* selected, nk_symbol_type stype,
            nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_symbol_text(nk_context* ctx, char* selected, int i,
            nk_symbol_type stype, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_image(nk_context* ctx, nk_image img, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_image_label(nk_context* ctx, char* selected, nk_image img,
            nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_begin_image_text(nk_context* ctx, char* selected, int i, nk_image img,
            nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_item_label(nk_context* ctx, byte* s, uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_item_text(nk_context* ctx, byte* s, int i, uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_item_image_label(nk_context* ctx, nk_image img, byte* s,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_item_image_text(nk_context* ctx, nk_image img, byte* s, int i,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_item_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_combo_item_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int i,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_combo_close(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_combo_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_contextual_begin(nk_context* ctx, uint flags_nkflags, nk_vec2 v,
            NkRect trigger_bounds);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_contextual_item_text(nk_context* ctx, byte* s, int i, uint align_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_contextual_item_label(nk_context* ctx, byte* s, uint align_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_contextual_item_image_label(nk_context* ctx, nk_image img, byte* s,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_contextual_item_image_text(nk_context* ctx, nk_image img, byte* s, int len,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_contextual_item_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_contextual_item_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int i,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_contextual_close(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_contextual_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_tooltip(nk_context* ctx, byte* s);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_tooltip_begin(nk_context* ctx, float width);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_tooltip_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_menubar_begin(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_menubar_end(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_text(nk_context* ctx, byte* title, int title_len, uint align_nkflags,
            nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_label(nk_context* ctx, byte* s, uint align_nkflags, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_image(nk_context* ctx, byte* s, nk_image img, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_image_text(nk_context* ctx, byte* s, int slen, uint align_nkflags,
            nk_image img, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_image_label(nk_context* ctx, byte* s, uint align_nkflags, nk_image img,
            nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_symbol(nk_context* ctx, byte* s, nk_symbol_type stype, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_symbol_text(nk_context* ctx, byte* s, int slen, uint align_nkflags,
            nk_symbol_type stype, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_begin_symbol_label(nk_context* ctx, byte* s, uint align_nkflags,
            nk_symbol_type stype, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_item_text(nk_context* ctx, byte* s, int slen, uint align_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_item_label(nk_context* ctx, byte* s, uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_item_image_label(nk_context* ctx, nk_image img, byte* s,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_item_image_text(nk_context* ctx, nk_image img, byte* s, int slen,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_item_symbol_text(nk_context* ctx, nk_symbol_type stype, byte* s, int slen,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_menu_item_symbol_label(nk_context* ctx, nk_symbol_type stype, byte* s,
            uint alignment_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_menu_close(nk_context* ctx);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_menu_end(nk_context* ctx);
    }
}