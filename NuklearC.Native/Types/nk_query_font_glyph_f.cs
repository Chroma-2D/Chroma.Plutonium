using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void nk_query_font_glyph_f(nk_handle handle, float font_height, nk_user_font_glyph* glyph,
        uint codepoint, uint next_codepoint);
}