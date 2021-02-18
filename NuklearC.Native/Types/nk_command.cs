using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command
    {
        public nk_command_type ctype;
        public IntPtr next_nksize;
        public nk_handle userdata;
    }
}