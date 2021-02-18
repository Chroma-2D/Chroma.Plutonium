using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_chart
    {
        public int slot;
        public float x;
        public float y;
        public float w;
        public float h;
        public nk_chart_slot slot0;
        public nk_chart_slot slot1;
        public nk_chart_slot slot2;
        public nk_chart_slot slot3;
    }
}