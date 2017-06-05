using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Flappy_Bird
{
    public class Highscore
    {
        // STATIC FIELDS
        private static string fileName = "highscore";

        // CONSTRUCTOR

        // STATIC METHODS
        public static int GetHighscore()
        {
            int score = 0;

            try
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read)))
                    score = reader.ReadInt32();
            }
            catch (EndOfStreamException)
            {
                return 0;
            }


            return score;
        }

        public static void SetHighcore(int score)
        {
            using (BinaryWriter writer = new BinaryWriter(new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write)))
            {
                writer.Write(score);
            }

        }

        // STATIC UPDATE
    }
}
