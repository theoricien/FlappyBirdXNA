using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public enum NumberSize
    {
        LARGE,
        SMALL
    }

    public class Number
    {
        // STATIC FIELDS
        public static int LARGE_NUMBER_WIDTH = 7;
        public static int LARGE_NUMBER_HEIGHT = 10;

        public static int SMALL_NUMBER_WIDTH = 6;
        public static int SMALL_NUMBER_HEIGHT = 7;

        // STATIC METHODS
        public static void Draw(SpriteBatch spriteBatch, NumberSize size, int x, int y, int num)
        {
            string strNum = num.ToString();

            foreach (char c in strNum)
            {
                int n = c - '0';
                if (size == NumberSize.SMALL)
                {
                    spriteBatch.Draw(Resources.Images["numbers_small"],
                                             new Rectangle(x * Settings.PIXEL_RATIO, y * Settings.PIXEL_RATIO, SMALL_NUMBER_WIDTH * Settings.PIXEL_RATIO, SMALL_NUMBER_HEIGHT * Settings.PIXEL_RATIO),
                                             new Rectangle(n * SMALL_NUMBER_WIDTH, 0, SMALL_NUMBER_WIDTH, SMALL_NUMBER_HEIGHT),
                                             Color.White);
                    x += SMALL_NUMBER_WIDTH + 1;
                }
                else
                {
                    spriteBatch.Draw(Resources.Images["numbers_large"],
                                            new Rectangle(x * Settings.PIXEL_RATIO, y * Settings.PIXEL_RATIO, LARGE_NUMBER_WIDTH * Settings.PIXEL_RATIO, LARGE_NUMBER_HEIGHT * Settings.PIXEL_RATIO),
                                            new Rectangle(n * LARGE_NUMBER_WIDTH, 0, LARGE_NUMBER_WIDTH, LARGE_NUMBER_HEIGHT),
                                            Color.White);
                    x += LARGE_NUMBER_WIDTH - 1;
                }
            }
        }
        
    }
}
