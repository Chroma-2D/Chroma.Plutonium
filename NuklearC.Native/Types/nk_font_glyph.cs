using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_font_glyph
    {
        public uint codepoint;
        public float xadvance;
        public float x0;
        public float y0;
        public float x1;
        public float y1;
        public float w;
        public float h;
        public float u0;
        public float v0;
        public float u1;
        public float v1;
    }
}