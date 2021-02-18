using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_buffer_marker
    {
        public int active;
        public IntPtr offset_nksize;
    }
}