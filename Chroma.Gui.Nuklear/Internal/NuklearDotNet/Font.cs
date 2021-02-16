using System;
using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet {
	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_user_font_glyph {
		internal nk_vec2 u;
		internal nk_vec2 v;
		internal nk_vec2 offset;
		internal float width;
		internal float height;
		internal float xadvance;
	}

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate float nk_text_width_f(NkHandle handle, float h, byte* s, int len);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal unsafe delegate void nk_query_font_glyph_f(NkHandle handle, float font_height, nk_user_font_glyph* glyph, uint codepoint, uint next_codepoint);

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_user_font {
		internal NkHandle userdata;
		internal float height;
		internal IntPtr widthfun_nkTextWidthF;
		internal IntPtr queryfun_nkQueryFontGlyphF;
		internal NkHandle texture;
	}

	internal enum nk_font_coord_type {
		NK_COORD_UV,
		NK_COORD_PIXEL
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_baked_font {
		internal float height;
		internal float ascent;
		internal float descent;
		internal uint glyph_offset;
		internal uint glyph_count;
		internal uint* ranges;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_font_config {
		internal nk_font_config* next;
		internal IntPtr ttf_blob;
		internal IntPtr ttf_size;
		internal byte ttf_data_owned_by_atlas;
		internal byte merge_mode;
		internal byte pixel_snap;
		internal byte oversample_v;
		internal byte oversample_h;
		fixed byte padding[3];
		internal float size;
		internal nk_font_coord_type coord_type;
		internal nk_vec2 spacing;
		internal uint* range;
		internal nk_baked_font* font;
		internal uint fallback_glyph;

		internal nk_font_config* n;
		internal nk_font_config* p;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct nk_font_glyph {
		internal uint codepoint;
		internal float xadvance;
		internal float x0;
		internal float y0;
		internal float x1;
		internal float y1;
		internal float w;
		internal float h;
		internal float u0;
		internal float v0;
		internal float u1;
		internal float v1;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_font {
		internal nk_font* next;
		internal nk_user_font handle;
		internal nk_baked_font info;
		internal float scale;
		internal nk_font_glyph* glyphs;
		internal nk_font_glyph* fallback;
		internal uint fallback_codepoint;
		internal NkHandle texture;
		internal nk_font_config* config;
	}

	internal enum nk_font_atlas_format {
		NK_FONT_ATLAS_ALPHA8,
		NK_FONT_ATLAS_RGBA32
	}

	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct nk_font_atlas {
		internal IntPtr pixel;
		internal int tex_width;
		internal int tex_height;

		internal nk_allocator permanent;
		internal nk_allocator temporary;

		internal nk_recti custom;
		internal nk_cursor cursorArrow;
		internal nk_cursor cursorText;
		internal nk_cursor cursorMove;
		internal nk_cursor cursorResizeV;
		internal nk_cursor cursorResizeH;
		internal nk_cursor cursorResizeTLDR;
		internal nk_cursor cursorResizeTRDL;

		internal int glyph_count;
		internal nk_font_glyph* glyphs;
		internal nk_font* default_font;
		internal nk_font* fonts;
		internal nk_font_config* config;
		internal int font_num;
	}

	// [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
	internal static unsafe partial class LibNuklear {
		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern uint* nk_font_default_glyph_ranges();

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern uint* nk_font_chinese_glyph_ranges();

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern uint* nk_font_cyrillic_glyph_ranges();

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern uint* nk_font_korean_glyph_ranges();

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_font_atlas_init(nk_font_atlas* atlas, nk_allocator* alloc);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_font_atlas_init_custom(nk_font_atlas* atlas, nk_allocator* persistent, nk_allocator* transient);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_font_atlas_begin(nk_font_atlas* atlas);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_font_config nk_font_config(float pixel_height);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_font* nk_font_atlas_add(nk_font_atlas* atlas, nk_font_config* fconfig);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_font* nk_font_atlas_add_default(nk_font_atlas* atlas, float height, nk_font_config* fconfig);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_font* nk_font_atlas_add_from_memory(nk_font_atlas* atlas, IntPtr memory, IntPtr size, float height, nk_font_config* fconfig);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_font* nk_font_atlas_add_compressed(nk_font_atlas* atlas, IntPtr memory, IntPtr size, float height, nk_font_config* fconfig);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_font* nk_font_atlas_add_compressed_base85(nk_font_atlas* atlas, byte* data, float height, nk_font_config* fconfig);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern IntPtr nk_font_atlas_bake(nk_font_atlas* atlas, int* width, int* height, nk_font_atlas_format afmt);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_font_atlas_end(nk_font_atlas* atlas, NkHandle tex, nk_draw_null_texture* drawnulltex);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern nk_font_glyph* nk_font_find_glyph(nk_font* font, uint unicode);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_font_atlas_cleanup(nk_font_atlas* atlas);

		[DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
		internal static extern void nk_font_atlas_clear(nk_font_atlas* atlas);
	}
}
