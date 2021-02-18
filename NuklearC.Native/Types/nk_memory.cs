using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_memory
    {
        public IntPtr ptr;
        public IntPtr size;
    }
}