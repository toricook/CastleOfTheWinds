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

        public Sprite(Texture2D texture, Rectangle source, Vector2 initialPosition) : base(initialPosition)
        {
            _texture = texture;
            _source = source;
        }

        public void Render(SpriteBatch spriteBatch, Vector2 viewPort)
        {
            var dest = new Rectangle((int)(Position.X + viewPort.X), (int)(Position.Y + (int)viewPort.Y), _source.Width, _source.Height);
            spriteBatch.Draw(_texture, dest, _source, Color.White);
        }

    }
}
