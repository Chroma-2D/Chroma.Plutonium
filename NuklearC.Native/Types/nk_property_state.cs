using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_property_state
    {
        public int active;
        public int prev;
        public fixed byte buffer[64];
        public int length;
        public int cursor;
        public int select_start;
        public int select_end;
        public uint name_nkhash;
        public uint seq;
        public uint old;
        public int state;
    }
}