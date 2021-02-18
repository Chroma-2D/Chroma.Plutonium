using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_colorf
    {
        public float r;
        public float g;
        public float b;
        public float a;
    }
}