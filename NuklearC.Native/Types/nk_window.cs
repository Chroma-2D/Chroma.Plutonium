using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_window
    {
        public uint seq;
        public uint name_nkhash;
        public fixed byte name_string[64];
        public uint flags_nkflags;

        public nk_rect bounds;
        public nk_scroll scrollbar;
        public nk_command_buffer buffer;
        public nk_panel* layout;
        public float scrollbar_hiding_timer;

        public nk_property_state property;
        public nk_popup_state popup;
        public nk_edit_state edit;
        public uint scrolled;

        public nk_table* tables;
        public uint table_count;

        public nk_window* next;
        public nk_window* prev;
        public nk_window* parent;
    }
}