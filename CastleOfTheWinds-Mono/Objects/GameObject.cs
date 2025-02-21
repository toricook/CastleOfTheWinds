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
        public GameObject()
        {
            ObjectStore.Instance.AddObject(this);
        }

        public void Destroy()
        {
            ObjectStore.Instance.RemoveObject(this);
        }

    }
}
