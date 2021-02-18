using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_config_stack_user_font_element
    {
        public nk_user_font* address;
        public nk_user_font* old_value;
    }
}