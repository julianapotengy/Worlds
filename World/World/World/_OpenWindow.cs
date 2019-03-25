using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    public class _OpenWindow
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color windowColor;

        public _OpenWindow(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;
            windowColor = Color.SandyBrown;

            this.verts = new VertexPositionColor[]
            {
                // slider window - esquerda - 1
                new VertexPositionColor(new Vector3(-2f,3,-1f),windowColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-2f),windowColor), //v1
                new VertexPositionColor(new Vector3(-2f,1.5f,-1f),windowColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,-1f),windowColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-2f),windowColor), //v1
                new VertexPositionColor(new Vector3(-2f,3f,-2f),windowColor),  //v2

                // esquerda - 1
                new VertexPositionColor(new Vector3(-2f,3,0f),windowColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-1f),windowColor), //v1
                new VertexPositionColor(new Vector3(-2f,3f,-1f),windowColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,0f),windowColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-1f),windowColor), //v1
                new VertexPositionColor(new Vector3(-2f,1.5f,0f),windowColor),  //v2

                // slider window - direita - 1
                new VertexPositionColor(new Vector3(2f,3,-1f),windowColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-2f),windowColor), //v1
                new VertexPositionColor(new Vector3(2f,1.5f,-1f),windowColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,-1f),windowColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-2f),windowColor), //v1
                new VertexPositionColor(new Vector3(2f,3f,-2f),windowColor),  //v2

                // direita - 1
                new VertexPositionColor(new Vector3(2f,3,0f),windowColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-1f),windowColor), //v1
                new VertexPositionColor(new Vector3(2f,3f,-1f),windowColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,0f),windowColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-1f),windowColor), //v1
                new VertexPositionColor(new Vector3(2f,1.5f,0f),windowColor),  //v2
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionColor), this.verts.Length, BufferUsage.None);
            this.effect = new BasicEffect(this.device);
        }

        public VertexPositionColor MakeTriangle(Vector3 pos, Color color)
        {
            return new VertexPositionColor(pos, color);
        }

        public void Draw(_Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.VertexColorEnabled = true;

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
