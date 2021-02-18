using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_edit_state
    {
        public uint name_nkhash;
        public uint seq;
        public uint old;
        public int active;
        public int prev;
        public int cursor;
        public int sel_start;
        public int sel_end;
        public nk_scroll scrollbar;
        public byte mode;
        public byte single_line;
    }
}