using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr nk_plugin_alloc_t(nk_handle handle, IntPtr old, int nk_size);
}