using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_color
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;
    }
}