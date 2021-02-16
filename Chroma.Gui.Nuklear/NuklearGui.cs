using System;
using System.Drawing;
using System.Numerics;
using Chroma.Gui.Nuklear.Internal.NuklearDotNet;

namespace Chroma.Gui.Nuklear
{
    public static class NuklearGui
    {
        private static IntPtr Context => NuklearAPI.Context;
        
        public static void Frame(Action render)
            => NuklearAPI.Frame(render);

        public static void StaticRowLayout(float height, int childWidth, int columns)
            => NuklearAPI.LayoutRowStatic(height, childWidth, columns);

        public static void DynamicRowLayout(float height = 0, int columns = 1)
            => NuklearAPI.LayoutRowDynamic(height, columns);
        
        public static bool Window(string name, string title, Vector2 position, Size size, PanelFlags flags,
            Action render)
        {
            return NuklearAPI.Window(
                name,
                title,
                position.X,
                position.Y,
                size.Width,
                size.Height,
                (NkPanelFlags)flags,
                render
            );
        }

        public static bool Window(string title, Vector2 position, Size size, PanelFlags flags, Action render)
        {
            return NuklearAPI.Window(
                title,
                position.X,
                position.Y,
                size.Width,
                size.Height,
                (NkPanelFlags)flags,
                render
            );
        }

        public static bool IsWindowClosed(string name)
            => NuklearAPI.WindowIsClosed(name);

        public static bool IsWindowHidden(string name)
            => NuklearAPI.WindowIsHidden(name);

        public static bool IsWindowCollapsed(string name)
            => NuklearAPI.WindowIsCollapsed(name);

        public static RectangleF GetWindowBounds()
            => NuklearAPI.WindowGetBounds();

        public static bool Group(string name, string title, PanelFlags flags, Action render)
        {
            return NuklearAPI.Group(
                name,
                title,
                (NkPanelFlags)flags,
                render
            );
        }

        public static bool Group(string name, PanelFlags flags, Action render)
        {
            return NuklearAPI.Group(
                name, 
                (NkPanelFlags)flags, 
                render
            );
        }

        public static bool Button(ButtonMode mode, string content)
        {
            return mode switch
            {
                ButtonMode.Label => NuklearAPI.ButtonLabel(content),
                ButtonMode.Text => NuklearAPI.ButtonLabel(content),
                _ => throw new NotSupportedException("Unsupported button mode.")
            };
        }

        public static void LabelWrapped(string text)
        {
            NuklearAPI.LabelWrap(text);
        }

        public static void LabelWrapped(string text, Color color)
        {
            NuklearAPI.LabelColoredWrap(
                text, 
                color.R, 
                color.G, 
                color.B, 
                color.A
            );
        }
        
        public static void Label(string text, TextAlignment textAlignment)
        {
            NuklearAPI.Label(
                text, 
                (NkTextAlign)textAlignment
            );
        }

        public static void Label(string text, TextAlignment textAlignment, Color color)
        {
            NuklearAPI.LabelColored(
                text,
                color.R,
                color.G,
                color.B,
                color.A,
                (NkTextAlign)textAlignment
            );
        }
    }
}