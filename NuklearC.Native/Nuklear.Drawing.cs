using System.Runtime.InteropServices;
using NuklearC.Native.Types;

namespace NuklearC.Native
{
    public static unsafe partial class Nuklear
    {
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_command* nk__begin(nk_context* context);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_command* nk__next(nk_context* context, nk_command* command);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint nk_convert(
            nk_context* context,
            nk_buffer* cmds,
            nk_buffer* vertices,
            nk_buffer* elements,
            nk_convert_config* ncc
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_draw_command* nk__draw_begin(nk_context* context, nk_buffer* buf);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_draw_command* nk__draw_end(nk_context* context, nk_buffer* buf);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_draw_command* nk__draw_next(
            nk_draw_command* drawc,
            nk_buffer* buf,
            nk_context* context
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_begin(nk_context* context, byte* title, nk_rect bounds, uint flags_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_begin(nk_context* context, string title, nk_rect bounds, uint flags_nkflags);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int nk_begin_titled(
            nk_context* context,
            string name,
            string title,
            nk_rect bounds,
            uint flags_nkflags
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_end(nk_context* context);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_line(
            nk_command_buffer* cbuf,
            float x0,
            float y0,
            float x1,
            float y1,
            float line_thickness,
            nk_color color
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_curve(
            nk_command_buffer* cbuf,
            float x,
            float y,
            float x1,
            float y1,
            float xa,
            float ya,
            float xb,
            float yb,
            float line_thickness,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_rect(
            nk_command_buffer* cbuf,
            nk_rect r,
            float rounding,
            float line_thickness,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_circle(
            nk_command_buffer* cbuf,
            nk_rect r,
            float line_thickness,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_arc(
            nk_command_buffer* cbuf,
            float cx,
            float cy,
            float radius,
            float a_min,
            float a_max,
            float line_thickness,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_triangle(
            nk_command_buffer* cbuf,
            float x0,
            float y0,
            float x1,
            float y1,
            float x2,
            float y2,
            float line_thickness,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_polyline(
            nk_command_buffer* cbuf,
            float* points,
            int point_count,
            float line_thickness,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_stroke_polygon(
            nk_command_buffer* cbuf,
            float* points,
            int point_count,
            float line_thickness,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_fill_rect(
            nk_command_buffer* cbuf,
            nk_rect r,
            float rounding,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_fill_rect_multi_color(
            nk_command_buffer* cbuf,
            nk_rect r,
            nk_color left,
            nk_color top,
            nk_color right,
            nk_color bottom
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_fill_circle(nk_command_buffer* cbuf, nk_rect r, nk_color col);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_fill_arc(
            nk_command_buffer* cbuf,
            float cx,
            float cy,
            float radius,
            float a_min,
            float a_max,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_fill_triangle(
            nk_command_buffer* cbuf,
            float x0,
            float y0,
            float x1,
            float y1,
            float x2,
            float y2,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_fill_polygon(nk_command_buffer* cbuf, float* pts, int point_count, nk_color col);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_image(nk_command_buffer* cbuf, nk_rect r, nk_image* img, nk_color col);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_text(
            nk_command_buffer* cbuf,
            nk_rect r,
            byte* text,
            int len,
            nk_user_font* userfont,
            nk_color col,
            nk_color col2
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_push_scissor(nk_command_buffer* cbuf, nk_rect r);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_push_custom(
            nk_command_buffer* cbuf,
            nk_rect r,
            nk_command_custom_callback cb,
            nk_handle userdata
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_init(nk_draw_list* dl);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_setup(
            nk_draw_list* dl,
            nk_convert_config* ncc,
            nk_buffer* cmds,
            nk_buffer* vertices,
            nk_buffer* elements,
            nk_anti_aliasing line_aa,
            nk_anti_aliasing shape_aa
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_clear(nk_draw_list* dl);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_draw_command* nk__draw_list_begin(nk_draw_list* dl, nk_buffer* buf);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_draw_command* nk__draw_list_next(
            nk_draw_command* drawcmd,
            nk_buffer* buf,
            nk_draw_list* dl
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern nk_draw_command* nk__draw_list_end(nk_draw_list* dl, nk_buffer* buf);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_clear(nk_draw_list* dl);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_line_to(nk_draw_list* dl, nk_vec2 pos);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_arc_to_fast(
            nk_draw_list* dl,
            nk_vec2 center,
            float radius,
            int a_min,
            int a_max
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_arc_to(
            nk_draw_list* dl,
            nk_vec2 center,
            float radius,
            float a_min,
            float a_max,
            uint segments
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_rect_to(nk_draw_list* dl, nk_vec2 a, nk_vec2 b, float rounding);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_curve_to(
            nk_draw_list* dl,
            nk_vec2 p2,
            nk_vec2 p3,
            nk_vec2 p4,
            uint num_segments
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_fill(nk_draw_list* dl, nk_color col);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_path_stroke(
            nk_draw_list* dl,
            nk_color col,
            nk_draw_list_stroke closed,
            float thickness
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_stroke_line(
            nk_draw_list* dl,
            nk_vec2 a,
            nk_vec2 b,
            nk_color col,
            float thickness
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_stroke_rect(
            nk_draw_list* dl,
            nk_rect rect,
            nk_color col,
            float rounding,
            float thickness
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_stroke_triangle(
            nk_draw_list* dl,
            nk_vec2 a,
            nk_vec2 b,
            nk_vec2 c,
            nk_color col,
            float thickness
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_stroke_circle(
            nk_draw_list* dl,
            nk_vec2 center,
            float radius,
            nk_color col,
            uint segs,
            float thickness
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_stroke_curve(
            nk_draw_list* dl,
            nk_vec2 p0,
            nk_vec2 cp0,
            nk_vec2 cp1,
            nk_vec2 p1,
            nk_color col,
            uint segments,
            float thickness
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_stroke_poly_line(
            nk_draw_list* dl,
            nk_vec2* pnts,
            uint cnt,
            nk_color col,
            nk_draw_list_stroke stroke,
            float thickness,
            nk_anti_aliasing aa
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_fill_rect(nk_draw_list* dl, nk_rect rect, nk_color col, float rounding);

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_fill_rect_multi_color(
            nk_draw_list* dl,
            nk_rect rect,
            nk_color left,
            nk_color top,
            nk_color right,
            nk_color bottom
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_fill_triangle(
            nk_draw_list* dl,
            nk_vec2 a,
            nk_vec2 b,
            nk_vec2 c,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_fill_circle(
            nk_draw_list* dl,
            nk_vec2 center,
            float radius,
            nk_color col,
            uint segs
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_fill_poly_convex(nk_draw_list* dl,
            nk_vec2* points,
            uint count,
            nk_color col,
            nk_anti_aliasing aa
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_add_image(
            nk_draw_list* dl,
            nk_image texture,
            nk_rect rect,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_add_text(
            nk_draw_list* dl,
            nk_user_font* userfont,
            nk_rect rect,
            byte* text,
            int len,
            float font_height,
            nk_color col
        );

        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void nk_draw_list_push_userdata(nk_draw_list* dl, nk_handle userdata);
    }
}