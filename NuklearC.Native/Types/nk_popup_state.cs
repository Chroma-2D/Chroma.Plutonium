using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_popup_state
    {
        public nk_window* win;
        public nk_panel_type type;
        public nk_popup_buffer buf;
        public uint name_nkhash;
        public int active;
        public uint combo_count;
        public uint con_count;
        public uint con_old;
        public uint active_con;
        public nk_rect header;
    }
}