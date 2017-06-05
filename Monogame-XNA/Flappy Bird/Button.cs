using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public class Button : GameObject
    {
        // FIELDS
        private bool isPressed;
        private bool hover;

        public bool IsPressed()
        {
            bool result = isPressed;
            if (isPressed)
                this.isPressed =  false;
            return result;
        }

        // CONSTRUCTOR
        public Button(int x, int y, int index, int width = 40)
            : base(x, y, new AnimatedSprite("menu_buttons", width, 14, index, SheetOrientation.VERTICAL))
        {
            this.isPressed = false;
            this.hover = false;
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            if (this.hitBox.Contains(input.GetMousePosition()))
            {
                if (input.IsLeftMousePressed())
                {
                    this.isPressed = true;
                    if(MenuMain.GetMusic() == true)
                        Resources.Sounds["button_clic"].Play();
                }
                if (input.IsLeftMousePressed())
                    this.sprite.SetColor(Color.Gray);
                else
                {
                    this.sprite.SetColor(Color.LightGray);
                    if (hover == false && MenuMain.GetMusic() == true)
                        Resources.Sounds["button_hover"].Play();
                }
                this.hover = true;
            }
            else
            {
                this.sprite.SetColor(Color.White);
                this.hover = false;
            }

            base.Update(gameTime, input);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
