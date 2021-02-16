using System;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Chroma.Gui.Nuklear.Internal.NuklearDotNet
{
    internal enum nk_bool
    {
        nk_false,
        nk_true
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NkColor
    {
        internal byte R;
        internal byte G;
        internal byte B;
        internal byte A;

        internal NkColor(byte R, byte G, byte B, byte A = 255)
        {
            this.R = R;
            this.G = G;
            this.B = B;
            this.A = A;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1}, {2}, {3})", R, G, B, A);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_colorf
    {
        internal float r;
        internal float g;
        internal float b;
        internal float a;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_vec2
    {
        internal float x;
        internal float y;

        internal nk_vec2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static implicit operator Vector2(nk_vec2 v)
        {
            return new(v.x, v.y);
        }

        public static implicit operator nk_vec2(Vector2 V)
        {
            return new(V.X, V.Y);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_vec2i
    {
        internal short x;
        internal short y;
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct NkRect
    {
        // nk_rect
        internal float X;
        internal float Y;
        internal float W;
        internal float H;

        internal NkRect(float X, float Y, float W, float H)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
            this.H = H;
        }

        public static implicit operator RectangleF(NkRect r)
        {
            return new(r.X, r.Y, r.W, r.H);
        }
    }


    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_recti
    {
        internal short x;
        internal short y;
        internal short w;
        internal short h;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct nk_glyph
    {
        [FieldOffset(0)] internal fixed byte bytes[4];

        [FieldOffset(0)] internal int glyph;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct NkHandle
    {
        [FieldOffset(0)] internal int id;
        [FieldOffset(0)] internal IntPtr ptr;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal unsafe struct nk_image
    {
        internal NkHandle handle;
        internal ushort w;
        internal ushort h;
        internal fixed ushort region[4];
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_cursor
    {
        internal nk_image img;
        internal nk_vec2 size;
        internal nk_vec2 offset;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct nk_scroll
    {
        internal uint x;
        internal uint y;
    }

    /* ... */

    internal enum nk_heading
    {
        NK_UP,
        NK_RIGHT,
        NK_DOWN,
        NK_LEFT
    }

    internal enum nk_button_behavior
    {
        NK_BUTTON_DEFAULT,
        NK_BUTTON_REPEATER
    }

    internal enum nk_modify
    {
        NK_FIXED = nk_bool.nk_false,
        NK_MODIFIABLE = nk_bool.nk_true
    }

    internal enum nk_orientation
    {
        NK_VERTICAL,
        NK_HORIZONTAL
    }

    internal enum nk_collapse_states
    {
        NK_MINIMIZED = nk_bool.nk_false,
        NK_MAXIMIZED = nk_bool.nk_true
    }

    internal enum nk_show_states
    {
        NK_HIDDEN = nk_bool.nk_false,
        NK_SHOWN = nk_bool.nk_true
    }

    internal enum nk_chart_type
    {
        NK_CHART_LINES,
        NK_CHART_COLUMN,
        NK_CHART_MAX
    }

    internal enum nk_chart_event
    {
        NK_CHART_HOVERING = 0x01,
        NK_CHART_CLICKED = 0x02
    }

    internal enum nk_color_format
    {
        NK_RGB,
        NK_RGBA
    }

    internal enum nk_popup_type
    {
        NK_POPUP_STATIC,
        NK_POPUP_DYNAMIC
    }

    internal enum nk_layout_format
    {
        NK_DYNAMIC,
        NK_STATIC
    }

    internal enum nk_tree_type
    {
        NK_TREE_NODE,
        NK_TREE_TAB
    }

    internal static unsafe partial class LibNuklear
    {
        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkHandle nk_handle_ptr(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkHandle nk_handle_id(int id);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_image nk_image_handle(NkHandle handle);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_image nk_image_ptr(IntPtr ptr);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_image nk_image_id(int id);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern int nk_image_is_subimage(nk_image* img);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_image nk_subimage_ptr(IntPtr ptr, ushort w, ushort h, NkRect sub_region);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_image nk_subimage_id(int id, ushort w, ushort h, NkRect sub_region);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_image nk_subimage_handle(NkHandle handle, ushort w, ushort h, NkRect sub_region);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern uint nk_murmur_hash(IntPtr key, int len, uint seed);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern void nk_triangle_from_direction(nk_vec2* result, NkRect r, float pad_x, float pad_y,
            nk_heading heading);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_vec2i(int x, int y);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_vec2v(float* xy);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_vec2iv(int* xy);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_get_null_rect();

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_recti(int x, int y, int w, int h);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_recta(nk_vec2 pos, nk_vec2 size);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_rectv(float* xywh);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern NkRect nk_rectiv(int* xywh);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_rect_pos(NkRect r);

        [DllImport(DllName, CallingConvention = CConv, CharSet = CSet)]
        internal static extern nk_vec2 nk_rect_size(NkRect r);
    }
}