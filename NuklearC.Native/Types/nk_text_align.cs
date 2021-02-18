using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_text_align
    {
        NK_TEXT_ALIGN_LEFT = 0x01,
        NK_TEXT_ALIGN_CENTERED = 0x02,
        NK_TEXT_ALIGN_RIGHT = 0x04,
        NK_TEXT_ALIGN_TOP = 0x08,
        NK_TEXT_ALIGN_MIDDLE = 0x10,
        NK_TEXT_ALIGN_BOTTOM = 0x20
    }
}