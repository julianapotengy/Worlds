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
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        Color wallColor;

        protected Vector3 position;
        private float angle;
        Texture2D texture;
        Texture2D snowTexture;

        Effect effect;
        float counter;

        public _Walls(GraphicsDevice device, Vector3 position, float angle, Texture2D texture, Effect effect, Texture2D snowTexture)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.wallColor = Color.Beige;
            this.position = position;
            this.angle = angle;
            this.texture = texture;
            this.snowTexture = snowTexture;
            this.effect = effect;

            this.verts = new VertexPositionTexture[]
            {
                // chao
                new VertexPositionTexture(new Vector3(-2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,0,3f),new Vector2(1, 0)),  //v1
                new VertexPositionTexture(new Vector3(2f,0,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,0,-3f),new Vector2(0, 0)),  //v1
                new VertexPositionTexture(new Vector3(2f,0,-3f),new Vector2(1, 0)),  //v2

                // parede da frente
                new VertexPositionTexture(new Vector3(-2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.7f,3,3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3,3f),new Vector2(0, 0)),  //v2
                
                new VertexPositionTexture(new Vector3(-2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.7f,3,3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-0.7f,0,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(0.7f,3,3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(0.7f,3,3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0.7f,0,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,3,3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,4,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,3f),new Vector2(1, 0)),   //v0
                new VertexPositionTexture(new Vector3(2f,4,3f),new Vector2(0, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,4,3f),new Vector2(0, 1)),  //v2

                // parede da esquerda

                new VertexPositionTexture(new Vector3(-2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,4,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,4,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,4,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,4,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,4,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,1.5f,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,2f),new Vector2(0, 0)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3f,3f),new Vector2(0, 1)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,1f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,0f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,1.5f,1f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,0f),new Vector2(0, 0)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,0f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3f,1f),new Vector2(0, 1)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,-3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,1.5f,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,-2f),new Vector2(0, 0)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3f,-3f),new Vector2(0, 1)),  //v2

                new VertexPositionTexture(new Vector3(-2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,0,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,0,3f),new Vector2(0, 0)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,1.5f,3f),new Vector2(0, 1)),  //v2

                // parede de tras
                new VertexPositionTexture(new Vector3(-2f,0,-3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.7f,3,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3,-3f),new Vector2(0, 0)),  //v2
                
                new VertexPositionTexture(new Vector3(-2f,0,-3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-0.7f,3,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-0.7f,0,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,0,-3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(0.7f,3,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,0,-3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(0.7f,3,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(0.7f,0,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,-3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,3,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,4,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,-3f),new Vector2(1, 0)),   //v0
                new VertexPositionTexture(new Vector3(2f,4,-3f),new Vector2(0, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,4,-3f),new Vector2(0, 1)),  //v2

                // parede da direita

                new VertexPositionTexture(new Vector3(2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,4,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,4,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,4,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,4,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,4,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,1.5f,3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,2f),new Vector2(0, 0)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3f,3f),new Vector2(0, 1)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,1f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,0f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,1.5f,1f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,0f),new Vector2(0, 0)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,0f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3f,1f),new Vector2(0, 1)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,-3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,1.5f,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,-2f),new Vector2(0, 0)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3f,-3f),new Vector2(0, 1)),  //v2

                new VertexPositionTexture(new Vector3(2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,0,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,0,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-3f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,1.5f,3f),new Vector2(0, 0)),  //v2

                // teto
                new VertexPositionTexture(new Vector3(-2f,4,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,4,3f),new Vector2(1, 0)),  //v1
                new VertexPositionTexture(new Vector3(2f,4,-3f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,4,3f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,4,-3f),new Vector2(1, 0)),  //v1
                new VertexPositionTexture(new Vector3(2f,4,-3f),new Vector2(0, 0)),  //v2
                };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionTexture), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);
        }

        public void Update(GameTime gameTime, float counter)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationY(angle);
            this.world *= Matrix.CreateTranslation(this.position);

            this.counter = counter;
        }

        public void Draw(_Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(this.world);
            effect.Parameters["View"].SetValue(camera.GetView());
            effect.Parameters["Projection"].SetValue(camera.GetProjection());
            effect.Parameters["colorTexture"].SetValue(this.texture);
            effect.Parameters["colorTextureSnow"].SetValue(this.snowTexture);
            effect.Parameters["counter"].SetValue(this.counter);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
