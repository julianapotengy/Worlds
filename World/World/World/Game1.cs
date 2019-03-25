using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace World
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        _Screen screen;
        _Camera camera;
        _Grass grass;
        _Walls walls;
        _FrontDoor frontDoor;
        _BackDoor backDoor;
        _SliderWindow sliderWindow;
        _OpenWindow openWindow;
        _Roof roof;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
        }

        protected override void Initialize()
        {
            this.screen = _Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);

            this.camera = new _Camera();

            this.grass = new _Grass(GraphicsDevice);
            this.walls = new _Walls(GraphicsDevice);
            this.frontDoor = new _FrontDoor(GraphicsDevice);
            this.backDoor = new _BackDoor(GraphicsDevice);
            this.sliderWindow = new _SliderWindow(GraphicsDevice);
            this.openWindow = new _OpenWindow(GraphicsDevice);
            this.roof = new _Roof(GraphicsDevice);

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        
        protected override void UnloadContent()
        {
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            this.camera.Update(gameTime);

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            this.grass.Draw(this.camera);
            this.walls.Draw(this.camera);
            this.frontDoor.Draw(this.camera);
            this.backDoor.Draw(this.camera);
            this.sliderWindow.Draw(this.camera);
            this.openWindow.Draw(this.camera);
            this.roof.Draw(this.camera);

            /*RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;*/

            base.Draw(gameTime);
        }
    }
}
