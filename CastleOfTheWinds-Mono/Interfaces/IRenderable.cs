using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public interface IRenderable
    {
        public void Render(SpriteBatch spriteBatch, Vector2 viewport);
    }
}
