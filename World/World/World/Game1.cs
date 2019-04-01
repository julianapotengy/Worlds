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
        _Moinhos moinho1;
        _Moinhos moinho2;
        // _Helice helice1;
        // _Helice helice2;

        List<_Helice> heliceList = new List<_Helice>();
        List<_Moinhos> moinhoList = new List<_Moinhos>();

        Vector3 housePos, grassPos, moinho1Pos, moinho2Pos, helice1Pos, helice2Pos;
        float moinho1Angle, moinho2Angle;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;

            housePos = new Vector3(0, 0, 0);
            grassPos = new Vector3(0, 0, 0);
            moinho1Pos = new Vector3(10, 0, -10);
            moinho2Pos = new Vector3(-10, 0, -10);
            helice1Pos = new Vector3(8.5f, 7, -7);
            helice2Pos = new Vector3(-8.5f, 7, -7);

            moinho1Angle = 320;
            moinho2Angle = -320;
        }

        protected override void Initialize()
        {
            this.screen = _Screen.GetInstance();
            this.screen.SetWidth(graphics.PreferredBackBufferWidth);
            this.screen.SetHeight(graphics.PreferredBackBufferHeight);

            this.camera = new _Camera();

            this.grass = new _Grass(GraphicsDevice, grassPos, 0);
            this.walls = new _Walls(GraphicsDevice, housePos, 0);
            this.frontDoor = new _FrontDoor(GraphicsDevice, housePos, 0);
            this.backDoor = new _BackDoor(GraphicsDevice, housePos, 0);
            this.sliderWindow = new _SliderWindow(GraphicsDevice, housePos, 0);
            this.openWindow = new _OpenWindow(GraphicsDevice, housePos, 0);
            this.roof = new _Roof(GraphicsDevice, housePos, 0);
            this.moinho1 = new _Moinhos(GraphicsDevice, moinho1Pos, moinho1Angle);
            this.moinho2 = new _Moinhos(GraphicsDevice, moinho2Pos, moinho2Angle);

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.heliceList.Add(new _Helice(GraphicsDevice, helice1Pos, moinho1Angle));
            this.heliceList.Add(new _Helice(GraphicsDevice, helice2Pos, moinho2Angle));
        }
        
        protected override void UnloadContent()
        {
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            this.camera.Update(gameTime);
            this.walls.Update(gameTime);
            this.grass.Update(gameTime);
            this.frontDoor.Update(gameTime);
            this.backDoor.Update(gameTime);
            this.sliderWindow.Update(gameTime);
            this.openWindow.Update(gameTime);
            this.roof.Update(gameTime);
            this.moinho1.Update(gameTime);
            this.moinho2.Update(gameTime);

            foreach (_Helice h in this.heliceList)
            {
                h.Update(gameTime);
            }

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
            this.moinho1.Draw(this.camera);
            this.moinho2.Draw(this.camera);

            foreach (_Helice h in this.heliceList)
            {
                h.Draw(ref this.camera);
            }

            RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;

            base.Draw(gameTime);
        }
    }
}
