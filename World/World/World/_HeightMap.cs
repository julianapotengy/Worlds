using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    class _HeightMap
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer vBuffer;
        short[] indexes;
        IndexBuffer iBuffer;
        Effect effect;
        int row, column;
        Texture2D grassTexture, snowGrassTexture;
        public Texture2D heightMapTexture;
        Game game;
        Vector3 position;
        float counter;

        public _HeightMap(GraphicsDevice device, Game game, Vector3 position, Texture2D heightMapTexture, Texture2D grassTexture, Texture2D snowGrassTexture, int row, int column)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;
            this.position = position;

            this.row = row;
            this.column = column;

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

            this.effect = this.game.Content.Load<Effect>(@"Effects\snow-effect");

            this.heightMapTexture = heightMapTexture;
            this.grassTexture = grassTexture;
            this.snowGrassTexture = snowGrassTexture;

            Color[] colors = new Color[this.heightMapTexture.Width * this.heightMapTexture.Height];
            heightMapTexture.GetData<Color>(colors);

            this.verts = new VertexPositionTexture[this.row * this.column];

            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.column; j++)
                {
                    int aux = i * this.column + j;

                    float _i = i / (float)(this.row - 1);
                    float _j = j / (float)(this.column - 1);

                    int _iTex = (int)(_i * (heightMapTexture.Height - 1));
                    int _jTex = (int)(_j * (heightMapTexture.Width - 1));

                    int _auxTex = _iTex * heightMapTexture.Width + _jTex;

                    this.verts[aux] = new VertexPositionTexture(new Vector3(j - (this.column - 1) / 2f, colors[_auxTex].B / 10f, i - this.row / 2f), new Vector2(j / (float)(this.column - 1), i / (float)(this.row - 1)));
                }
            }

            this.vBuffer = new VertexBuffer(this.device,
                                           typeof(VertexPositionTexture),
                                           this.verts.Length,
                                           BufferUsage.None);
            this.vBuffer.SetData<VertexPositionTexture>(this.verts);

            this.world *= Matrix.CreateTranslation(this.position);
        }

        public void Update(GameTime gameTime, float counter)
        {
            this.counter = counter;
        }

        public void Draw(_Camera camera)
        {
            this.effect.CurrentTechnique = this.effect.Techniques["Technique1"];
            this.effect.Parameters["World"].SetValue(this.world);
            this.effect.Parameters["View"].SetValue(camera.GetView());
            this.effect.Parameters["Projection"].SetValue(camera.GetProjection());
            this.effect.Parameters["colorTexture"].SetValue(this.grassTexture);
            this.effect.Parameters["colorTextureSnow"].SetValue(this.snowGrassTexture);
            this.effect.Parameters["counter"].SetValue(counter);

            foreach (EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                this.device.DrawUserIndexedPrimitives(PrimitiveType.TriangleList,
                                                            this.verts,
                                                            0,
                                                            this.verts.Length,
                                                            this.indexes,
                                                            0,
                                                            this.indexes.Length / 3);
            }
        }
    }
}
