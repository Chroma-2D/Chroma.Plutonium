using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_panel
    {
        public nk_panel_type type;
        public uint flags_nkflags;
        public nk_rect bounds;
        public uint* offset_x;
        public uint* offset_y;
        public float at_x;
        public float at_y;
        public float max_x;
        public float footer_height;
        public float header_height;
        public float border;
        public uint has_scrolling;
        public nk_rect clip;
        public nk_menu_state menu;
        public nk_row_layout row;
        public nk_chart chart;
        public nk_command_buffer* buffer;
        public nk_panel* parent;
    }
}