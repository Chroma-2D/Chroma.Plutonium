using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_font
    {
        public nk_font* next;
        public nk_user_font handle;
        public nk_baked_font info;
        public float scale;
        public nk_font_glyph* glyphs;
        public nk_font_glyph* fallback;
        public uint fallback_codepoint;
        public nk_handle texture;
        public nk_font_config* config;
    }
}