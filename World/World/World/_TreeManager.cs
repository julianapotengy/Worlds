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
        Game game;
        float x, z, counter;
        Texture2D treeTexture, snowTreeTexture;
        Effect effect;

        List<_Tree> treeList = new List<_Tree>();

        public _TreeManager(GraphicsDevice device, Game game, _Camera camera, int column, int line, Texture2D treeTexture, Effect effect, Texture2D snowTreeTexture)
        {
            this.device = device;
            this.game = game;
            this.treeTexture = treeTexture;
            this.snowTreeTexture = snowTreeTexture;
            this.effect = effect;

            for (int c = 0; c < column; c++)
            {
                for (int l = 0; l < line; l++)
                {
                    x = 18 - c * 4;
                    z = -20 - l * 7;
                    treeList.Add(new _Tree(device, new Vector3(x, 2, z), game, camera, treeTexture, effect, snowTreeTexture));
                }
            }
        }

        public void Update(GameTime gameTime, float counter)
        {
            this.counter = counter;

            for (int i = 0; i < treeList.Count; i++)
            {
                treeList[i].Update(gameTime, counter);
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
