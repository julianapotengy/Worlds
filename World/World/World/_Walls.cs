using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    public class _Walls
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color wallColor;

        public _Walls(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;
            wallColor = Color.Beige;

            this.verts = new VertexPositionColor[]
            {
                // chao
                new VertexPositionColor(new Vector3(-2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,0,3f),wallColor),  //v1
                new VertexPositionColor(new Vector3(2f,0,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,0,-3f),wallColor),  //v1
                new VertexPositionColor(new Vector3(2f,0,-3f),wallColor),  //v2

                // parede da frente
                new VertexPositionColor(new Vector3(-2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-0.7f,3,3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,3,3f),wallColor),  //v2
                
                new VertexPositionColor(new Vector3(-2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-0.7f,3,3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-0.7f,0,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(0.7f,3,3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,3,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(0.7f,3,3f),wallColor), //v1
                new VertexPositionColor(new Vector3(0.7f,0,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,3,3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,4,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,4,3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,4,3f),wallColor),  //v2

                // parede da esquerda

                new VertexPositionColor(new Vector3(-2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,4,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,4,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,4,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,3,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,4,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,4,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,2f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,1.5f,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,2f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,2f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,3f,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,1f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,0f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,1.5f,1f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,0f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,0f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,3f,1f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-2f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,1.5f,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,-2f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-2f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,3f,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,0,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,1.5f,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,1.5f,3f),wallColor),  //v2

                // parede de tras
                new VertexPositionColor(new Vector3(-2f,0,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-0.7f,3,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,3,-3f),wallColor),  //v2
                
                new VertexPositionColor(new Vector3(-2f,0,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-0.7f,3,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-0.7f,0,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,0,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(0.7f,3,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,3,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,0,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(0.7f,3,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(0.7f,0,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,3,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,4,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,3,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,4,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(-2f,4,-3f),wallColor),  //v2

                // parede da direita

                new VertexPositionColor(new Vector3(2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,4,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,4,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,4,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,3,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,4,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,4,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,2f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,1.5f,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,2f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,2f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,3f,3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,1f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,0f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,1.5f,1f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,0f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,0f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,3f,1f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,-3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-2f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,1.5f,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,3,-2f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-2f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,3f,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,0,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(2f,0,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,1.5f,-3f),wallColor), //v1
                new VertexPositionColor(new Vector3(2f,1.5f,3f),wallColor),  //v2

                // teto
                new VertexPositionColor(new Vector3(-2f,4,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(2f,4,3f),wallColor),  //v1
                new VertexPositionColor(new Vector3(2f,4,-3f),wallColor),  //v2

                new VertexPositionColor(new Vector3(-2f,4,3f),wallColor),   //v0
                new VertexPositionColor(new Vector3(-2f,4,-3f),wallColor),  //v1
                new VertexPositionColor(new Vector3(2f,4,-3f),wallColor),  //v2
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
