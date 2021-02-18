using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_input
    {
        public nk_keyboard keyboard;
        public nk_mouse mouse;
    }
}