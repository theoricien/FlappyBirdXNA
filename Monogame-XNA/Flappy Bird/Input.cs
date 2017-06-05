using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public class Input
    {
        // FIELDS
        private KeyboardState oldKeyboard;
        private MouseState oldMouse;

        private KeyboardState keyboard;
        private MouseState mouse;

        // CONSTRUCTOR
        public Input(KeyboardState o_kb, MouseState o_ms, KeyboardState kb, MouseState ms)
        {
            this.oldKeyboard = o_kb;
            this.oldMouse = o_ms;

            this.keyboard = kb;
            this.mouse = ms;

        }

        // METHODS
        public bool IsKey(Keys key)
        {
            return this.oldKeyboard.IsKeyUp(key) && this.keyboard.IsKeyDown(key);
        }

        public bool IsMouseDown()
        {
            return this.mouse.LeftButton == ButtonState.Pressed;
        }

        public bool IsLeftMousePressed()
        {
            return this.oldMouse.LeftButton == ButtonState.Released && this.mouse.LeftButton == ButtonState.Pressed;
        }

        public bool IsSpacePressed()
        {
            return this.oldKeyboard.IsKeyUp(Keys.Space) && this.keyboard.IsKeyDown(Keys.Space);
        }

        public bool IsPPressed()
        {
            return this.oldKeyboard.IsKeyUp(Keys.P) && this.keyboard.IsKeyDown(Keys.P);
        }

        public Point GetMousePosition()
        {
            return new Point(this.mouse.X, this.mouse.Y);
        }


    }
}
