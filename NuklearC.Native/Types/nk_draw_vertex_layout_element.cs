using System;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_draw_vertex_layout_element
    {
        public static readonly nk_draw_vertex_layout_element NK_VERTEX_LAYOUT_END = new nk_draw_vertex_layout_element(
            nk_draw_vertex_layout_attribute.NK_VERTEX_ATTRIBUTE_COUNT, nk_draw_vertex_layout_format.NK_FORMAT_COUNT,
            IntPtr.Zero);

        public nk_draw_vertex_layout_attribute attribute;
        public nk_draw_vertex_layout_format format;
        public IntPtr offset_nksize;

        public nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute Attr, nk_draw_vertex_layout_format Fmt,
            IntPtr Offset)
        {
            attribute = Attr;
            format = Fmt;
            offset_nksize = Offset;
        }
    }
}