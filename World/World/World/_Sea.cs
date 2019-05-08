using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    class _Sea
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        short[] index;
        IndexBuffer iBuffer;

        Vector3 position;
        Effect effect;
        Texture2D seaTexture;
        float angle, time;

        public _Sea(Texture2D seaTexture, GraphicsDevice device, Vector3 position, float angle, Effect seaEffect)
        {
            this.seaTexture = seaTexture;

            this.device = device;
            this.world = Matrix.Identity;
            this.position = position;
            this.angle = angle;
            this.effect = seaEffect;

            this.verts = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-200,0,200), Vector2.Zero),
                new VertexPositionTexture(new Vector3(200,0,200), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-200,0,-200), Vector2.UnitY),
                new VertexPositionTexture(new Vector3(200,0,-200), Vector2.One),
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionTexture), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);

            this.index = new short[]
            {
                0,1,2,
                1,3,2,
            };
            this.iBuffer = new IndexBuffer(this.device, IndexElementSize.SixteenBits, this.index.Length, BufferUsage.None);
            this.iBuffer.SetData<short>(this.index);
        }

        public void Update(GameTime gameTime)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateRotationX(angle);
            this.world *= Matrix.CreateTranslation(this.position);

            this.time += gameTime.ElapsedGameTime.Milliseconds * 0.001f * 4;
        }

        public void Draw(_Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);
            this.device.BlendState = BlendState.AlphaBlend;
            this.device.Indices = this.iBuffer;

            this.effect.CurrentTechnique = effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["time"].SetValue(this.time);
            this.effect.Parameters["colorTexture"].SetValue(seaTexture);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length, this.index, 0, 2);
            }
        }
    }
}
