using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_user_font_glyph
    {
        public nk_vec2 u;
        public nk_vec2 v;
        public nk_vec2 offset;
        public float width;
        public float height;
        public float xadvance;
    }
}