using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_user_font
    {
        public nk_handle userdata;
        public float height;
        public IntPtr widthfun_nkTextWidthF;
        public IntPtr queryfun_nkQueryFontGlyphF;
        public nk_handle texture;
    }
}