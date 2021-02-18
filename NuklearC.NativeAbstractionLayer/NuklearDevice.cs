using System;
using System.Collections.Generic;
using NuklearC.Native.Types;

namespace NuklearC.NativeAbstractionLayer
{
    public abstract class NuklearDevice
    {
        public Queue<NuklearEvent> Events;

        public abstract void SetBuffer(nk_vertex[] VertexBuffer, ushort[] IndexBuffer);
        public abstract void Render(nk_handle userdata, int texture, nk_rect clipRect, uint offset, uint count);
        public abstract int CreateTextureHandle(int width, int height, IntPtr data);

        public NuklearDevice()
        {
            Events = new Queue<NuklearEvent>();
            ForceUpdate();
        }

        public virtual void Init()
        {
        }

        public virtual void FontStash(IntPtr atlas)
        {
        }

        public virtual void BeginRender()
        {
        }

        public virtual void EndRender()
        {
        }

        public void OnMouseButton(NuklearEvent.MouseButton button, int x, int y, bool isDown)
        {
            Events.Enqueue(new NuklearEvent
            {
                Type = NuklearEvent.EventType.MouseButton,
                Button = button,
                X = x,
                Y = y,
                IsDown = isDown
            });
        }

        public void OnMouseMove(int x, int y)
        {
            Events.Enqueue(new NuklearEvent
            {
                Type = NuklearEvent.EventType.MouseMove,
                X = x,
                Y = y
            });
        }

        public void OnScroll(float xScroll, float yScroll)
        {
            Events.Enqueue(new NuklearEvent
            {
                Type = NuklearEvent.EventType.Scroll,
                ScrollX = xScroll,
                ScrollY = yScroll
            });
        }

        public void OnText(string text)
        {
            Events.Enqueue(new NuklearEvent
            {
                Type = NuklearEvent.EventType.Text,
                Text = text
            });
        }

        public void OnKey(nk_keys Key, bool isDown)
        {
            Events.Enqueue(new NuklearEvent
            {
                Type = NuklearEvent.EventType.KeyboardKey,
                Key = Key,
                IsDown = isDown
            });
        }

        public void ForceUpdate()
        {
            Events.Enqueue(new NuklearEvent
            {
                Type = NuklearEvent.EventType.ForceUpdate
            });
        }
    }
}