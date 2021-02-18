using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_command_buffer
    {
        public nk_buffer* baseBuf;
        public nk_rect clip;
        public int use_clipping;
        public nk_handle userdata;
        public IntPtr begin_nksize;
        public IntPtr end_nksize;
        public IntPtr last_nksize;
    }
}