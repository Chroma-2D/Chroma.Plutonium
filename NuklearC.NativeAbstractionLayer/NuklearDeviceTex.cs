using System;
using System.Collections.Generic;
using NuklearC.Native.Types;

namespace NuklearC.NativeAbstractionLayer
{
    public abstract class NuklearDeviceTextured<T> : NuklearDevice
    {
        private List<T> Textures;

        public NuklearDeviceTextured()
        {
            Textures = new List<T>();
            Textures.Add(default); // Start indices at 1
        }

        public int CreateTextureHandle(T texture)
        {
            Textures.Add(texture);
            return Textures.Count - 1;
        }

        public T GetTexture(int handle)
        {
            return Textures[handle];
        }

        public sealed override int CreateTextureHandle(int width, int height, IntPtr data)
        {
            var texture = CreateTexture(width, height, data);
            return CreateTextureHandle(texture);
        }

        public sealed override void Render(
            nk_handle userdata, 
            int texture, 
            nk_rect clipRect,
            uint offset,
            uint count) =>
            Render(userdata, GetTexture(texture), clipRect, offset, count);

        public abstract T CreateTexture(int width, int height, IntPtr data);
        public abstract void Render(nk_handle userdata, T Texture, nk_rect clipRect, uint offset, uint count);
    }
}