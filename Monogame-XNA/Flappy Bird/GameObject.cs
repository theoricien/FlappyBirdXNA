using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public abstract class GameObject
    {
        // FIELDS
        protected Sprite       sprite;
        protected Rectangle    hitBox;

        // GETTERS
        public int X
        {
            get
            {
                return this.hitBox.X;
            }
        }

        public int Y
        {
            get
            {
                return this.hitBox.Y;
            }
        }

        public int Right
        {
            get
            {
                return this.hitBox.Right;
            }
        }

        // CONSTRUCTOR
        protected GameObject(int x, int y, Sprite sprite)
        {
            Point textureSize = sprite.GetTextureSize();
            this.hitBox = new Rectangle(x * Settings.PIXEL_RATIO, y * Settings.PIXEL_RATIO, textureSize.X, textureSize.Y);
            this.sprite = sprite;
            this.sprite.Update(x, y);
        }

        // METHODS
        public bool CollisionWith(GameObject objet)
        {
            return this.hitBox.Intersects(objet.hitBox);
        }

        // UPDATE & DRAW
        public virtual void Update(GameTime gameTime, Input input)
        {
            this.sprite.Update(this.hitBox.X / Settings.PIXEL_RATIO, this.hitBox.Y / Settings.PIXEL_RATIO);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);

            // HITBOX VISIBLE
            //spriteBatch.Draw(Resources.Images["ground"], this.hitBox, Color.Red);
        }
    }
}
