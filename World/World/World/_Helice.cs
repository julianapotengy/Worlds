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
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        Color heliceColor;

        protected Vector3 position;
        float angle;
        float speed;
        Random random;
        float rotateZ;
        Texture2D texture;
        Texture2D snowTexture;

        Effect effect;
        float counter;

        public _Helice(GraphicsDevice device, Vector3 position, float angle, Texture2D texture, Effect effect, Texture2D snowTexture)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.heliceColor = Color.SaddleBrown;
            this.position = position;
            this.angle = angle;
            this.random = new Random();
            this.speed = (random.Next(1, 5));
            this.rotateZ = 0;
            this.texture = texture;
            this.snowTexture = snowTexture;
            this.effect = effect;

            this.verts = new VertexPositionTexture[]
            {
                // de cima
                new VertexPositionTexture(new Vector3(0.5f,1f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.5f,1f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0,0,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(0.5f,1f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.5f,1f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0.5f,4,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(-0.5f,4f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.5f,1f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0.5f,4,0),new Vector2(0, 0)), //v2

                // de baixo
                new VertexPositionTexture(new Vector3(0.5f,-1f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.5f,-1f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0,0,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(0.5f,-1f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.5f,-1f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0.5f,-4,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(-0.5f,-4f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.5f,-1f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0.5f,-4,0),new Vector2(0, 0)), //v2

                // esquerda
                new VertexPositionTexture(new Vector3(-1f,0.5f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1f,-0.5f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0,0,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(-1f,0.5f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1f,-0.5f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-4f,-0.5f,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(-1f,0.5f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-4f,0.5f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-4f,-0.5f,0),new Vector2(0, 0)), //v2

                // direita
                new VertexPositionTexture(new Vector3(1f,0.5f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(1f,-0.5f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0,0,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(1f,0.5f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(1f,-0.5f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(4f,-0.5f,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(1f,0.5f,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(4f,0.5f,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(4f,-0.5f,0),new Vector2(0, 0)), //v2
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionTexture), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);
        }

        public void Update(GameTime gameTime, float counter)
        {
            this.rotateZ += gameTime.ElapsedGameTime.Milliseconds * (float)this.speed / 5f;

            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationZ(rotateZ);
            this.world *= Matrix.CreateRotationY(angle);
            this.world *= Matrix.CreateTranslation(this.position);

            this.counter = counter;
        }

        public void Draw(ref _Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(world);
            effect.Parameters["View"].SetValue(camera.GetView());
            effect.Parameters["Projection"].SetValue(camera.GetProjection());
            effect.Parameters["colorTexture"].SetValue(texture);
            effect.Parameters["colorTextureSnow"].SetValue(this.snowTexture);
            effect.Parameters["counter"].SetValue(counter);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
