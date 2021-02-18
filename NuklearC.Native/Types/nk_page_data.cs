using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Explicit)]
    public struct nk_page_data
    {
        [FieldOffset(0)] public nk_panel pan;
        [FieldOffset(0)] public nk_window win;
        [FieldOffset(0)] public nk_table tbl;
    }
}