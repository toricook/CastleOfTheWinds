using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public class MovementSystem
    {
        public void Update(float deltaTime)
        {
            foreach (var gameObject in ObjectStore.Instance.GetObjects())
            {
                if (gameObject is IMoveable moveable)
                {
                    var pos = moveable.GetNextPosition(deltaTime);
                    gameObject.Position = pos;
                }
            }
        }
    }
}
