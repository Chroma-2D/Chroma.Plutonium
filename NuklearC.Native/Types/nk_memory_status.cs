using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_memory_status
    {
        public IntPtr memory;
        public uint type;
        public IntPtr size;
        public IntPtr allocated;
        public IntPtr needed;
        public IntPtr calls;
    }
}