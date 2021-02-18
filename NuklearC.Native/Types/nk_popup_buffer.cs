using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_popup_buffer
    {
        public IntPtr begin_nksize;
        public IntPtr parent_nksize;
        public IntPtr last_nksize;
        public IntPtr end_nksize;
        public int active;
    }
}