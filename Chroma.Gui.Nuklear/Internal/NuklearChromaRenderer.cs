using System;
using System.Collections.Generic;
using System.Drawing;
using Chroma.Graphics;
using Chroma.Gui.Nuklear.Internal.NuklearDotNet;

namespace Chroma.Gui.Nuklear.Internal
{
    internal class NuklearChromaRenderer : NuklearDeviceTex<Texture>
    {
        public Texture Texture { get; private set; }
        public Rectangle Scissor { get; private set; }

        public ushort VertexCount { get; private set; }
        public float[] VertexBuffer { get; private set; }
        public ushort[] IndexBuffer { get; private set; }

        internal override Texture CreateTexture(int width, int height, IntPtr data)
        {
            var texture = new Texture(width, height);

            unsafe
            {
                var span = new Span<byte>(data.ToPointer(), width * height * 4);
                texture.SetPixelData(span.ToArray());
            }

            texture.Flush();
            return texture;
        }

        internal override void Render(NkHandle udata, Texture texture, NkRect clipRect, uint offset, uint count)
        {
            Scissor = new Rectangle(
                (int)clipRect.X,
                (int)clipRect.Y,
                (int)clipRect.W,
                (int)clipRect.H
            );
            
            Texture = texture;
        }

        internal override void SetBuffer(NkVertex[] vertexBuffer, ushort[] indexBuffer)
        {
            var list = new List<float>();

            for (var i = 0; i < vertexBuffer.Length; i++)
            {
                list.Add(vertexBuffer[i].Position.X);
                list.Add(vertexBuffer[i].Position.Y);
                list.Add(vertexBuffer[i].UV.X);
                list.Add(vertexBuffer[i].UV.Y);
                list.Add(vertexBuffer[i].Color.R / 255f);
                list.Add(vertexBuffer[i].Color.G / 255f);
                list.Add(vertexBuffer[i].Color.B / 255f);
                list.Add(vertexBuffer[i].Color.A / 255f);
            }

            VertexCount = (ushort)vertexBuffer.Length;

            VertexBuffer = list.ToArray();
            IndexBuffer = indexBuffer;
        }
    }
}