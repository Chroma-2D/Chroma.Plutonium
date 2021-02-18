using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_pool
    {
        public nk_allocator alloc;
        public nk_allocation_type type;
        public uint page_count;
        public nk_page* pages;
        public nk_page_element* freelist;
        public uint capacity;
        public IntPtr size_nksize;
        public IntPtr cap_nksize;
    }
}