using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        public nk_color(byte R, byte G, byte B, byte A = 255)
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
}