using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct nk_keyboard
    {
        public fixed uint keysCastTwoOfMeToOneNkKey[2 * (int)nk_keys.NK_KEY_MAX];
        public fixed byte text[Nuklear.NK_INPUT_MAX];
        public int text_len;
    }
}