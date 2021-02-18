using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_context
    {
        public nk_input input;
        public nk_style style;
        public nk_buffer memory;
        public nk_clipboard clip;
        public uint last_widget_state_nkflags;
        public nk_button_behavior button_behavior;
        public nk_configuration_stacks stacks;
        public float delta_time_Seconds;

        public nk_draw_list draw_list;

        public nk_handle userdata;

        public nk_text_edit text_edit;

        public nk_command_buffer overlay;

        public int build;
        public int use_pool;
        public nk_pool pool;
        public nk_window* begin;
        public nk_window* end;
        public nk_window* active;
        public nk_window* current;
        public nk_page_element* freelist;
        public uint count;
        public uint seq;
    }
}