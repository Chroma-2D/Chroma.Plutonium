using System;
using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet
{
    internal enum nk_anti_aliasing
    {
        NK_ANTI_ALIASING_OFF,
        NK_ANTI_ALIASING_ON
    }

    [Flags]
    internal enum NkConvertResult
    {
        // nk_convert_result, NK_CONVERT_*
        Success = 0,
        InvalidParam = 1,
        CommandBufferFull = (1 << (1)),
        VertexBufferFull = (1 << (2)),
        ElementBufferFull = (1 << (3))
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_draw_null_texture
    {
        internal NkHandle texture;
        internal nk_vec2 uv;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_convert_config
    {
        internal float global_alpha;
        internal nk_anti_aliasing line_AA;
        internal nk_anti_aliasing shape_AA;
        internal uint circle_segment_count;
        internal uint arc_segment_count;
        internal uint curve_segment_count;
        internal nk_draw_null_texture null_tex;
        internal nk_draw_vertex_layout_element* vertex_layout;
        internal IntPtr vertex_size;
        internal IntPtr vertex_alignment;
    }

    internal enum nk_command_type
    {
        NK_COMMAND_NOP,
        NK_COMMAND_SCISSOR,
        NK_COMMAND_LINE,
        NK_COMMAND_CURVE,
        NK_COMMAND_RECT,
        NK_COMMAND_RECT_FILLED,
        NK_COMMAND_RECT_MULTI_COLOR,
        NK_COMMAND_CIRCLE,
        NK_COMMAND_CIRCLE_FILLED,
        NK_COMMAND_ARC,
        NK_COMMAND_ARC_FILLED,
        NK_COMMAND_TRIANGLE,
        NK_COMMAND_TRIANGLE_FILLED,
        NK_COMMAND_POLYGON,
        NK_COMMAND_POLYGON_FILLED,
        NK_COMMAND_POLYLINE,
        NK_COMMAND_TEXT,
        NK_COMMAND_IMAGE,
        NK_COMMAND_CUSTOM
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command
    {
        internal nk_command_type ctype;
        internal IntPtr next_nksize;
        internal NkHandle userdata;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_scissor
    {
        internal nk_command header;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_line
    {
        internal nk_command header;
        internal ushort line_thickness;
        internal nk_vec2i begin;
        internal nk_vec2i end;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_curve
    {
        internal nk_command header;
        internal ushort line_thickness;
        internal nk_vec2i begin;
        internal nk_vec2i end;
        internal nk_vec2i ctrlA;
        internal nk_vec2i ctrlB;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_rect
    {
        internal nk_command header;
        internal ushort rounding;
        internal ushort line_thickness;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_rect_filled
    {
        internal nk_command header;
        internal ushort rounding;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_rect_multi_color
    {
        internal nk_command header;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
        internal NkColor left;
        internal NkColor top;
        internal NkColor bottom;
        internal NkColor right;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_triangle
    {
        internal nk_command header;
        internal ushort line_thickness;
        internal nk_vec2i a;
        internal nk_vec2i b;
        internal nk_vec2i c;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_triangle_filled
    {
        internal nk_command header;
        internal nk_vec2i a;
        internal nk_vec2i b;
        internal nk_vec2i c;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_circle
    {
        internal nk_command header;
        internal short x;
        internal short y;
        internal ushort line_thickness;
        internal ushort w;
        internal ushort h;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_circle_filled
    {
        internal nk_command header;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_command_arc
    {
        internal nk_command header;
        internal short cx;
        internal short cy;
        internal ushort r;
        internal ushort line_thickness;
        internal fixed float a[2];
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_command_arc_filled
    {
        internal nk_command header;
        internal short cx;
        internal short cy;
        internal ushort r;
        internal fixed float a[2];
        internal NkColor color;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_command_polygon
    {
        internal nk_command header;
        internal NkColor color;
        internal ushort line_thickness;
        internal ushort point_count;
        internal nk_vec2i firstPoint; /* (fixed?) struct nk_vec2i points[1]; /* ????? * */
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_command_polygon_filled
    {
        internal nk_command header;
        internal NkColor color;
        internal ushort point_count;
        internal nk_vec2i firstPoint;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_polyline
    {
        internal nk_command header;
        internal NkColor color;
        internal ushort line_thickness;
        internal ushort point_count;
        internal nk_vec2i firstPoint;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_image
    {
        internal nk_command header;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
        internal nk_image img;
        internal NkColor col;
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void nk_command_custom_callback(IntPtr canvas, short x, short y, ushort w, ushort h,
        NkHandle callback_data);

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_command_custom
    {
        internal nk_command header;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
        internal NkHandle callback_data;
        internal nk_command_custom_callback callback;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_command_text
    {
        internal nk_command header;
        internal nk_user_font* font;
        internal NkColor background;
        internal NkColor foreground;
        internal short x;
        internal short y;
        internal ushort w;
        internal ushort h;
        internal float height;
        internal int length;
        internal byte stringFirstByte;
    }

    internal enum nk_command_clipping
    {
        NK_CLIPPING_OFF = nk_bool.nk_false,
        NK_CLIPPING_ON = nk_bool.nk_true
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_command_buffer
    {
        internal nk_buffer* baseBuf;
        internal NkRect clip;
        internal int use_clipping;
        internal NkHandle userdata;
        internal IntPtr begin_nksize;
        internal IntPtr end_nksize;
        internal IntPtr last_nksize;
    }

    /* nk_draw_index -> nk_ushort */

    internal enum nk_draw_list_stroke
    {
        NK_STROKE_OPEN = nk_bool.nk_false,
        NK_STROKE_CLOSED = nk_bool.nk_true
    }

    internal enum nk_draw_vertex_layout_attribute
    {
        NK_VERTEX_POSITION,
        NK_VERTEX_COLOR,
        NK_VERTEX_TEXCOORD,
        NK_VERTEX_ATTRIBUTE_COUNT
    }

    internal enum nk_draw_vertex_layout_format
    {
        NK_FORMAT_SCHAR,
        NK_FORMAT_SSHORT,
        NK_FORMAT_SINT,
        NK_FORMAT_UCHAR,
        NK_FORMAT_USHORT,
        NK_FORMAT_UINT,
        NK_FORMAT_FLOAT,
        NK_FORMAT_DOUBLE,

        NK_FORMAT_COLOR_BEGIN,
        NK_FORMAT_R8G8B8 = NK_FORMAT_COLOR_BEGIN,
        NK_FORMAT_R16G15B16,
        NK_FORMAT_R32G32B32,

        NK_FORMAT_R8G8B8A8,
        NK_FORMAT_B8G8R8A8,
        NK_FORMAT_R16G15B16A16,
        NK_FORMAT_R32G32B32A32,
        NK_FORMAT_R32G32B32A32_FLOAT,
        NK_FORMAT_R32G32B32A32_DOUBLE,

        NK_FORMAT_RGB32,
        NK_FORMAT_RGBA32,
        NK_FORMAT_COLOR_END = NK_FORMAT_RGBA32,
        NK_FORMAT_COUNT
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_draw_vertex_layout_element
    {
        internal static readonly nk_draw_vertex_layout_element NK_VERTEX_LAYOUT_END = new nk_draw_vertex_layout_element(
            nk_draw_vertex_layout_attribute.NK_VERTEX_ATTRIBUTE_COUNT, nk_draw_vertex_layout_format.NK_FORMAT_COUNT,
            IntPtr.Zero);

        internal nk_draw_vertex_layout_attribute attribute;
        internal nk_draw_vertex_layout_format format;
        internal IntPtr offset_nksize;

        internal nk_draw_vertex_layout_element(nk_draw_vertex_layout_attribute Attr, nk_draw_vertex_layout_format Fmt,
            IntPtr Offset)
        {
            this.attribute = Attr;
            this.format = Fmt;
            this.offset_nksize = Offset;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_draw_command
    {
        internal uint elem_count;
        internal NkRect clip_rect;
        internal NkHandle texture;
        internal NkHandle userdata;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_draw_list
    {
        internal NkRect clip_rect;
        internal fixed long circle_vtx_CastMeToVec2[12];
        internal nk_convert_config config;

        internal nk_buffer* buffer;
        internal nk_buffer* vertices;
        internal nk_buffer* elements;

        internal uint element_count;
        internal uint vertex_count;
        internal uint cmd_count;
        internal IntPtr cmd_offset_nksize;

        internal uint path_count;
        internal uint path_offset;

        internal nk_anti_aliasing line_AA;
        internal nk_anti_aliasing shape_AA;

        internal NkHandle userdata;
    }

    internal static unsafe partial class LibNuklear
    {
        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_command* nk__begin(nk_context* context);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_command* nk__next(nk_context* context, nk_command* command);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_convert(nk_context* context, nk_buffer* cmds, nk_buffer* vertices,
            nk_buffer* elements, nk_convert_config* ncc);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_draw_command* nk__draw_begin(nk_context* context, nk_buffer* buf);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_draw_command* nk__draw_end(nk_context* context, nk_buffer* buf);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_draw_command* nk__draw_next(nk_draw_command* drawc, nk_buffer* buf,
            nk_context* context);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_begin(nk_context* context, byte* title, NkRect bounds, uint flags_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_begin(nk_context* context, string title, NkRect bounds, uint flags_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_begin_titled(nk_context* context, string name, string title, NkRect bounds,
            uint flags_nkflags);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_end(nk_context* context);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_line(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1,
            float line_thickness, NkColor color);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_curve(nk_command_buffer* cbuf, float x, float y, float x1, float y1,
            float xa, float ya, float xb, float yb, float line_thickness, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_rect(nk_command_buffer* cbuf, NkRect r, float rounding,
            float line_thickness, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_circle(nk_command_buffer* cbuf, NkRect r, float line_thickness,
            NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_arc(nk_command_buffer* cbuf, float cx, float cy, float radius,
            float a_min, float a_max, float line_thickness, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_triangle(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1,
            float x2, float y2, float line_thickness, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_polyline(nk_command_buffer* cbuf, float* points, int point_count,
            float line_thickness, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_stroke_polygon(nk_command_buffer* cbuf, float* points, int point_count,
            float line_thickness, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_fill_rect(nk_command_buffer* cbuf, NkRect r, float rounding, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_fill_rect_multi_color(nk_command_buffer* cbuf, NkRect r, NkColor left,
            NkColor top, NkColor right, NkColor bottom);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_fill_circle(nk_command_buffer* cbuf, NkRect r, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_fill_arc(nk_command_buffer* cbuf, float cx, float cy, float radius, float a_min,
            float a_max, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_fill_triangle(nk_command_buffer* cbuf, float x0, float y0, float x1, float y1,
            float x2, float y2, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_fill_polygon(nk_command_buffer* cbuf, float* pts, int point_count, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_image(nk_command_buffer* cbuf, NkRect r, nk_image* img, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_text(nk_command_buffer* cbuf, NkRect r, byte* text, int len,
            nk_user_font* userfont, NkColor col, NkColor col2);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_push_scissor(nk_command_buffer* cbuf, NkRect r);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_push_custom(nk_command_buffer* cbuf, NkRect r, nk_command_custom_callback cb,
            NkHandle userdata);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_init(nk_draw_list* dl);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_setup(nk_draw_list* dl, nk_convert_config* ncc, nk_buffer* cmds,
            nk_buffer* vertices, nk_buffer* elements, nk_anti_aliasing line_aa, nk_anti_aliasing shape_aa);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_clear(nk_draw_list* dl);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_draw_command* nk__draw_list_begin(nk_draw_list* dl, nk_buffer* buf);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_draw_command* nk__draw_list_next(nk_draw_command* drawcmd, nk_buffer* buf,
            nk_draw_list* dl);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_draw_command* nk__draw_list_end(nk_draw_list* dl, nk_buffer* buf);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_clear(nk_draw_list* dl);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_line_to(nk_draw_list* dl, nk_vec2 pos);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_arc_to_fast(nk_draw_list* dl, nk_vec2 center, float radius,
            int a_min, int a_max);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_arc_to(nk_draw_list* dl, nk_vec2 center, float radius,
            float a_min, float a_max, uint segments);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_rect_to(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, float rounding);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_curve_to(nk_draw_list* dl, nk_vec2 p2, nk_vec2 p3, nk_vec2 p4,
            uint num_segments);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_fill(nk_draw_list* dl, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_path_stroke(nk_draw_list* dl, NkColor col, nk_draw_list_stroke closed,
            float thickness);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_stroke_line(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, NkColor col,
            float thickness);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_stroke_rect(nk_draw_list* dl, NkRect rect, NkColor col, float rounding,
            float thickness);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_stroke_triangle(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_vec2 c,
            NkColor col, float thickness);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_stroke_circle(nk_draw_list* dl, nk_vec2 center, float radius,
            NkColor col, uint segs, float thickness);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_stroke_curve(nk_draw_list* dl, nk_vec2 p0, nk_vec2 cp0, nk_vec2 cp1,
            nk_vec2 p1, NkColor col, uint segments, float thickness);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_stroke_poly_line(nk_draw_list* dl, nk_vec2* pnts, uint cnt,
            NkColor col, nk_draw_list_stroke stroke, float thickness, nk_anti_aliasing aa);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_fill_rect(nk_draw_list* dl, NkRect rect, NkColor col, float rounding);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_fill_rect_multi_color(nk_draw_list* dl, NkRect rect, NkColor left,
            NkColor top, NkColor right, NkColor bottom);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_fill_triangle(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, nk_vec2 c,
            NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_fill_circle(nk_draw_list* dl, nk_vec2 center, float radius,
            NkColor col, uint segs);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_fill_poly_convex(nk_draw_list* dl, nk_vec2* points, uint count,
            NkColor col, nk_anti_aliasing aa);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void
            nk_draw_list_add_image(nk_draw_list* dl, nk_image texture, NkRect rect, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_add_text(nk_draw_list* dl, nk_user_font* userfont, NkRect rect,
            byte* text, int len, float font_height, NkColor col);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_draw_list_push_userdata(nk_draw_list* dl, NkHandle userdata);
    }
}