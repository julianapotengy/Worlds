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
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color moinhosColor;

        protected Vector3 position;
        float angle;
        Texture2D texture;

        public _Moinhos(GraphicsDevice device, Vector3 position, float angle, Texture2D texture)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.moinhosColor = Color.Gray;
            this.position = position;
            this.angle = angle;
            this.texture = texture;

            this.verts = new VertexPositionTexture[]
            {
                // chao
                new VertexPositionTexture(new Vector3(1,0,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,0,-3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-1,0,3),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(1,0,-3),new Vector2(0, 1)), //v0
                new VertexPositionTexture(new Vector3(1,0,3),new Vector2(0, 0)),   //v1
                new VertexPositionTexture(new Vector3(-1,0,-3),new Vector2(1, 0)), //v2

                // parede esquerda - reto
                new VertexPositionTexture(new Vector3(-1,8,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,0,-3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-1,0,3),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(-1,8,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,8,0),new Vector2(0, 0)), //v1
                new VertexPositionTexture(new Vector3(-1,0,-3),new Vector2(1, 0)), //v2

                // parede direita - reto
                new VertexPositionTexture(new Vector3(1,8,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(1,0,-3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(1,0,3),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(1,8,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(1,8,0),new Vector2(0, 0)), //v1
                new VertexPositionTexture(new Vector3(1,0,-3),new Vector2(1, 0)), //v2

                // rampa
                new VertexPositionTexture(new Vector3(1,8,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(1,0,-3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-1,0,-3),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(1,8,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,8,0),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-1,0,-3),new Vector2(0, 0)), //v2

                // frente
                new VertexPositionTexture(new Vector3(1,8,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,8,3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(1,0,3),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(-1,0,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,8,3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(1,0,3),new Vector2(0, 0)), //v2

                // teto
                new VertexPositionTexture(new Vector3(1,8,3),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,8,3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(1,8,0),new Vector2(0, 0)), //v2

                new VertexPositionTexture(new Vector3(-1,8,0),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-1,8,3),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(1,8,0),new Vector2(0, 0)), //v2
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionColor), this.verts.Length, BufferUsage.None);
            //this.buffer.SetData<VertexPositionTexture>(this.verts);
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
            this.effect.TextureEnabled = true;
            this.effect.Texture = texture;

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
