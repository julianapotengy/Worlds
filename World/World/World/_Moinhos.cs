using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    public class _Moinhos
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color moinhosColor;

        protected Vector3 position;
        float angle;

        public _Moinhos(GraphicsDevice device, Vector3 position, float angle)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.moinhosColor = Color.Gray;
            this.position = position;
            this.angle = angle;

            this.verts = new VertexPositionColor[]
            {
                // chao
                new VertexPositionColor(new Vector3(1,0,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,0,-3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(-1,0,3),moinhosColor), //v2
                new VertexPositionColor(new Vector3(1,0,-3),moinhosColor), //v0
                new VertexPositionColor(new Vector3(1,0,3),moinhosColor),   //v1
                new VertexPositionColor(new Vector3(-1,0,-3),moinhosColor), //v2

                // parede esquerda - reto
                new VertexPositionColor(new Vector3(-1,8,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,0,-3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(-1,0,3),moinhosColor), //v2

                new VertexPositionColor(new Vector3(-1,8,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,8,0),moinhosColor), //v1
                new VertexPositionColor(new Vector3(-1,0,-3),moinhosColor), //v2

                // parede direita - reto
                new VertexPositionColor(new Vector3(1,8,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(1,0,-3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(1,0,3),moinhosColor), //v2

                new VertexPositionColor(new Vector3(1,8,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(1,8,0),moinhosColor), //v1
                new VertexPositionColor(new Vector3(1,0,-3),moinhosColor), //v2

                // rampa
                new VertexPositionColor(new Vector3(1,8,0),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(1,0,-3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(-1,0,-3),moinhosColor), //v2

                new VertexPositionColor(new Vector3(1,8,0),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,8,0),moinhosColor), //v1
                new VertexPositionColor(new Vector3(-1,0,-3),moinhosColor), //v2

                // frente
                new VertexPositionColor(new Vector3(1,8,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,8,3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(1,0,3),moinhosColor), //v2

                new VertexPositionColor(new Vector3(-1,0,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,8,3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(1,0,3),moinhosColor), //v2

                // teto
                new VertexPositionColor(new Vector3(1,8,3),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,8,3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(1,8,0),moinhosColor), //v2

                new VertexPositionColor(new Vector3(-1,8,0),moinhosColor),   //v0
                new VertexPositionColor(new Vector3(-1,8,3),moinhosColor), //v1
                new VertexPositionColor(new Vector3(1,8,0),moinhosColor), //v2
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionColor), this.verts.Length, BufferUsage.None);
            this.effect = new BasicEffect(this.device);
        }

        public void Update(GameTime gameTime)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationY(angle);
            this.world *= Matrix.CreateTranslation(this.position);
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
