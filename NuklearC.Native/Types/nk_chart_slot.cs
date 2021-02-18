using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_chart_slot
    {
        public nk_chart_type type;
        public nk_color color;
        public nk_color highlight;
        public float min;
        public float max;
        public float range;
        public int count;
        public nk_vec2 last;
        public int index;
    }
}