using NuklearC.Native.Types;

namespace Chroma.Plutonium
{
    public enum TextAlignment : uint
    {
        Left = nk_text_alignment.NK_TEXT_LEFT,
        Right = nk_text_alignment.NK_TEXT_RIGHT,
        Center = nk_text_alignment.NK_TEXT_CENTERED,
    }
}