using System;
using System.Runtime.InteropServices;

namespace NuklearC.NativeAbstractionLayer
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FontStashAction(IntPtr atlas);
}