using System;
using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet {
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate IntPtr nk_plugin_alloc_t(NkHandle handle, IntPtr old, IntPtr nk_size);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void nk_plugin_free_t(NkHandle handle, IntPtr old);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate int nk_plugin_filter_t(ref nk_text_edit edit, uint unicode_rune);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void nk_plugin_paste_t(NkHandle handle, ref nk_text_edit edit);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void nk_plugin_copy_t(NkHandle handle, byte* str, int len);

	/* ... */

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_allocator {
		internal NkHandle userdata;
		// nk_plugin_alloc_t alloc;
		internal IntPtr alloc_nkpluginalloct;
		// nk_plugin_free_t free;
		internal IntPtr free_nkpluginfreet;
	}

	internal enum nk_symbol_type {
		NK_SYMBOL_NONE,
		NK_SYMBOL_X,
		NK_SYMBOL_UNDERSCORE,
		NK_SYMBOL_CIRCLE_SOLID,
		NK_SYMBOL_CIRCLE_OUTLINE,
		NK_SYMBOL_RECT_SOLID,
		NK_SYMBOL_RECT_OUTLINE,
		NK_SYMBOL_TRIANGLE_UP,
		NK_SYMBOL_TRIANGLE_DOWN,
		NK_SYMBOL_TRIANGLE_LEFT,
		NK_SYMBOL_TRIANGLE_RIGHT,
		NK_SYMBOL_PLUS,
		NK_SYMBOL_MINUS,
		NK_SYMBOL_MAX
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_memory_status {
		internal IntPtr memory;
		internal uint type;
		internal IntPtr size;
		internal IntPtr allocated;
		internal IntPtr needed;
		internal IntPtr calls;
	}

	internal enum nk_allocation_type : int {
		NK_BUFFER_FIXED,
		NK_BUFFER_DYNAMIC
	}

	internal enum nk_buffer_allocation_type : int {
		NK_BUFFER_FRONT,
		NK_BUFFER_BACK,
		NK_BUFFER_MAX
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_buffer_marker {
		internal int active;
		internal IntPtr offset_nksize;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_memory {
		internal IntPtr ptr;
		internal IntPtr size;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_buffer {
		internal nk_buffer_marker marker0;
		internal nk_buffer_marker marker1;
		internal nk_allocator pool;
		internal nk_allocation_type allocation_type;
		internal nk_memory memory;
		internal float grow_factor;
		internal IntPtr allocated;
		internal IntPtr needed;
		internal IntPtr calls;
		internal IntPtr size;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_style_item_element {
		internal nk_style_item* address;
		internal nk_style_item old_value;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_float_element {
		internal float* address;
		internal float old_value;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_vec2_element {
		internal nk_vec2* address;
		internal nk_vec2 old_value;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_flags_element {
		internal uint* address_nkflags;
		internal uint old_value_nkflags;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_color_element {
		internal NkColor* address;
		internal NkColor old_value;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_user_font_element {
		internal nk_user_font* address;
		internal nk_user_font* old_value;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_button_behavior_element {
		internal nk_button_behavior* address;
		internal nk_button_behavior old_value;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_style_item {
		internal int head;
		internal nk_config_stack_style_item_element element0;
		internal nk_config_stack_style_item_element element1;
		internal nk_config_stack_style_item_element element2;
		internal nk_config_stack_style_item_element element3;
		internal nk_config_stack_style_item_element element4;
		internal nk_config_stack_style_item_element element5;
		internal nk_config_stack_style_item_element element6;
		internal nk_config_stack_style_item_element element7;
		internal nk_config_stack_style_item_element element8;
		internal nk_config_stack_style_item_element element9;
		internal nk_config_stack_style_item_element element10;
		internal nk_config_stack_style_item_element element11;
		internal nk_config_stack_style_item_element element12;
		internal nk_config_stack_style_item_element element13;
		internal nk_config_stack_style_item_element element14;
		internal nk_config_stack_style_item_element element15;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_float {
		internal int head;
		internal nk_config_stack_float_element element0;
		internal nk_config_stack_float_element element1;
		internal nk_config_stack_float_element element2;
		internal nk_config_stack_float_element element3;
		internal nk_config_stack_float_element element4;
		internal nk_config_stack_float_element element5;
		internal nk_config_stack_float_element element6;
		internal nk_config_stack_float_element element7;
		internal nk_config_stack_float_element element8;
		internal nk_config_stack_float_element element9;
		internal nk_config_stack_float_element element10;
		internal nk_config_stack_float_element element11;
		internal nk_config_stack_float_element element12;
		internal nk_config_stack_float_element element13;
		internal nk_config_stack_float_element element14;
		internal nk_config_stack_float_element element15;
		internal nk_config_stack_float_element element16;
		internal nk_config_stack_float_element element17;
		internal nk_config_stack_float_element element18;
		internal nk_config_stack_float_element element19;
		internal nk_config_stack_float_element element20;
		internal nk_config_stack_float_element element21;
		internal nk_config_stack_float_element element22;
		internal nk_config_stack_float_element element23;
		internal nk_config_stack_float_element element24;
		internal nk_config_stack_float_element element25;
		internal nk_config_stack_float_element element26;
		internal nk_config_stack_float_element element27;
		internal nk_config_stack_float_element element28;
		internal nk_config_stack_float_element element29;
		internal nk_config_stack_float_element element30;
		internal nk_config_stack_float_element element31;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_vec2 {
		internal int head;
		internal nk_config_stack_vec2_element element0;
		internal nk_config_stack_vec2_element element1;
		internal nk_config_stack_vec2_element element2;
		internal nk_config_stack_vec2_element element3;
		internal nk_config_stack_vec2_element element4;
		internal nk_config_stack_vec2_element element5;
		internal nk_config_stack_vec2_element element6;
		internal nk_config_stack_vec2_element element7;
		internal nk_config_stack_vec2_element element8;
		internal nk_config_stack_vec2_element element9;
		internal nk_config_stack_vec2_element element10;
		internal nk_config_stack_vec2_element element11;
		internal nk_config_stack_vec2_element element12;
		internal nk_config_stack_vec2_element element13;
		internal nk_config_stack_vec2_element element14;
		internal nk_config_stack_vec2_element element15;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_flags {
		internal int head;
		internal nk_config_stack_flags_element element0;
		internal nk_config_stack_flags_element element1;
		internal nk_config_stack_flags_element element2;
		internal nk_config_stack_flags_element element3;
		internal nk_config_stack_flags_element element4;
		internal nk_config_stack_flags_element element5;
		internal nk_config_stack_flags_element element6;
		internal nk_config_stack_flags_element element7;
		internal nk_config_stack_flags_element element8;
		internal nk_config_stack_flags_element element9;
		internal nk_config_stack_flags_element element10;
		internal nk_config_stack_flags_element element11;
		internal nk_config_stack_flags_element element12;
		internal nk_config_stack_flags_element element13;
		internal nk_config_stack_flags_element element14;
		internal nk_config_stack_flags_element element15;
		internal nk_config_stack_flags_element element16;
		internal nk_config_stack_flags_element element17;
		internal nk_config_stack_flags_element element18;
		internal nk_config_stack_flags_element element19;
		internal nk_config_stack_flags_element element20;
		internal nk_config_stack_flags_element element21;
		internal nk_config_stack_flags_element element22;
		internal nk_config_stack_flags_element element23;
		internal nk_config_stack_flags_element element24;
		internal nk_config_stack_flags_element element25;
		internal nk_config_stack_flags_element element26;
		internal nk_config_stack_flags_element element27;
		internal nk_config_stack_flags_element element28;
		internal nk_config_stack_flags_element element29;
		internal nk_config_stack_flags_element element30;
		internal nk_config_stack_flags_element element31;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_color {
		internal int head;
		internal nk_config_stack_color_element element0;
		internal nk_config_stack_color_element element1;
		internal nk_config_stack_color_element element2;
		internal nk_config_stack_color_element element3;
		internal nk_config_stack_color_element element4;
		internal nk_config_stack_color_element element5;
		internal nk_config_stack_color_element element6;
		internal nk_config_stack_color_element element7;
		internal nk_config_stack_color_element element8;
		internal nk_config_stack_color_element element9;
		internal nk_config_stack_color_element element10;
		internal nk_config_stack_color_element element11;
		internal nk_config_stack_color_element element12;
		internal nk_config_stack_color_element element13;
		internal nk_config_stack_color_element element14;
		internal nk_config_stack_color_element element15;
		internal nk_config_stack_color_element element16;
		internal nk_config_stack_color_element element17;
		internal nk_config_stack_color_element element18;
		internal nk_config_stack_color_element element19;
		internal nk_config_stack_color_element element20;
		internal nk_config_stack_color_element element21;
		internal nk_config_stack_color_element element22;
		internal nk_config_stack_color_element element23;
		internal nk_config_stack_color_element element24;
		internal nk_config_stack_color_element element25;
		internal nk_config_stack_color_element element26;
		internal nk_config_stack_color_element element27;
		internal nk_config_stack_color_element element28;
		internal nk_config_stack_color_element element29;
		internal nk_config_stack_color_element element30;
		internal nk_config_stack_color_element element31;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_user_font {
		internal int head;
		internal nk_config_stack_user_font_element element0;
		internal nk_config_stack_user_font_element element1;
		internal nk_config_stack_user_font_element element2;
		internal nk_config_stack_user_font_element element3;
		internal nk_config_stack_user_font_element element4;
		internal nk_config_stack_user_font_element element5;
		internal nk_config_stack_user_font_element element6;
		internal nk_config_stack_user_font_element element7;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_config_stack_button_behavior {
		internal int head;
		internal nk_config_stack_button_behavior_element element0;
		internal nk_config_stack_button_behavior_element element1;
		internal nk_config_stack_button_behavior_element element2;
		internal nk_config_stack_button_behavior_element element3;
		internal nk_config_stack_button_behavior_element element4;
		internal nk_config_stack_button_behavior_element element5;
		internal nk_config_stack_button_behavior_element element6;
		internal nk_config_stack_button_behavior_element element7;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_configuration_stacks {
		internal nk_config_stack_style_item style_items;
		internal nk_config_stack_float floats;
		internal nk_config_stack_vec2 vectors;
		internal nk_config_stack_flags flags;
		internal nk_config_stack_color colors;
		internal nk_config_stack_user_font fonts;
		internal nk_config_stack_button_behavior button_behaviors;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_table {
		internal uint seq;
		internal uint size;
		// nk_hash keys[(((((sizeof(struct nk_window)) < (sizeof(struct nk_panel)) ? (sizeof(struct nk_panel)) : (sizeof(struct nk_window))) / sizeof(nk_uint))) / 2)];
		// nk_window: c# size 472, C size 472
		// nk_panel: c# size 448, C size 448
		// => nk_hash keys[(((472 < 448 ? 448 : 472) / 4) / 2)]
		// => nk_hash keys[((472 / 4) / 2)]
		// => nk_hash keys[472 / 8]
		internal fixed uint keys_nkhash[472 / 8];
		// nk_uint values[(((((sizeof(struct nk_window)) < (sizeof(struct nk_panel)) ? (sizeof(struct nk_panel)) : (sizeof(struct nk_window))) / sizeof(nk_uint))) / 2)];
		internal fixed uint values[472 / 8];
		internal nk_table* next;
		internal nk_table* prev;
	}

	[StructLayout(LayoutKind.Explicit)]
	internal unsafe struct nk_page_data {
		[FieldOffset(0)]
		internal nk_panel pan;
		[FieldOffset(0)]
		internal nk_window win;
		[FieldOffset(0)]
		internal nk_table tbl;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_page_element {
		internal nk_page_data data;
		internal nk_page_element* next;
		internal nk_page_element* prev;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_page {
		internal uint size;
		internal nk_page* next;
		internal nk_page_element win0;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_pool {
		internal nk_allocator alloc;
		internal nk_allocation_type type;
		internal uint page_count;
		internal nk_page* pages;
		internal nk_page_element* freelist;
		internal uint capacity;
		internal IntPtr size_nksize;
		internal IntPtr cap_nksize;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_context {
		internal nk_input input;
		internal nk_style style;
		internal nk_buffer memory;
		internal nk_clipboard clip;
		internal uint last_widget_state_nkflags;
		internal nk_button_behavior button_behavior;
		internal nk_configuration_stacks stacks;
		internal float delta_time_Seconds;

		internal nk_draw_list draw_list;

		internal NkHandle userdata;

		internal nk_text_edit text_edit;

		internal nk_command_buffer overlay;

		internal int build;
		internal int use_pool;
		internal nk_pool pool;
		internal nk_window* begin;
		internal nk_window* end;
		internal nk_window* active;
		internal nk_window* current;
		internal nk_page_element* freelist;
		internal uint count;
		internal uint seq;
	}

	internal static unsafe partial class LibNuklear {
		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_init_fixed(nk_context* context, IntPtr memory, IntPtr size, nk_user_font* userfont);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_init(nk_context* context, nk_allocator* allocator, nk_user_font* userfont);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_init_custom(nk_context* context, nk_buffer* cmds, nk_buffer* pool, nk_user_font* userfont);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_clear(nk_context* context);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_set_user_data(nk_context* context, NkHandle handle);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_init(nk_buffer* buffer, nk_allocator* allocator, IntPtr size);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_init_fixed(nk_buffer* buffer, IntPtr memory, IntPtr size);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_info(nk_memory_status* status, nk_buffer* buffer);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_push(nk_buffer* buffer, nk_buffer_allocation_type atype, IntPtr memory, IntPtr size, IntPtr align);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_mark(nk_buffer* buffer, nk_buffer_allocation_type atype);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_reset(nk_buffer* buffer, nk_buffer_allocation_type atype);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_clear(nk_buffer* buffer);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_buffer_free(nk_buffer* buffer);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern IntPtr nk_buffer_memory(nk_buffer* buffer);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern IntPtr nk_buffer_memory_const(nk_buffer* buffer);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern IntPtr nk_buffer_total(nk_buffer* buffer);

	}
}
