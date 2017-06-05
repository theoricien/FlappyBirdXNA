using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public class Ground : GameObject
    {
        // FIELDS
        private int currentOffset;
        private int baseX;
        private int timer;

        // CONSTRUCTOR
        public Ground(int x, int y)
            : base(x, y, new Sprite("ground"))
        {
            this.baseX = x;
            this.currentOffset = 0;
            this.timer = 0;
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;
            while (this.timer >= 16)
            {
                this.timer -= 16;
                this.currentOffset += 1;

                if (this.currentOffset >= 7)
                    this.currentOffset = 0;

                this.hitBox.X = this.baseX - (this.currentOffset * Settings.PIXEL_RATIO);
            }
        }
    }
}
