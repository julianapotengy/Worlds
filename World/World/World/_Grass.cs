using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    public class _Grass
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color grassColor;

        protected Vector3 position;
        private float angle;
        Texture2D texture;

        public _Grass(GraphicsDevice device, Vector3 position, float angle, Texture2D texture)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.grassColor = Color.Green;
            this.position = position;
            this.angle = angle;
            this.texture = texture;

            this.verts = new VertexPositionTexture[]
            {
                // grass
                new VertexPositionTexture(new Vector3(-20, 0,-20),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(20,0,20),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-20,0,20),new Vector2(0, 0)),  //v2
                
                new VertexPositionTexture(new Vector3(20,0,-20),new Vector2(0, 0)), //v0
                new VertexPositionTexture(new Vector3(20,0,20),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-20,0,-20),new Vector2(0, 1)),  //v2
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionTexture), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);
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

            foreach(EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.device.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
