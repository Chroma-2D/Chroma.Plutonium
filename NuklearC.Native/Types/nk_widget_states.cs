using System;

namespace NuklearC.Native.Types
{
    [Flags]
    public enum nk_widget_states
    {
        NK_WIDGET_STATE_MODIFIED = 1 << 1,
        NK_WIDGET_STATE_INACTIVE = 1 << 2,
        NK_WIDGET_STATE_ENTERED = 1 << 3,
        NK_WIDGET_STATE_HOVER = 1 << 4,
        NK_WIDGET_STATE_ACTIVED = 1 << 5,
        NK_WIDGET_STATE_LEFT = 1 << 6,
        NK_WIDGET_STATE_HOVERED = NK_WIDGET_STATE_HOVER | NK_WIDGET_STATE_MODIFIED,
        NK_WIDGET_STATE_ACTIVE = NK_WIDGET_STATE_ACTIVED | NK_WIDGET_STATE_MODIFIED
    }
}