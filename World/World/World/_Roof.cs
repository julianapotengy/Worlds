using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    public class _Roof
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color roofColor;

        public _Roof(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;
            roofColor = Color.SaddleBrown;

            this.verts = new VertexPositionColor[]
            {
                // telhado
                new VertexPositionColor(new Vector3(-2.3f,4,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(2.3f,4,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(-2.3f,4,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4,-3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(-2.3f,4,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4.3f,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(2.3f,4.3f,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4.3f,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(-2.3f,4,-3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4.3f,-3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(2.3f,4.3f,-3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4.3f,-3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(2.3f,4.3f,-3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(2.3f,4.3f,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(2.3f,4f,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(2.3f,4.3f,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(-2.3f,4.3f,-3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4.3f,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(-2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(-2.3f,4f,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4.3f,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(-2.3f,4,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(-2.3f,4.3f,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(2.3f,4.3f,3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4.3f,-3.3f),roofColor),  //v2

                new VertexPositionColor(new Vector3(-2.3f,4.3f,3.3f),roofColor),   //v0
                new VertexPositionColor(new Vector3(-2.3f,4.3f,-3.3f),roofColor),  //v1
                new VertexPositionColor(new Vector3(2.3f,4.3f,-3.3f),roofColor),  //v2
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
