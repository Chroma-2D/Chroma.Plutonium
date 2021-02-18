using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_text_edit {
        public nk_clipboard clip;
        public nk_str str;
        public IntPtr filter_nkPluginFilterT;
        public nk_vec2 scrollbar;

        public int cursor;
        public int select_start;
        public int select_end;
        public byte mode;
        public byte cursor_at_end_of_line;
        public byte initialized;
        public byte has_preferred_x;
        public byte single_line;
        public byte active;
        public byte padding1;
        public float preferred_x;
        public nk_text_undo_state undo;
    }
}