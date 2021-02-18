using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int nk_plugin_filter_t(ref nk_text_edit edit, uint unicode_rune);
}