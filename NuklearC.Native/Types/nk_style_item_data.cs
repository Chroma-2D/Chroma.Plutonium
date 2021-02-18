using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Explicit)]
    public struct nk_style_item_data {
        [FieldOffset(0)]
        public nk_color color;

        [FieldOffset(0)]
        public nk_image image;
    }
}