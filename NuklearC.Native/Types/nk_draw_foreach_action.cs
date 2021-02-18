using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void nk_draw_foreach_action(nk_draw_command* c);
}