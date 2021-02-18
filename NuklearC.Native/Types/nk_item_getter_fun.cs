using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void nk_item_getter_fun(IntPtr user, int i, byte** idk);
}