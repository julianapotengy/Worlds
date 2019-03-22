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
        VertexPositionColor[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color wallColor;
        Color grassColor;
        Color windowColor1;
        Color windowColor2;

        public _Walls(GraphicsDevice device)
        {
            this.device = device;
            this.world = Matrix.Identity;
            wallColor = Color.Beige;
            grassColor = Color.Green;
            windowColor1 = Color.SandyBrown;
            windowColor2 = Color.RosyBrown;

            this.verts = new VertexPositionColor[]
            {
                // grass
                MakeTriangle(new Vector3(2,-0.2f,0), grassColor),
                MakeTriangle(new Vector3(0,-1,2), grassColor),
                MakeTriangle(new Vector3(0,1,-2), grassColor),
                MakeTriangle(new Vector3(0,1,-2), grassColor),
                MakeTriangle(new Vector3(0,-1,2), grassColor),
                MakeTriangle(new Vector3(-2,-0.2f,0), grassColor),

                // wall 1
                MakeTriangle(new Vector3(0,1f,-1), wallColor), 
                MakeTriangle(new Vector3(1.2f,-0.1f,0), wallColor), // chao
                MakeTriangle(new Vector3(0,0.5f,-1), wallColor), // chao
                MakeTriangle(new Vector3(0,1f,-1), wallColor),
                MakeTriangle(new Vector3(1.2f,0.35f,0), wallColor),
                MakeTriangle(new Vector3(1.2f,-0.1f,0), wallColor),
                
                MakeTriangle(new Vector3(0,1f,-1), wallColor),
                MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(0.2f,1.2f,0), wallColor),
                MakeTriangle(new Vector3(0.2f,1.2f,0), wallColor),
                MakeTriangle(new Vector3(0.2f,0.75f,0), wallColor),
                MakeTriangle(new Vector3(0,1f,-1), wallColor),

                MakeTriangle(new Vector3(0.2f,0.75f,0), windowColor1),
                MakeTriangle(new Vector3(0.2f,1.2f,0), windowColor1),
                MakeTriangle(new Vector3(0.4f,0.67f,0), windowColor1),
                MakeTriangle(new Vector3(0.4f,0.67f,0), windowColor1),
                MakeTriangle(new Vector3(0.2f,1.2f,0), windowColor1),
                MakeTriangle(new Vector3(0.4f,1.14f,0), windowColor1),

                // w2
                MakeTriangle(new Vector3(0.6f,1.08f,0), windowColor2),
                MakeTriangle(new Vector3(0.4f,0.67f,0), windowColor2),
                MakeTriangle(new Vector3(0.4f,1.14f,0), windowColor2),
                MakeTriangle(new Vector3(0.6f,0.59f,0), windowColor2),
                MakeTriangle(new Vector3(0.4f,0.67f,0), windowColor2),
                MakeTriangle(new Vector3(0.6f,1.08f,0), windowColor2),

                MakeTriangle(new Vector3(0.8f,0.51f,0), wallColor),
                MakeTriangle(new Vector3(0.6f,0.59f,0), wallColor),
                MakeTriangle(new Vector3(0.6f,1.08f,0), wallColor),
                MakeTriangle(new Vector3(0.8f,0.51f,0), wallColor),
                MakeTriangle(new Vector3(0.6f,1.08f,0), wallColor),
                MakeTriangle(new Vector3(0.8f,1.02f,0), wallColor),

                // w1
                MakeTriangle(new Vector3(1f,0.96f,0), windowColor1),
                MakeTriangle(new Vector3(0.8f,0.51f,0), windowColor1),
                MakeTriangle(new Vector3(0.8f,1.02f,0), windowColor1),
                MakeTriangle(new Vector3(0.8f,0.51f,0), windowColor1),
                MakeTriangle(new Vector3(1f,0.96f,0), windowColor1),
                MakeTriangle(new Vector3(1f,0.43f,0), windowColor1),

                MakeTriangle(new Vector3(1f,0.96f,0), wallColor),
                MakeTriangle(new Vector3(1.2f,0.35f,0), wallColor),
                MakeTriangle(new Vector3(1f,0.43f,0), wallColor),
                MakeTriangle(new Vector3(1f,0.96f,0), wallColor),
                MakeTriangle(new Vector3(1.2f,0.9f,0), wallColor),
                MakeTriangle(new Vector3(1.2f,0.35f,0), wallColor),

                MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(0,2f,-1), wallColor),
                MakeTriangle(new Vector3(1.2f,1.4f,0), wallColor),
                MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(1.2f,1.4f,0), wallColor),
                MakeTriangle(new Vector3(1.2f,0.9f,0), wallColor),

                // wall 2
                MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(-1f,1.5f,0), wallColor),
                MakeTriangle(new Vector3(0,2f,-1), wallColor),
                MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(-1f,1.5f,0), wallColor),
                MakeTriangle(new Vector3(-1,1f,0), wallColor),

                /*MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(-1f,0f,0), wallColor), // chao
                MakeTriangle(new Vector3(0,0.5f,-1), wallColor),*/
                MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(-0.2f,0.35f,0), wallColor),
                MakeTriangle(new Vector3(0,0.5f,-1), wallColor),
                MakeTriangle(new Vector3(0,1.5f,-1), wallColor),
                MakeTriangle(new Vector3(-0.2f,0.35f,0), wallColor),
                MakeTriangle(new Vector3(-0.2f,1.2f,0), wallColor),

                MakeTriangle(new Vector3(-0.8f,1.3f,-1), windowColor1),
                MakeTriangle(new Vector3(-0.2f,0.35f,0), windowColor1),
                MakeTriangle(new Vector3(-0.2f,1.2f,0), windowColor1),
                MakeTriangle(new Vector3(-0.8f,1.3f,-1), windowColor1),
                MakeTriangle(new Vector3(-0.2f,0.35f,0), windowColor1),
                MakeTriangle(new Vector3(-0.8f,0.25f,-1), windowColor1),

                MakeTriangle(new Vector3(-0.8f,1.3f,-1), wallColor),
                MakeTriangle(new Vector3(-1f,0.1f,0), wallColor),
                MakeTriangle(new Vector3(-0.8f,0.25f,-1), wallColor),
                MakeTriangle(new Vector3(-0.8f,1.3f,-1), wallColor),
                MakeTriangle(new Vector3(-1f,0.1f,0), wallColor),
                MakeTriangle(new Vector3(-1f,1.0f,0), wallColor),
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionColor), this.verts.Length, BufferUsage.None);
            this.effect = new BasicEffect(this.device);
        }

        public VertexPositionColor MakeTriangle(Vector3 pos, Color color)
        {
            return new VertexPositionColor(pos, color);
        }

        public void Draw(_Camera camera)
        {
            this.device.SetVertexBuffer(this.buffer);

            this.effect.World = this.world;
            this.effect.View = camera.GetView();
            this.effect.Projection = camera.GetProjection();
            this.effect.VertexColorEnabled = true;

            foreach(EffectPass pass in this.effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                this.device.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, this.verts, 0, this.verts.Length / 3);
            }
        }
    }
}
