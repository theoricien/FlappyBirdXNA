using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public class MenuMain : MenuBase
    {
        // FIELDS
        private Button startButton;
        private Button quitButton;
        private Button musicOnButton;
        private Button musicOffButton;
        private Sprite background;
        private Sprite logo;
        private Ground ground;

        // CONSTRUCTOR
        public MenuMain(string back)
            : base()
        {
            this.logo = new Sprite("logo", (Settings.SCREEN_WIDTH - 96) / 2, 25);
            this.startButton = new Button((Settings.SCREEN_WIDTH - 40) / 2, 100, 5);
            this.quitButton = new Button((Settings.SCREEN_WIDTH - 40) / 2, 125, 2);
            this.musicOnButton = new Button((Settings.SCREEN_WIDTH - 40) / 2, 150, 4);
            this.musicOffButton = new Button((Settings.SCREEN_WIDTH - 40) / 2, 150, 3);
            this.background = new Sprite(back);
            this.ground = new Ground(0, 200);
        }

        // METHODS

        // UPDATE AND DRAW
        public override void Update(GameTime gameTime, Input input, Game1 game)
        {
            base.Update(gameTime, input, game);
            this.startButton.Update(gameTime, input);

            if(this.startButton.IsPressed())
            {
                game.ChangeMenu(Menu.GAME);
            }

            this.quitButton.Update(gameTime, input);
            
            if (this.quitButton.IsPressed())
            {
                game.Exit();
            }

            if (musicOn == true)
            {
                this.musicOnButton.Update(gameTime, input);
                if (this.musicOnButton.IsPressed())
                {
                    musicOn = false;
                }
            }
            else
            {
                this.musicOffButton.Update(gameTime, input);
                if (this.musicOffButton.IsPressed())
                {
                    musicOn = true;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            this.background.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
            this.logo.Draw(spriteBatch);
            this.startButton.Draw(spriteBatch);
            this.quitButton.Draw(spriteBatch);

            if(musicOn == true)
            {
                this.musicOnButton.Draw(spriteBatch);
            }
            else
            {
                this.musicOffButton.Draw(spriteBatch);
            }
        }
    }
}
