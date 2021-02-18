using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_table
    {
        public uint seq;
        public uint size;
        public fixed uint keys_nkhash[472 / 8];
        public fixed uint values[472 / 8];
        public nk_table* next;
        public nk_table* prev;
    }
}