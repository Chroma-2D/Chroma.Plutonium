using System;
using System.Collections.Generic;
using System.Drawing;
using Chroma.Graphics;
using NuklearC.NativeAbstractionLayer;
using NuklearC.Native.Types;

namespace Chroma.Plutonium.Internal
{
    public class NuklearChromaRenderer : NuklearDeviceTextured<Texture>
    {
        public Texture Texture { get; private set; }
        public Rectangle Scissor { get; private set; }

        public ushort VertexCount { get; private set; }
        public float[] VertexBuffer { get; private set; }
        public ushort[] IndexBuffer { get; private set; }

        public override Texture CreateTexture(int width, int height, IntPtr data)
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

        public override void Render(nk_handle udata, Texture texture, nk_rect clipRect, uint offset, uint count)
        {
            Scissor = clipRect;
            Texture = texture;
        }

        public override void SetBuffer(nk_vertex[] vertexBuffer, ushort[] indexBuffer)
        {
            var list = new List<float>();

            for (var i = 0; i < vertexBuffer.Length; i++)
            {
                list.Add(vertexBuffer[i].position.x);
                list.Add(vertexBuffer[i].position.y);
                list.Add(vertexBuffer[i].uv.x);
                list.Add(vertexBuffer[i].uv.y);
                list.Add(vertexBuffer[i].color.r / 255f);
                list.Add(vertexBuffer[i].color.g / 255f);
                list.Add(vertexBuffer[i].color.b / 255f);
                list.Add(vertexBuffer[i].color.a / 255f);
            }

            VertexCount = (ushort)vertexBuffer.Length;

            VertexBuffer = list.ToArray();
            IndexBuffer = indexBuffer;
        }
    }
}