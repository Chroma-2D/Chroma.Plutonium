using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void nk_plugin_copy_t(nk_handle handle, byte* str, int len);
}