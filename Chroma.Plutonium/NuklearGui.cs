using System;
using System.Drawing;
using System.Numerics;
using NuklearC.NativeAbstractionLayer;
using NuklearC.Native.Types;

namespace Chroma.Plutonium
{
    public static class NuklearGui
    {
        public static void StaticRowLayout(float height, int childWidth, int columns)
            => NuklearUI.LayoutRowStatic(height, childWidth, columns);

        public static void DynamicRowLayout(float height = 0, int columns = 1)
            => NuklearUI.LayoutRowDynamic(height, columns);

        public static bool Window(string name, string title, Vector2 position, Size size, PanelFlags flags,
            Action render)
        {
            return NuklearUI.Window(
                name,
                title,
                new RectangleF(
                    position.X,
                    position.Y,
                    size.Width,
                    size.Height
                ),
                (nk_panel_flags)flags,
                render
            );
        }

        public static bool Window(string title, Vector2 position, Size size, PanelFlags flags, Action render)
        {
            return NuklearUI.Window(
                title,
                position.X,
                position.Y,
                size.Width,
                size.Height,
                (nk_panel_flags)flags,
                render
            );
        }

        public static bool IsWindowClosed(string name)
            => NuklearUI.WindowIsClosed(name);

        public static bool IsWindowHidden(string name)
            => NuklearUI.WindowIsHidden(name);

        public static bool IsWindowCollapsed(string name)
            => NuklearUI.WindowIsCollapsed(name);

        public static RectangleF GetWindowBounds()
            => NuklearUI.WindowGetBounds();

        public static bool Group(string name, string title, PanelFlags flags, Action render)
        {
            return NuklearUI.Group(
                name,
                title,
                (nk_panel_flags)flags,
                render
            );
        }

        public static bool Group(string name, PanelFlags flags, Action render)
        {
            return NuklearUI.Group(
                name,
                (nk_panel_flags)flags,
                render
            );
        }

        public static bool Button(ButtonMode mode, string content)
        {
            return mode switch
            {
                ButtonMode.Label => NuklearUI.ButtonLabel(content),
                ButtonMode.Text => NuklearUI.ButtonLabel(content),
                _ => throw new NotSupportedException("Unsupported button mode.")
            };
        }

        public static void LabelWrapped(string text)
        {
            NuklearUI.LabelWrap(text);
        }

        public static void LabelWrapped(string text, Color color)
        {
            NuklearUI.LabelColoredWrap(
                text,
                color.R,
                color.G,
                color.B,
                color.A
            );
        }

        public static void Label(string text, TextAlignment textAlignment)
        {
            NuklearUI.Label(
                text,
                (nk_text_align)textAlignment
            );
        }

        public static void Label(string text, TextAlignment textAlignment, Color color)
        {
            NuklearUI.LabelColored(
                text,
                color.R,
                color.G,
                color.B,
                color.A,
                (nk_text_align)textAlignment
            );
        }
    }
}