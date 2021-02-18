using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_window_flags : uint
    {
        NK_WINDOW_PRIVATE = 1 << 11,
        NK_WINDOW_DYNAMIC = NK_WINDOW_PRIVATE,
        NK_WINDOW_ROM = 1 << 12,
        NK_WINDOW_NOT_INTERACTIVE = NK_WINDOW_ROM | nk_panel_flags.NO_INPUT,
        NK_WINDOW_HIDDEN = 1 << 13,
        NK_WINDOW_CLOSED = 1 << 14,
        NK_WINDOW_MINIMIZED = 1 << 15,
        NK_WINDOW_REMOVE_ROM = 1 << 16
    }
}