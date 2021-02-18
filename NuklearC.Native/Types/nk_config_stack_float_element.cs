using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_config_stack_float_element
    {
        public float* address;
        public float old_value;
    }
}