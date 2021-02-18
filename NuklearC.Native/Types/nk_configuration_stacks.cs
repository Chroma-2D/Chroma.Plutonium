using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_configuration_stacks
    {
        public nk_config_stack_style_item style_items;
        public nk_config_stack_float floats;
        public nk_config_stack_vec2 vectors;
        public nk_config_stack_flags flags;
        public nk_config_stack_color colors;
        public nk_config_stack_user_font fonts;
        public nk_config_stack_button_behavior button_behaviors;
    }
}