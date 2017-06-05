using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public class Sprite
    {
        // FIELDS
        //private Vector2      position;
        protected Texture2D    texture;
        protected Rectangle    destinationRectangle;
        protected Color        color;
        protected float        rotation;
        protected Vector2      origin;
        protected SpriteEffects imgOrientation;

        // SETTERS
        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetOrientation(SpriteEffects orientation)
        {
            this.imgOrientation = orientation;
        }

        public Point GetTextureSize()
        {
            return new Point(this.destinationRectangle.Width, this.destinationRectangle.Height);
        }

        public void SetRotation(float rotation)
        {
            this.rotation = rotation;
        }

        public void SetOrigin(int x, int y)
        {
            this.origin.X = x;
            this.origin.Y = y;
        }

        // CONSTRUCTOR
        public Sprite(string key)
        {
            this.Initialize(key, 0, 0, SpriteEffects.None);
        }

        public Sprite(string key, int x, int y)
        {
            this.Initialize(key, x, y, SpriteEffects.None);
        }

        public Sprite(string key, int x, int y, SpriteEffects orientation)
        {
            this.Initialize(key, x, y, orientation);
        }

        private void Initialize(string key, int x, int y, SpriteEffects orientation)
        {
            this.texture = Resources.Images[key];
            this.color = Color.White;
            this.rotation = 0;
            this.imgOrientation = orientation;
            this.origin = new Vector2(0,0);

            this.destinationRectangle = new Rectangle((x + (int)this.origin.X) * Settings.PIXEL_RATIO,
                                          (y + (int)this.origin.Y) * Settings.PIXEL_RATIO,
                                          this.texture.Width * Settings.PIXEL_RATIO,
                                          this.texture.Height * Settings.PIXEL_RATIO);
        }

        // METHODS


        // DRAW
        public virtual void Update(int x, int y)
        {
            this.destinationRectangle.X = (x + (int)this.origin.X) * Settings.PIXEL_RATIO;
            this.destinationRectangle.Y = (y + (int)this.origin.Y) * Settings.PIXEL_RATIO;
            this.destinationRectangle.Width = this.texture.Width * Settings.PIXEL_RATIO;
            this.destinationRectangle.Height = this.texture.Height * Settings.PIXEL_RATIO;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.destinationRectangle, null, this.color, this.rotation, this.origin, this.imgOrientation, 0f);
        }
    }
}
