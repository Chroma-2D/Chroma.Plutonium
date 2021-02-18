using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_config_stack_user_font
    {
        public int head;
        public nk_config_stack_user_font_element element0;
        public nk_config_stack_user_font_element element1;
        public nk_config_stack_user_font_element element2;
        public nk_config_stack_user_font_element element3;
        public nk_config_stack_user_font_element element4;
        public nk_config_stack_user_font_element element5;
        public nk_config_stack_user_font_element element6;
        public nk_config_stack_user_font_element element7;
    }
}