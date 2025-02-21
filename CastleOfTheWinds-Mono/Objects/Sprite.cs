using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public class Sprite : GameObject, IRenderable
    {
        Texture2D _texture;
        Rectangle _source;

        Rectangle _destination;

        public Sprite(Texture2D texture, Rectangle source, Rectangle destination) : base()
        {
            _texture = texture;
            _source = source;
            _destination = destination;
        }

        public void Render(SpriteBatch spriteBatch, Vector2 viewPort)
        {
            var dest = new Rectangle(_destination.X + (int)viewPort.X, _destination.Y + (int)viewPort.Y, _destination.Width, _destination.Height);
            spriteBatch.Draw(_texture, dest, _source, Color.White);
        }

    }
}
