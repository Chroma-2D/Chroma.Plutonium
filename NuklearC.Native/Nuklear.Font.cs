using System;
using System.Runtime.InteropServices;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* nk_font_default_glyph_ranges();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* nk_font_chinese_glyph_ranges();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* nk_font_cyrillic_glyph_ranges();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint* nk_font_korean_glyph_ranges();

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_font_atlas_init(nk_font_atlas* atlas, nk_allocator* alloc);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_font_atlas_init_custom(
            nk_font_atlas* atlas,
            nk_allocator* persistent,
            nk_allocator* transient
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_font_atlas_begin(nk_font_atlas* atlas);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_font_config nk_font_config(float pixel_height);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_font* nk_font_atlas_add(nk_font_atlas* atlas, nk_font_config* fconfig);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_font* nk_font_atlas_add_default(
            nk_font_atlas* atlas,
            float height,
            nk_font_config* fconfig
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_font* nk_font_atlas_add_from_memory(
            nk_font_atlas* atlas,
            IntPtr memory,
            IntPtr size,
            float height,
            nk_font_config* fconfig
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_font* nk_font_atlas_add_compressed(
            nk_font_atlas* atlas,
            IntPtr memory,
            IntPtr size,
            float height,
            nk_font_config* fconfig
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_font* nk_font_atlas_add_compressed_base85(
            nk_font_atlas* atlas,
            byte* data,
            float height,
            nk_font_config* fconfig
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr nk_font_atlas_bake(
            nk_font_atlas* atlas,
            int* width,
            int* height,
            nk_font_atlas_format afmt
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_font_atlas_end(
            nk_font_atlas* atlas,
            nk_handle tex,
            nk_draw_null_texture* drawnulltex
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_font_glyph* nk_font_find_glyph(nk_font* font, uint unicode);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_font_atlas_cleanup(nk_font_atlas* atlas);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_font_atlas_clear(nk_font_atlas* atlas);
    }
}