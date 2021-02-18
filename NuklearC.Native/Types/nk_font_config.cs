using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_font_config
    {
        public nk_font_config* next;
        public IntPtr ttf_blob;
        public IntPtr ttf_size;
        public byte ttf_data_owned_by_atlas;
        public byte merge_mode;
        public byte pixel_snap;
        public byte oversample_v;
        public byte oversample_h;
        fixed byte padding[3];
        public float size;
        public nk_font_coord_type coord_type;
        public nk_vec2 spacing;
        public uint* range;
        public nk_baked_font* font;
        public uint fallback_glyph;

        public nk_font_config* n;
        public nk_font_config* p;
    }
}