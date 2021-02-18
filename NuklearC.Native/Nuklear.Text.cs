using System;
using System.Runtime.InteropServices;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_init(nk_str* str, nk_allocator* allocator, IntPtr size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_init_fixed(nk_str* str, IntPtr memory, IntPtr size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_clear(nk_str* str);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_free(nk_str* str);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_append_text_char(nk_str* str, byte* s, int slen);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_append_str_char(nk_str* str, byte* s);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_append_text_utf8(nk_str* str, byte* s, int slen);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_append_str_utf8(nk_str* str, byte* s);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_append_text_runes(nk_str* str, uint* runes, int len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_append_str_runes(nk_str* str, uint* runes);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_at_char(nk_str* str, int pos, byte* s, int slen);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_at_rune(nk_str* str, int pos, byte* s, int slen);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_text_char(nk_str* str, int pos, byte* s, int slen);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_str_char(nk_str* str, int pos, byte* s);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_text_utf8(nk_str* str, int pos, byte* s, int slen);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_str_utf8(nk_str* str, int pos, byte* s);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_text_runes(nk_str* str, int pos, uint* runes, int slen);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_insert_str_runes(nk_str* str, int pos, uint* runes);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_remove_chars(nk_str* str, int len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_remove_runes(nk_str* str, int len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_delete_chars(nk_str* str, int pos, int len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_str_delete_runes(nk_str* str, int pos, int len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* nk_str_at_char(nk_str* str, int pos);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte* nk_str_at_rune(nk_str* str, int pos, uint* unicode, int* len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_str_rune_at(nk_str* str, int pos);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char* nk_str_at_char_const(nk_str* str, int pos);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char* nk_str_at_const(nk_str* str, int pos, uint* unicode, int* len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char* nk_str_get(nk_str* str);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern char* nk_str_get_const(nk_str* str);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_len(nk_str* str);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_str_len_char(nk_str* str);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_filter_default(nk_text_edit* te, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_filter_ascii(nk_text_edit* te, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_filter_float(nk_text_edit* te, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_filter_decimal(nk_text_edit* te, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_filter_hex(nk_text_edit* te, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_filter_oct(nk_text_edit* te, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_filter_binary(nk_text_edit* te, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_init(nk_text_edit* te, nk_allocator* alloc, IntPtr size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_init_fixed(nk_text_edit* te, IntPtr memory, IntPtr size);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_free(nk_text_edit* te);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_text(nk_text_edit* te, byte* s, int total_len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_delete(nk_text_edit* te, int where, int len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_delete_selection(nk_text_edit* te);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_select_all(nk_text_edit* te);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_textedit_cut(nk_text_edit* te);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_textedit_paste(nk_text_edit* te, byte* s, int len);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_undo(nk_text_edit* te);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_textedit_redo(nk_text_edit* te);
    }
}