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
    public class Bird : GameObject
    {
        // CONST
        private const float FLAP = -2.3f;
        private const float MAX_SPEED = 15f;
        private const float MAX_ROTATION_VELOCITY = 0.15f;
        private const float MAX_ROTATION = ((float)Math.PI / 2f);

        // FIELDS
        private bool gravity;
        private float speedY;
        private float rotationVelocity;
        private int currentFrame;
        private int timer;
        private float rotation;

        // CONSTRUCTOR
        public Bird(string bird , int x, int y)
            : base(x, y, new AnimatedSprite(bird, 17, 12, 0, SheetOrientation.HORIZONTAL))
        {
            this.gravity = false;
            this.speedY = 0f;
            this.rotationVelocity = 0f;
            this.rotation = 0f;
            this.currentFrame = 0;
            this.timer = 0;
            this.sprite.SetOrigin(8, 6);
        }
        
        // METHODS
        public void SetMaxRotation()
        {
            this.rotation = MAX_ROTATION;
        }

        public void ActiveGravity()
        {
            this.gravity = true;
        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            if (this.timer > 48)
            {
                this.timer = 0;
                if (this.currentFrame == 2)
                {
                    this.currentFrame = 0;
                }
                else
                    ++this.currentFrame;
                ((AnimatedSprite)this.sprite).SetIndex(this.currentFrame);

                this.sprite.SetOrigin(8, 6);
            }

            if (input != null)
            {
                if (input.IsSpacePressed())
                {
                    // FLAP
                    this.gravity = true;
                    this.speedY = FLAP * Settings.PIXEL_RATIO;
                    this.rotation = -(float)Math.PI / 8f;
                    this.rotationVelocity = -0.175f;
                    Resources.Sounds["flap"].Play();
                }

                // ROOF PROTECTION
                if (this.hitBox.Y <= 0)
                {
                    this.speedY = 0f;
                    this.hitBox.Y = 1;
                }

            }

            if (this.gravity)
            {
                if (this.speedY < MAX_SPEED)
                {
                    this.speedY += 0.25f;
                }

                if (this.rotationVelocity < MAX_ROTATION_VELOCITY)
                {
                    this.rotationVelocity += 0.005f;
                }

                if (this.rotation < MAX_ROTATION)
                {
                    if (this.rotationVelocity > 0f)
                    {
                        this.rotation += this.rotationVelocity;
                    }
                }
                else
                {
                    this.rotation = MAX_ROTATION;
                }


                this.sprite.SetRotation(this.rotation);
                this.hitBox.Y += (int)this.speedY;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
