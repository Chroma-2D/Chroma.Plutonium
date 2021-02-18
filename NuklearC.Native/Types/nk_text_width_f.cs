using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate float nk_text_width_f(nk_handle handle, float h, byte* s, int len);
}