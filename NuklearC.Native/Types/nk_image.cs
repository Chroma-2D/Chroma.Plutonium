using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_image
    {
        public nk_handle handle;
        public ushort w;
        public ushort h;
        public fixed ushort region[4];
    }
}