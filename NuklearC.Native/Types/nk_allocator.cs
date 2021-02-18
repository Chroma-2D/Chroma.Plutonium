using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    /* ... */

    [StructLayout(LayoutKind.Sequential)]
    public struct nk_allocator
    {
        public nk_handle userdata;

        // nk_plugin_alloc_t alloc;
        public IntPtr alloc_nkpluginalloct;

        // nk_plugin_free_t free;
        public IntPtr free_nkpluginfreet;
    }
}