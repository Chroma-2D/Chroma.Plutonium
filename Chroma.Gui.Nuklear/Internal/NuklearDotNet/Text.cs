using System;
using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet {
	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_str {
		internal nk_buffer buffer;
		internal int len;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_clipboard {
		internal NkHandle userdata;
		internal IntPtr pastefun_nkPluginPasteT;
		internal IntPtr copyfun_nkPluginCopyT;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_text_undo_record {
		internal int iwhere;
		internal short insert_length;
		internal short delete_length;
		internal short char_storage;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_text_undo_state {
		// fixed nk_text_undo_record undo_rec[99];
		internal fixed short undo_rec_nkTextUndoRecord[99 * 6]; // ...?
		internal fixed uint undo_char[999];
		internal short undo_point;
		internal short redo_point;
		internal short undo_char_point;
		internal short redo_char_point;
	}

	internal enum nk_text_edit_type {
		NK_TEXT_EDIT_SINGLE_LINE,
		NK_TEXT_EDIT_MULTI_LINE
	}

	internal enum nk_text_edit_mode {
		NK_TEXT_EDIT_MODE_VIEW,
		NK_TEXT_EDIT_MODE_INSERT,
		NK_TEXT_EDIT_MODE_REPLACE
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_text_edit {
		internal nk_clipboard clip;
		internal nk_str str;
		internal IntPtr filter_nkPluginFilterT;
		internal nk_vec2 scrollbar;

		internal int cursor;
		internal int select_start;
		internal int select_end;
		internal byte mode;
		internal byte cursor_at_end_of_line;
		internal byte initialized;
		internal byte has_preferred_x;
		internal byte single_line;
		internal byte active;
		internal byte padding1;
		internal float preferred_x;
		internal nk_text_undo_state undo;
	}

	// [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
	internal static unsafe partial class LibNuklear {
		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_init(nk_str* str, nk_allocator* allocator, IntPtr size);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_init_fixed(nk_str* str, IntPtr memory, IntPtr size);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_clear(nk_str* str);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_free(nk_str* str);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_append_text_char(nk_str* str, byte* s, int slen);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_append_str_char(nk_str* str, byte* s);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_append_text_utf8(nk_str* str, byte* s, int slen);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_append_str_utf8(nk_str* str, byte* s);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_append_text_runes(nk_str* str, uint* runes, int len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_append_str_runes(nk_str* str, uint* runes);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_at_char(nk_str* str, int pos, byte* s, int slen);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_at_rune(nk_str* str, int pos, byte* s, int slen);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_text_char(nk_str* str, int pos, byte* s, int slen);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_str_char(nk_str* str, int pos, byte* s);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_text_utf8(nk_str* str, int pos, byte* s, int slen);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_str_utf8(nk_str* str, int pos, byte* s);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_text_runes(nk_str* str, int pos, uint* runes, int slen);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_insert_str_runes(nk_str* str, int pos, uint* runes);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_remove_chars(nk_str* str, int len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_remove_runes(nk_str* str, int len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_delete_chars(nk_str* str, int pos, int len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_str_delete_runes(nk_str* str, int pos, int len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern byte* nk_str_at_char(nk_str* str, int pos);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern byte* nk_str_at_rune(nk_str* str, int pos, uint* unicode, int* len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern uint nk_str_rune_at(nk_str* str, int pos);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern char* nk_str_at_char_const(nk_str* str, int pos);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern char* nk_str_at_const(nk_str* str, int pos, uint* unicode, int* len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern char* nk_str_get(nk_str* str);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern char* nk_str_get_const(nk_str* str);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_len(nk_str* str);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_str_len_char(nk_str* str);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_filter_default(nk_text_edit* te, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_filter_ascii(nk_text_edit* te, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_filter_float(nk_text_edit* te, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_filter_decimal(nk_text_edit* te, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_filter_hex(nk_text_edit* te, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_filter_oct(nk_text_edit* te, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_filter_binary(nk_text_edit* te, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_init(nk_text_edit* te, nk_allocator* alloc, IntPtr size);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_init_fixed(nk_text_edit* te, IntPtr memory, IntPtr size);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_free(nk_text_edit* te);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_text(nk_text_edit* te, byte* s, int total_len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_delete(nk_text_edit* te, int where, int len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_delete_selection(nk_text_edit* te);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_select_all(nk_text_edit* te);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_textedit_cut(nk_text_edit* te);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern int nk_textedit_paste(nk_text_edit* te, byte* s, int len);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_undo(nk_text_edit* te);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_textedit_redo(nk_text_edit* te);
	}
}
