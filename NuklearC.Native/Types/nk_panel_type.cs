using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_panel_type : uint
    {
        NK_PANEL_WINDOW = 1 << 0,
        NK_PANEL_GROUP = 1 << 1,
        NK_PANEL_POPUP = 1 << 2,
        NK_PANEL_CONTEXTUAL = 1 << 4,
        NK_PANEL_COMBO = 1 << 5,
        NK_PANEL_MENU = 1 << 6,
        NK_PANEL_TOOLTIP = 1 << 7
    }
}