using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace World
{
    public class _Camera
    {
        private Matrix view;
        private Matrix projection;

        private Vector3 position;
        private Vector3 target;
        private Vector3 up;

        float speed;
        float angleY;
        float speedY;

        public _Camera()
        {
            this.position = new Vector3(0f,5f,20f);
            this.target = Vector3.Up;
            this.up = Vector3.Up;
            speed = 20;
            angleY = 0;
            speedY = 100;
            this.SetupView(this.position, this.target, this.up);

            this.SetupProjection();
        }

        private void SetupView(Vector3 position, Vector3 target, Vector3 up)
        {
            this.view = Matrix.CreateLookAt(position, target, up);
        }

        private void SetupProjection()
        {
            _Screen screen = _Screen.GetInstance();

            this.projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, 
                                                                  screen.GetWidth() / (float)screen.GetHeight(), 0.001f, 1000);
        }

        public Matrix GetView()
        {
            return this.view;
        }

        public Matrix GetProjection()
        {
            return this.projection;
        }

        public void Update(GameTime gameTime)
        {
            this.Translation(gameTime);

            this.view = Matrix.Identity;
            this.view *= Matrix.CreateRotationY(MathHelper.ToRadians(this.angleY));
            this.view *= Matrix.CreateTranslation(this.position);
            this.view = Matrix.Invert(this.view);
        }

        private void Translation(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.angleY + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.angleY + 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                //this.angleY += this.speedY * gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                this.position.X += (float)Math.Sin(MathHelper.ToRadians(this.angleY - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                this.position.Z += (float)Math.Cos(MathHelper.ToRadians(this.angleY - 90)) * gameTime.ElapsedGameTime.Milliseconds * 0.001f * this.speed;
                //this.angleY -= this.speedY * gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            }
        }
    }
}
