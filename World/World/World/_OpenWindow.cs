﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace World
{
    public class _OpenWindow
    {
        GraphicsDevice device;
        Matrix world;
        VertexPositionTexture[] verts;
        VertexBuffer buffer;
        BasicEffect effect;
        Color windowColor;

        protected Vector3 position;
        private float angle;
        Texture2D texture;

        public _OpenWindow(GraphicsDevice device, Vector3 position, float angle, Texture2D texture)
        {
            this.device = device;
            this.world = Matrix.Identity;
            this.windowColor = Color.SandyBrown;
            this.position = position;
            this.angle = angle;
            this.texture = texture;

            this.verts = new VertexPositionTexture[]
            {
                // slider window - esquerda - 1
                new VertexPositionTexture(new Vector3(-2f,3,-1f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,1.5f,-1f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,-1f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3f,-2f),new Vector2(0, 0)),  //v2

                // esquerda - 2
                new VertexPositionTexture(new Vector3(-2f,3,0f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-1f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,3f,-1f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(-2f,3,0f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(-2f,1.5f,-1f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(-2f,1.5f,0f),new Vector2(0, 0)),  //v2

                // slider window - direita - 1
                new VertexPositionTexture(new Vector3(2f,3,-1f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,1.5f,-1f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,-1f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-2f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3f,-2f),new Vector2(0, 0)),  //v2

                // direita - 2
                new VertexPositionTexture(new Vector3(2f,3,0f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-1f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,3f,-1f),new Vector2(0, 0)),  //v2

                new VertexPositionTexture(new Vector3(2f,3,0f),new Vector2(0, 1)),   //v0
                new VertexPositionTexture(new Vector3(2f,1.5f,-1f),new Vector2(1, 0)), //v1
                new VertexPositionTexture(new Vector3(2f,1.5f,0f),new Vector2(0, 0)),  //v2
            };

            this.buffer = new VertexBuffer(this.device, typeof(VertexPositionTexture), this.verts.Length, BufferUsage.None);
            this.buffer.SetData<VertexPositionTexture>(this.verts);
            this.effect = new BasicEffect(this.device);
        }

        public void LoadContent(ContentManager Content, Texture2D diretorio)
        {
            
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
