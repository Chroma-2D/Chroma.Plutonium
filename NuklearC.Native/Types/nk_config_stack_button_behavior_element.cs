using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_config_stack_button_behavior_element
    {
        public nk_button_behavior* address;
        public nk_button_behavior old_value;
    }
}