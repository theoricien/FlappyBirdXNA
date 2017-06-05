using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flappy_Bird
{
    public class Resources
    {
        public static Dictionary<string, Texture2D> Images;
        public static Dictionary<string, SoundEffect> Sounds;

        public static void LoadImages(ContentManager content)
        {
            Images = new Dictionary<string, Texture2D>();

            List<string> graphics = new List<string>()
            {
                "background1",
                "background2",
                "bird1",
                "bird2",
                "bird3",
                "game_buttons",
                "gameover",
                "getready",
                "ground",
                "logo",
                "medals",
                "menu_buttons",
                "new",
                "numbers_large",
                "numbers_small",
                "pause_screen",
                "pipe_bot",
                "pipe_top",
                "tutorial",
                "score_box"
            };

            foreach (string img in graphics)
            {
                Images.Add(img, content.Load<Texture2D>("graphics/" + img));
            }
        }

        public static void LoadSounds(ContentManager content)
        {
            Sounds = new Dictionary<string, SoundEffect>();

            List<string> sounds = new List<string>()
            {
                "background",
                "button_clic",
                "button_hover",
                "flap",
                "flap2",
                "pipe_hit",
                "pipe_hit2",
                "pipe_pass"
            };

            foreach (string sfx in sounds)
            {
                Sounds.Add(sfx, content.Load<SoundEffect>("sounds/" + sfx));
            }


        }

        public static void StopSound(string song)
        {

        }
    }
}
