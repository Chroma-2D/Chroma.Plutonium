using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_config_stack_style_item_element
    {
        public nk_style_item* address;
        public nk_style_item old_value;
    }
}