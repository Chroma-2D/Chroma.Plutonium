using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_page_element
    {
        public nk_page_data data;
        public nk_page_element* next;
        public nk_page_element* prev;
    }
}