using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public class Tilemap
    {
        public Dictionary<Vector2, int> Tiles;

        public Tilemap(Dictionary<Vector2, int> tiles)
        {
            Tiles = tiles;
        }

        public static Tilemap FromCsv(string filepath)
        {
            var ret = new Dictionary<Vector2, int>();
            StreamReader sr = new StreamReader(filepath);
            string line;

            int y = 0;
            while ((line = sr.ReadLine()) != null)
            {
                string[] items = line.Split(',');
                for (int x = 0; x < items.Length; x++)
                {
                    if (int.TryParse(items[x], out int val) && val > -1)
                    {
                        ret[new Vector2(x, y)] = val;
                    }
                }
                y++;
            }
            return new Tilemap(ret);
        }

    }
}
