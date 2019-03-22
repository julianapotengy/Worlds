using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace World
{
    public class _Screen
    {
        private int width;
        private int height;
        private static _Screen instance;

        private _Screen()
        {

        }

        public static _Screen GetInstance()
        {
            if(instance == null)
            {
                instance = new _Screen();
            }

            return instance;
        }

        public void SetWidth(int w)
        {
            width = w;
        }

        public int GetWidth()
        {
            return width;
        }

        public void SetHeight(int h)
        {
            height = h;
        }

        public int GetHeight()
        {
            return height;
        }
    }
}
