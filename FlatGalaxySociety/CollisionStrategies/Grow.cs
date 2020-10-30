using FlatGalaxySociety.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Grow : CollisionStrategy
    {

        public override void OnCollision(Galaxy galaxy, Star star)
        {
            star.radius++;
            if (star.radius >= 20)
            {
                star.collisionStrategy = CollisionStrategyFactory.Instance.GetNextStrategy(this);
            }
        }

        public override string Type()
        {
            return "grow";
        }

        public override CollisionStrategy Clone(Dictionary<object, object> objectMap)
        {
            return new Grow();
        }
    }
}