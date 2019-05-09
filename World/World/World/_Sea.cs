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
        short[] indexes;
        IndexBuffer iBuffer;

        Vector3 position;
        Effect effect;
        Texture2D seaTexture;
        float angle, time;

        int row, column;

        public _Sea(Texture2D seaTexture, GraphicsDevice device, Vector3 position, float angle, Effect seaEffect)
        {
            this.seaTexture = seaTexture;

            this.device = device;
            this.world = Matrix.Identity;
            this.position = position;
            this.angle = angle;
            this.effect = seaEffect;
            row = 150;
            column = 150;

            this.world = Matrix.Identity;
            this.world = Matrix.CreateRotationX(angle);
            this.world *= Matrix.CreateScale(40);
            this.world *= Matrix.CreateTranslation(this.position);

            this.indexes = new short[(this.row - 1) * (this.column - 1) * 2 * 3];

            int k = 0;
            for (int i = 0; i < row - 1; i++)
            {
                for (short j = 0; j < this.column - 1; j++)
                {
                    this.indexes[k++] = (short)(i * this.column + j);
                    this.indexes[k++] = (short)(i * this.column + (j + 1));
                    this.indexes[k++] = (short)((i + 1) * this.column + j);

                    this.indexes[k++] = (short)(i * this.column + j + 1);
                    this.indexes[k++] = (short)((i + 1) * this.column + (j + 1));
                    this.indexes[k++] = (short)((i + 1) * this.column + j);
                }
            }

            this.iBuffer = new IndexBuffer(this.device, IndexElementSize.SixteenBits, this.indexes.Length, BufferUsage.None);
            this.iBuffer.SetData<short>(this.indexes);

            this.verts = new VertexPositionTexture[this.row * this.column];

            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    this.verts[i * this.column + j] = new VertexPositionTexture(new Vector3((j - this.column / 2f) / 10f, (-i + this.row / 2f) / 10f, 0),
                                                                                new Vector2(j / (float)(this.column - 1), i / (float)(this.row - 1)));
                }
            }

            this.buffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);
        }

        public void Update(GameTime gameTime)
        {

            this.time += gameTime.ElapsedGameTime.Milliseconds * 0.001f * 2;
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
                //device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length, this.index, 0, 2);
                device.DrawUserIndexedPrimitives<VertexPositionTexture>(PrimitiveType.TriangleList, this.verts, 0, verts.Length, this.indexes, 0, this.indexes.Length / 3);
            }
        }
    }
}
