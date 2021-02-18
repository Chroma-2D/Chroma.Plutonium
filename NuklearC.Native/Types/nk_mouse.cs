using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_mouse
    {
        /* fixed nk_mouse_button buttons[(int)(nk_buttons.NK_BUTTON_MAX)]; */
        public nk_mouse_button buttonLeft;
        public nk_mouse_button buttonMiddle;
        public nk_mouse_button buttonRight;
        public nk_mouse_button buttonDouble;

        public nk_vec2 pos;
        public nk_vec2 prev;
        public nk_vec2 delta;
        public nk_vec2 scroll_delta;

        public byte grab;
        public byte grabbed;
        public byte ungrab;
    }
}