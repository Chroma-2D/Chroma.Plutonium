using System.Numerics;
using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_vec2
    {
        public float x;
        public float y;

        public nk_vec2(float x, float y)
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
}