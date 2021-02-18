using System.Drawing;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_rect
    {
        public float x;
        public float y;
        public float w;
        public float h;

        public static implicit operator nk_rect(RectangleF rect)
        {
            return new()
            {
                x = rect.X,
                y = rect.Y,
                w = rect.Width,
                h = rect.Height
            };
        }

        public static implicit operator Rectangle(nk_rect rect)
        {
            return new(
                (int)rect.x,
                (int)rect.y,
                (int)rect.w,
                (int)rect.h
            );
        }

        public static implicit operator RectangleF(nk_rect rect)
        {
            return new(
                rect.x,
                rect.y,
                rect.w,
                rect.h
            );
        }
    }
}