using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_edit_flags
    {
        // nk_edit_flags
        DEFAULT = 0,
        READ_ONLY = 1 << 0,
        AUTO_SELECT = 1 << 1,
        SIG_ENTER = 1 << 2,
        ALLOW_TAB = 1 << 3,
        NO_CURSOR = 1 << 4,
        SELECTABLE = 1 << 5,
        CLIPBOARD = 1 << 6,
        CTRL_ENTER_NEW_LINE = 1 << 7,
        NO_HORIZONTAL_SCROLL = 1 << 8,
        ALWAYS_INSERT_MODE = 1 << 9,
        MULTILINE = 1 << 10,
        GOTO_END_ON_ACTIVATE = 1 << 11
    }
}