using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public class Scene
    {
        public string TilemapCsvPath;
        public string SpriteCsvPath;

        public Tilemap Tilemap;
        public List<Sprite> Sprites;

        public Scene(string tilemapCsv, string spriteCsv)
        {
            TilemapCsvPath = tilemapCsv;
            SpriteCsvPath = spriteCsv;
        }

        public void Load(Dictionary<string, Texture2D> spriteSheets)
        {
            Tilemap = Tilemap.FromCsv(TilemapCsvPath);
            Sprites = new List<Sprite>();

            StreamReader sr = new StreamReader(SpriteCsvPath);
            string line;

            while ((line = sr.ReadLine()) != null)
            {
                string[] data = line.Split(',');
                var texture = spriteSheets[data[0]];
                var source = new Rectangle(int.Parse(data[1]), int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                var dest = new Rectangle(int.Parse(data[5]), int.Parse(data[6]), source.Width, source.Height);
                Sprites.Add(new Sprite(texture, source, dest));
            }
        }

    }
}
