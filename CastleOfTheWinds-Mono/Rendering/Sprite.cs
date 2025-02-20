using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public class Sprite
    {
        Texture2D _texture;
        Rectangle _source;

        public Rectangle Rect;

        public Sprite(Texture2D texture, Rectangle dest, Rectangle source)
        {
            _texture = texture;
            Rect = dest;
            _source = source;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Rect, _source, Color.White);
        }
    }
}
