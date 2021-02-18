using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_menu_state
    {
        public float x;
        public float y;
        public float w;
        public float h;
        public nk_scroll offset;
    }
}