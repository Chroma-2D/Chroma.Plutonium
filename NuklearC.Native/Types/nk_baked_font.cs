using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_baked_font
    {
        public float height;
        public float ascent;
        public float descent;
        public uint glyph_offset;
        public uint glyph_count;
        public uint* ranges;
    }
}