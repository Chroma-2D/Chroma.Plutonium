using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_panel_flags : uint
    {
        BORDER = 1 << 0,
        MOVABLE = 1 << 1,
        SCALABLE = 1 << 2,
        CLOSABLE = 1 << 3,
        MINIMIZABLE = 1 << 4,
        NO_SCROLLBAR = 1 << 5,
        TITLE = 1 << 6,
        SCROLL_AUTO_HIDE = 1 << 7,
        BACKGROUND = 1 << 8,
        SCALE_LEFT = 1 << 9,
        NO_INPUT = 1 << 10,

        BORDER_TITLE = BORDER
                       | TITLE,

        CLOSABLE_MINIMIZABLE = CLOSABLE
                               | MINIMIZABLE,

        MOVABLE_SCALABLE = MOVABLE
                           | SCALABLE
    }
}