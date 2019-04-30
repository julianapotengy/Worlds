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

        List<_Helice> heliceList = new List<_Helice>();
        List<_Moinhos> moinhoList = new List<_Moinhos>();

        Vector3 housePos, grassPos, moinho1Pos, moinho2Pos, helice1Pos, helice2Pos;
        float moinho1Angle, moinho2Angle;
        Texture2D grassTexture, grayPaintTexture, redPaintTexture, woodTexture;
        Texture2D snowGrassTexture, snowGrayPaintTexture, snowRedPaintTexture, snowWoodTexture;

        Effect snowEffect;
        float counter, add;

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

            this.grassTexture = Content.Load<Texture2D>(@"Textures\grass-texture");
            this.grayPaintTexture = Content.Load<Texture2D>(@"Textures\gray-paint-texture");
            this.redPaintTexture = Content.Load<Texture2D>(@"Textures\red-paint-texture");
            this.woodTexture = Content.Load<Texture2D>(@"Textures\wood-texture");

            this.snowGrassTexture = Content.Load<Texture2D>(@"Textures\snow-grass-texture");
            this.snowGrayPaintTexture = Content.Load<Texture2D>(@"Textures\snow-gray-paint-texture");
            this.snowRedPaintTexture = Content.Load<Texture2D>(@"Textures\snow-red-paint-texture");
            this.snowWoodTexture = Content.Load<Texture2D>(@"Textures\snow-wood-texture");

            this.snowEffect = Content.Load<Effect>(@"Effects\snow-effect");
            add = 0.001f;

            GraphicsDevice.RasterizerState = RasterizerState.CullNone;

            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            this.grass = new _Grass(GraphicsDevice, grassPos, 0, grassTexture, snowEffect, snowGrassTexture);
            this.walls = new _Walls(GraphicsDevice, housePos, 0, grayPaintTexture, snowEffect, snowGrayPaintTexture);
            this.frontDoor = new _FrontDoor(GraphicsDevice, housePos, 0, woodTexture, snowEffect, snowWoodTexture);
            this.backDoor = new _BackDoor(GraphicsDevice, housePos, 0, woodTexture, snowEffect, snowWoodTexture);
            this.sliderWindow = new _SliderWindow(GraphicsDevice, housePos, 0, woodTexture, snowEffect, snowWoodTexture);
            this.openWindow = new _OpenWindow(GraphicsDevice, housePos, 0, woodTexture, snowEffect, snowWoodTexture);
            this.roof = new _Roof(GraphicsDevice, housePos, 0, woodTexture, snowEffect, snowWoodTexture);
            this.moinho1 = new _Moinhos(GraphicsDevice, moinho1Pos, moinho1Angle, redPaintTexture, snowEffect, snowRedPaintTexture);
            this.moinho2 = new _Moinhos(GraphicsDevice, moinho2Pos, moinho2Angle, redPaintTexture, snowEffect, snowRedPaintTexture);

            this.heliceList.Add(new _Helice(GraphicsDevice, helice1Pos, moinho1Angle, woodTexture, snowEffect, snowWoodTexture));
            this.heliceList.Add(new _Helice(GraphicsDevice, helice2Pos, moinho2Angle, woodTexture, snowEffect, snowWoodTexture));
        }
        
        protected override void UnloadContent()
        {
            
        }
        
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            this.camera.Update(gameTime);
            this.walls.Update(gameTime, counter);
            this.grass.Update(gameTime, counter);
            this.frontDoor.Update(gameTime, counter);
            this.backDoor.Update(gameTime, counter);
            this.sliderWindow.Update(gameTime, counter);
            this.openWindow.Update(gameTime, counter);
            this.roof.Update(gameTime, counter);
            this.moinho1.Update(gameTime, counter);
            this.moinho2.Update(gameTime, counter);

            foreach (_Helice h in this.heliceList)
            {
                h.Update(gameTime, counter);
            }

            counter += (gameTime.ElapsedGameTime.Milliseconds / 7) * add;
            if(counter > 0.7f)
            {
                add = -0.001f;
            }
            else if(counter < 0.1f)
            {
                add = 0.001f;
            }

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearClamp;
            GraphicsDevice.SamplerStates[1] = SamplerState.LinearClamp;

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

            /*RasterizerState rs = new RasterizerState();
            rs.CullMode = CullMode.None;
            rs.FillMode = FillMode.WireFrame;
            GraphicsDevice.RasterizerState = rs;*/

            base.Draw(gameTime);
        }
    }
}
