using FlatGalaxySociety.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public abstract class CollisionStrategy: ICloneable<CollisionStrategy>
    {
        public abstract string Type();
        public bool IsStrategy(string type)
        {
            return type.Equals(Type());
        }

        public abstract void OnCollision(Galaxy galaxy, Star star);

        public virtual void OnNoCollision(Star star) { }

        public abstract CollisionStrategy Clone(Dictionary<object, object> objectMap);
    }
}