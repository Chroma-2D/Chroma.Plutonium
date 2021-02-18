using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Explicit)]
    public struct nk_handle
    {
        [FieldOffset(0)] public int id;
        [FieldOffset(0)] public IntPtr ptr;
    }
}