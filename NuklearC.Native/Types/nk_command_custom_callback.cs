using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void nk_command_custom_callback(IntPtr canvas, short x, short y, ushort w, ushort h,
        nk_handle callback_data);
}