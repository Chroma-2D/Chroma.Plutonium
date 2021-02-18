using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_config_stack_flags_element
    {
        public uint* address_nkflags;
        public uint old_value_nkflags;
    }
}