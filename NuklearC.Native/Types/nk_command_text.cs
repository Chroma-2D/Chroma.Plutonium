using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_command_text
    {
        public nk_command header;
        public nk_user_font* font;
        public nk_color background;
        public nk_color foreground;
        public short x;
        public short y;
        public ushort w;
        public ushort h;
        public float height;
        public int length;
        public byte stringFirstByte;
    }
}