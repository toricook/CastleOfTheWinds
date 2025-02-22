using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    public interface IMoveable
    {
        public Vector2 GetNextPosition(float deltaTime);
    }
}
