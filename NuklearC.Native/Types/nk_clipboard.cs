using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_clipboard {
        public nk_handle userdata;
        public IntPtr pastefun_nkPluginPasteT;
        public IntPtr copyfun_nkPluginCopyT;
    }
}