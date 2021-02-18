using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_list_view
    {
        public int begin;
        public int end;
        public int count;

        public int total_height;
        public nk_context* ctx;
        public uint* scroll_pointer;
        public uint scroll_value;
    }
}