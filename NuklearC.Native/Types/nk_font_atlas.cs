using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_font_atlas
    {
        public IntPtr pixel;
        public int tex_width;
        public int tex_height;

        public nk_allocator permanent;
        public nk_allocator temporary;

        public nk_recti custom;
        public nk_cursor cursorArrow;
        public nk_cursor cursorText;
        public nk_cursor cursorMove;
        public nk_cursor cursorResizeV;
        public nk_cursor cursorResizeH;
        public nk_cursor cursorResizeTLDR;
        public nk_cursor cursorResizeTRDL;

        public int glyph_count;
        public nk_font_glyph* glyphs;
        public nk_font* default_font;
        public nk_font* fonts;
        public nk_font_config* config;
        public int font_num;
    }
}