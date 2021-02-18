using System.Collections.Generic;
using Chroma.Graphics;
using Chroma.Input;
using Chroma.Plutonium.Internal;
using NuklearC.NativeAbstractionLayer;
using NuklearC.Native.Types;

namespace Chroma.Plutonium
{
    public static class NuklearCore
    {
        private static Dictionary<KeyCode, nk_keys> _keyLookup = new()
        {
            {KeyCode.LeftShift, nk_keys.Shift},
            {KeyCode.RightShift, nk_keys.Shift},
            {KeyCode.LeftControl, nk_keys.Ctrl},
            {KeyCode.RightControl, nk_keys.Ctrl},
            {KeyCode.Delete, nk_keys.Del},
            {KeyCode.Up, nk_keys.Up},
            {KeyCode.Down, nk_keys.Down},
            {KeyCode.Left, nk_keys.Left},
            {KeyCode.Right, nk_keys.Right},
            {KeyCode.Return, nk_keys.Enter},
            {KeyCode.NumEnter, nk_keys.Enter},
            {KeyCode.Tab, nk_keys.Tab},
            {KeyCode.Backspace, nk_keys.Backspace},
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