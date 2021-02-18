using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_page
    {
        public uint size;
        public nk_page* next;
        public nk_page_element win0;
    }
}