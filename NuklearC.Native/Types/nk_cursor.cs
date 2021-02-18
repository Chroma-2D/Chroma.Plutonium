using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_cursor
    {
        public nk_image img;
        public nk_vec2 size;
        public nk_vec2 offset;
    }
}