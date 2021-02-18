using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void nk_plugin_free_t(nk_handle handle, IntPtr old);
}