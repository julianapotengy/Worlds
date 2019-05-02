using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace World
{
    class _TreeManager
    {
        GraphicsDevice device;
        Matrix world;
        Game game;
        float x, z, counter;
        Texture2D treeTexture, snowTreeTexture;
        Effect effect;

        List<_Tree> treeList = new List<_Tree>();
        int column, line;
        _Camera camera;
        Vector3 position;

        public _TreeManager(GraphicsDevice device, Game game, _Camera camera, Vector3 position, int column, int line, Texture2D treeTexture, Effect effect, Texture2D snowTreeTexture)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.game = game;
            this.treeTexture = treeTexture;
            this.snowTreeTexture = snowTreeTexture;
            this.effect = effect;
            this.column = column;
            this.line = line;
            this.camera = camera;
            this.position = position;

            for (int c = 0; c < column; c++)
            {
                for (int l = 0; l < line; l++)
                {
                    x = 20 - c * 4;
                    z = -3 - l * 7;
                    treeList.Add(new _Tree(device, new Vector3(x, 2, z), game, camera, treeTexture, effect, snowTreeTexture));
                }
            }
        }

        public void Update(GameTime gameTime, float counter)
        {
            this.world = Matrix.Identity;
            this.world *= Matrix.CreateTranslation(this.position);
            this.counter = counter;

            foreach (_Tree t in treeList)
            {
                t.Update(gameTime, counter);
            }

            BubbleSort();
        }

        public void BubbleSort()
        {
            for (int i = 0; i < treeList.Count; i++)
            {
                for (int j = 0; j < treeList.Count - 1; j++)
                {
                    if (treeList[i].disCamera > treeList[j].disCamera)
                    {
                        _Tree aux = treeList[i];
                        treeList[i] = treeList[j];
                        treeList[j] = aux;
                    }
                }
            }
        }

        public void Draw(_Camera camera)
        {
            foreach(_Tree t in treeList)
            {
                t.Draw(camera);
            }
        }
    }
}
