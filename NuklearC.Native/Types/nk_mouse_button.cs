using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_mouse_button
    {
        public int down;
        public uint clicked;
        public nk_vec2 clicked_pos;
    }
}