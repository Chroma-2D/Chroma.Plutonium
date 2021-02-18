using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_row_layout
    {
        public nk_panel_row_layout_type type;
        public int index;
        public float height;
        public float min_height;
        public int columns;
        public float* ratio;
        public float item_width;
        public float item_height;
        public float item_offset;
        public float filled;
        public nk_rect item;
        public int tree_depth;
        public fixed float templates[16];
    }
}