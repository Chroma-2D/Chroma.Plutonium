using System;
using Chroma;
using Chroma.Graphics;
using Chroma.Plutonium;
using Chroma.Input;

namespace NuklearExample
{
    public class GameCore : Game
    {
        private string _buttonText = "Be gentle, please.";
        
        protected override void LoadContent()
        {
            NuklearCore.Initialize();
        }

        protected override void Update(float delta)
        {
            NuklearCore.Update(delta);
        }

        protected override void Draw(RenderContext context)
        {
            NuklearCore.Begin(() =>
            {
                NuklearGui.Window(
                    "NuklearGUI for Chroma",
                    new(100, 100),
                    new(200, 200),
                    PanelFlags.Border
                    | PanelFlags.Title
                    | PanelFlags.Background
                    | PanelFlags.MovableScalable,
                    () =>
                    {
                        NuklearGui.DynamicRowLayout(35);

                        if (NuklearGui.Button(ButtonMode.Label, _buttonText))
                        {
                            _buttonText = "Ouch!";
                        }
                    }
                );
            });

            NuklearCore.Draw(context);
        }

        protected override void KeyPressed(KeyEventArgs e)
            => NuklearCore.KeyPressed(e);

        protected override void KeyReleased(KeyEventArgs e)
            => NuklearCore.KeyReleased(e);

        protected override void MouseMoved(MouseMoveEventArgs e)
            => NuklearCore.MouseMoved(e);

        protected override void WheelMoved(MouseWheelEventArgs e)
            => NuklearCore.WheelMoved(e);

        protected override void MousePressed(MouseButtonEventArgs e)
            => NuklearCore.MousePressed(e);

        protected override void MouseReleased(MouseButtonEventArgs e)
            => NuklearCore.MouseReleased(e);

        protected override void TextInput(TextInputEventArgs e)
            => NuklearCore.TextInput(e);
    }
}