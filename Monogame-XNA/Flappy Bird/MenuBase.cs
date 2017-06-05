using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public abstract class MenuBase
    {
        // FIELDS

        // CONSTRCUTOR
        public MenuBase()
        {
        }

        // METHODS


        // UPDATE & DRAW
        public virtual void Update(GameTime gameTime, Input input, Game1 game)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
