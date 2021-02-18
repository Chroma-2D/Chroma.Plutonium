using System;
using NuklearC.Native.Types;

namespace Chroma.Plutonium
{
    [Flags]
    public enum PanelFlags : uint
    {
        Border = nk_panel_flags.BORDER,
        Movable = nk_panel_flags.MOVABLE,
        Scalable = nk_panel_flags.SCALABLE,
        Closable = nk_panel_flags.CLOSABLE,
        Minimizable = nk_panel_flags.MINIMIZABLE,
        NoScrollbar = nk_panel_flags.NO_SCROLLBAR,
        Title = nk_panel_flags.TITLE,
        ScrollAutoHide = nk_panel_flags.SCROLL_AUTO_HIDE,
        Background = nk_panel_flags.BACKGROUND,
        ScaleLeft = nk_panel_flags.SCALE_LEFT,
        NoInput = nk_panel_flags.NO_INPUT,

        BorderTitle = Border | Title,
        ClosableMinimizable = Closable | Minimizable,
        MovableScalable = Movable | Scalable
    }
}