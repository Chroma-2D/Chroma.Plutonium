using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_config_stack_color_element
    {
        public nk_color* address;
        public nk_color old_value;
    }
}