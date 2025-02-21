using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public class RenderingSystem
    {
        public void Draw(SpriteBatch spriteBatch, Vector2 viewport)
        {
            foreach (var gameObject in ObjectStore.Instance.GetObjects())
            {
                if (gameObject is IRenderable renderable)
                {
                    renderable.Render(spriteBatch, viewport);
                }
            }
        }
    }
}
