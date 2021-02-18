using NuklearC.Native.Types;

namespace NuklearC.NativeAbstractionLayer
{
    public struct NuklearEvent
    {
        public EventType Type;
        public MouseButton Button;
        
        public nk_keys Key;
        public int X, Y;
        public bool Down;
        public float ScrollX, ScrollY;
        public string Text;
        
        public enum EventType
        {
            MouseButton,
            MouseMove,
            Scroll,
            Text,
            KeyboardKey,
            ForceUpdate
        }

        public enum MouseButton
        {
            Left,
            Middle,
            Right
        }
    }
}