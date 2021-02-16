using System;
using Chroma.Gui.Nuklear.Internal.NuklearDotNet;

namespace Chroma.Gui.Nuklear
{
    [Flags]
    public enum PanelFlags : uint
    {
        Border = NkPanelFlags.Border,
        Movable = NkPanelFlags.Movable,
        Scalable = NkPanelFlags.Scalable,
        Closable = NkPanelFlags.Closable,
        Minimizable = NkPanelFlags.Minimizable,
        NoScrollbar = NkPanelFlags.NoScrollbar,
        Title = NkPanelFlags.Title,
        ScrollAutoHide = NkPanelFlags.ScrollAutoHide,
        Background = NkPanelFlags.Background,
        ScaleLeft = NkPanelFlags.ScaleLeft,
        NoInput = NkPanelFlags.NoInput,

        BorderTitle = Border | Title,
        ClosableMinimizable = Closable | Minimizable,
        MovableScalable = Movable | Scalable
    }
}