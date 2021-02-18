using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_buffer
    {
        public nk_buffer_marker marker0;
        public nk_buffer_marker marker1;
        public nk_allocator pool;
        public nk_allocation_type allocation_type;
        public nk_memory memory;
        public float grow_factor;
        public IntPtr allocated;
        public IntPtr needed;
        public IntPtr calls;
        public IntPtr size;
    }
}