using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Flappy_Bird
{
    public enum Menu
    {
        MAIN,
        GAME
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MenuBase menu;
        KeyboardState oldKeyboard;
        MouseState oldMouse;
        Random random;
        string background;
        bool musicOn;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Settings.SCREEN_WIDTH * Settings.PIXEL_RATIO;
            graphics.PreferredBackBufferHeight = Settings.SCREEN_HEIGHT * Settings.PIXEL_RATIO;
            this.IsMouseVisible = Settings.IS_MOUSE_VISIBLE;
            this.IsFixedTimeStep = true;
            graphics.IsFullScreen = Settings.IS_FULLSCREEN;
            Content.RootDirectory = "Content";
            random = new Random();
            background = "background" + random.Next(1, 3);
        }

        protected override void Initialize()
        {

            base.Initialize();

            this.menu = new MenuMain(background);

            this.oldKeyboard = Keyboard.GetState();
            this.oldMouse = Mouse.GetState();
            this.musicOn = true;
        }

        public bool GetMusic()
        {
            return musicOn;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Resources.LoadImages(this.Content);
            Resources.LoadSounds(this.Content);
        }

        protected override void UnloadContent()
        {

        }

        public void ChangeMenu(Menu menu)
        {
            switch(menu)
            {
                case Menu.MAIN:
                    this.menu = new MenuMain(background);
                    break;
                case Menu.GAME:
                    this.menu = new MenuGame(background);
                    break;
                default:
                    break;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.menu.Update(gameTime, new Input(oldKeyboard, oldMouse, Keyboard.GetState(), Mouse.GetState()), this);

            oldKeyboard = Keyboard.GetState();
            oldMouse = Mouse.GetState();



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            this.menu.Draw(this.spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
