using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    public class _Helice
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color heliceColor;

        protected Vector3 position;
        float angle;
        float speed;
        Random random;
        float rotateZ;

        public _Helice(GraphicsDevice device, Vector3 position, float angle)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.heliceColor = Color.SaddleBrown;
            this.position = position;
            this.angle = angle;
            this.random = new Random();
            this.speed = (random.Next(1, 5));
            this.rotateZ = 0;

            this.verts = new VertexPositionColor[]
            {
                // de cima
                new VertexPositionColor(new Vector3(0.5f,1f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-0.5f,1f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0,0,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(0.5f,1f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-0.5f,1f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0.5f,4,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(-0.5f,4f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-0.5f,1f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0.5f,4,0),heliceColor), //v2

                // de baixo
                new VertexPositionColor(new Vector3(0.5f,-1f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-0.5f,-1f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0,0,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(0.5f,-1f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-0.5f,-1f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0.5f,-4,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(-0.5f,-4f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-0.5f,-1f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0.5f,-4,0),heliceColor), //v2

                // esquerda
                new VertexPositionColor(new Vector3(-1f,0.5f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-1f,-0.5f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0,0,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(-1f,0.5f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-1f,-0.5f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(-4f,-0.5f,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(-1f,0.5f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(-4f,0.5f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(-4f,-0.5f,0),heliceColor), //v2

                // direita
                new VertexPositionColor(new Vector3(1f,0.5f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(1f,-0.5f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(0,0,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(1f,0.5f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(1f,-0.5f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(4f,-0.5f,0),heliceColor), //v2

                new VertexPositionColor(new Vector3(1f,0.5f,0),heliceColor),   //v0
                new VertexPositionColor(new Vector3(4f,0.5f,0),heliceColor), //v1
                new VertexPositionColor(new Vector3(4f,-0.5f,0),heliceColor), //v2
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionColor), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionColor>(this.verts);
            this.effect = new BasicEffect(this.device);
        }

        public void Update(GameTime gameTime)
        {
            this.rotateZ += gameTime.ElapsedGameTime.Milliseconds * (float)this.speed / 5f;

            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationZ(rotateZ);
            this.world *= Matrix.CreateRotationY(angle);
            this.world *= Matrix.CreateTranslation(this.position);
        }

        public void Draw(ref _Camera camera)
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
