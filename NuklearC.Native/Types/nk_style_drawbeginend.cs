using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void nk_style_drawbeginend(nk_command_buffer* cbuf, nk_handle userdata);
}