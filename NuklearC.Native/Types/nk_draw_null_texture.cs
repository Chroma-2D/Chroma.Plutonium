using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_draw_null_texture
    {
        public nk_handle texture;
        public nk_vec2 uv;
    }

    /* nk_draw_index -> nk_ushort */
}