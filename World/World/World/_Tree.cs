using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    class _Tree
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        short[] index;
        IndexBuffer iBuffer;

        Vector3 position;
        Texture2D texture;
        Texture2D snowTexture;
        Effect effect;
        _Camera camera;
        float counter, time, disCamera;

        public _Tree(GraphicsDevice device, Vector3 position, Game game, _Camera camera, Texture2D texture, Effect effect, Texture2D snowTexture)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.position = position;
            this.texture = texture;
            this.snowTexture = snowTexture;
            this.effect = effect;
            this.camera = camera;

            this.verts = new VertexPositionTexture[]
            {
                new VertexPositionTexture(new Vector3(-2,2,0), Vector2.Zero),
                new VertexPositionTexture(new Vector3( 2,2,0), Vector2.UnitX),
                new VertexPositionTexture(new Vector3(-2,-2,0), Vector2.UnitY),
                new VertexPositionTexture(new Vector3( 2,-2,0), Vector2.One),
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

        public void Update(GameTime gameTime, float counter)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateConstrainedBillboard(this.position, camera.GetPosition(), Vector3.Up, new Nullable<Vector3>(), new Nullable<Vector3>());
            time = 0.05f * gameTime.ElapsedGameTime.Milliseconds;

            disCamera = Vector3.Distance(this.position, camera.GetPosition());

            this.counter = counter;
        }

        public void Draw(_Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);
            this.device.BlendState = BlendState.AlphaBlend;
            this.device.Indices = this.iBuffer;

            effect.CurrentTechnique = effect.Techniques["Technique1"];
            effect.Parameters["World"].SetValue(world);
            effect.Parameters["View"].SetValue(camera.GetView());
            effect.Parameters["Projection"].SetValue(camera.GetProjection());
            effect.Parameters["colorTexture"].SetValue(texture);
            effect.Parameters["colorTextureSnow"].SetValue(snowTexture);
            effect.Parameters["counter"].SetValue(counter);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length, this.index, 0, 2);
            }
        }
    }
}
