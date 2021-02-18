using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_recti
    {
        public short x;
        public short y;
        public short w;
        public short h;
    }
}