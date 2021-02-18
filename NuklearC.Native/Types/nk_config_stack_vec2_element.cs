using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_config_stack_vec2_element
    {
        public nk_vec2* address;
        public nk_vec2 old_value;
    }
}