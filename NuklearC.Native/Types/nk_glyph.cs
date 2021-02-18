using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct nk_glyph
    {
        [FieldOffset(0)] public fixed byte bytes[4];

        [FieldOffset(0)] public int glyph;
    }
}