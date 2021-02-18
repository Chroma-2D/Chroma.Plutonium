using System.Drawing;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_rect
    {
        public float X;
        public float Y;
        public float W;
        public float H;

        public nk_rect(float X, float Y, float W, float H)
        {
            this.X = X;
            this.Y = Y;
            this.W = W;
            this.H = H;
        }

        public static implicit operator RectangleF(nk_rect r)
        {
            return new(r.X, r.Y, r.W, r.H);
        }
    }
}