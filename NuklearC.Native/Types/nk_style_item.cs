using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_style_item {
        public nk_style_item_type type;
        public nk_style_item_data data;
    }
}