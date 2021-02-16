using System.Collections.Generic;
using Chroma.Graphics;
using Chroma.Gui.Nuklear.Internal;
using Chroma.Gui.Nuklear.Internal.NuklearDotNet;
using Chroma.Input;

namespace Chroma.Gui.Nuklear
{
    public static class NuklearCore
    {
        private static Dictionary<KeyCode, NkKeys> _keyLookup = new()
        {
            {KeyCode.LeftShift, NkKeys.Shift},
            {KeyCode.RightShift, NkKeys.Shift},
            {KeyCode.LeftControl, NkKeys.Ctrl},
            {KeyCode.RightControl, NkKeys.Ctrl},
            {KeyCode.Delete, NkKeys.Del},
            {KeyCode.Up, NkKeys.Up},
            {KeyCode.Down, NkKeys.Down},
            {KeyCode.Left, NkKeys.Left},
            {KeyCode.Right, NkKeys.Right},
            {KeyCode.Return, NkKeys.Enter},
            {KeyCode.NumEnter, NkKeys.Enter},
            {KeyCode.Tab, NkKeys.Tab},
            {KeyCode.Backspace, NkKeys.Backspace},
        };

        private static Dictionary<MouseButton, NuklearEvent.MouseButton> _mbLookup = new()
        {
            {MouseButton.Left, NuklearEvent.MouseButton.Left},
            {MouseButton.Right, NuklearEvent.MouseButton.Right},
            {MouseButton.Middle, NuklearEvent.MouseButton.Middle}
        };

        private static NuklearChromaRenderer _renderer;

        public static void Initialize()
        {
            _renderer = new NuklearChromaRenderer();
            NuklearAPI.Init(_renderer);
            
            NuklearAPI.SetClipboardCallback(
                (s) => { Clipboard.Text = s; },
                () => Clipboard.Text
            );
        }

        public static void Draw(RenderContext context)
        {
            var previousScissor = RenderSettings.Scissor;
            RenderSettings.Scissor = _renderer.Scissor;

            context.RenderArbitraryGeometry(
                _renderer.Texture,
                VertexFormat.XYSTRGBA,
                _renderer.VertexCount,
                _renderer.VertexBuffer,
                _renderer.IndexBuffer
            );

            RenderSettings.Scissor = previousScissor;
        }

        public static void Update(float delta)
        {
            NuklearAPI.SetDeltaTime(delta);
        }

        public static void MousePressed(MouseButtonEventArgs e)
        {
            if (_mbLookup.ContainsKey(e.Button))
            {
                _renderer.OnMouseButton(
                    _mbLookup[e.Button],
                    (int)e.Position.X,
                    (int)e.Position.Y,
                    true
                );
            }
        }

        public static void MouseReleased(MouseButtonEventArgs e)
        {
            if (_mbLookup.ContainsKey(e.Button))
            {
                _renderer.OnMouseButton(
                    _mbLookup[e.Button],
                    (int)e.Position.X,
                    (int)e.Position.Y,
                    false
                );
            }
        }

        public static void MouseMoved(MouseMoveEventArgs e)
        {
            _renderer.OnMouseMove(
                (int)e.Position.X,
                (int)e.Position.Y
            );
        }

        public static void WheelMoved(MouseWheelEventArgs e)
        {
            _renderer.OnScroll(
                e.Motion.X,
                e.Motion.Y
            );
        }

        public static void TextInput(TextInputEventArgs e)
        {
            _renderer.OnText(e.Text);
        }

        public static void KeyPressed(KeyEventArgs e)
        {
            if (_keyLookup.ContainsKey(e.KeyCode))
            {
                _renderer.OnKey(_keyLookup[e.KeyCode], true);
            }
        }

        public static void KeyReleased(KeyEventArgs e)
        {
            if (_keyLookup.ContainsKey(e.KeyCode))
            {
                _renderer.OnKey(_keyLookup[e.KeyCode], false);
            }
        }
    }
}