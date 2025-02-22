using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastleOfTheWinds
{
    // TODO: consider switching to factory pattern or something
    public abstract class GameObject
    {
        public Vector2 Position { get; set; }
        public GameObject(Vector2 position)
        {
            Position = position;
            ObjectStore.Instance.AddObject(this);
        }

        public void Destroy()
        {
            ObjectStore.Instance.RemoveObject(this);
        }

    }
}
