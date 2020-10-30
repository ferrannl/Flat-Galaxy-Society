using FlatGalaxySociety.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Bounce : CollisionStrategy
    {
        public int counter;

        public override void OnCollision(Galaxy galaxy, Star star)
        {
            star.vx = -star.vx;
            star.vy = -star.vy;
            counter++;
            if (counter > 5)
            {
                star.collisionStrategy = CollisionStrategyFactory.Instance.GetNextStrategy(this);
            }
        }

        public override string Type()
        {
            return "bounce";
        }

        public override CollisionStrategy Clone(Dictionary<object, object> objectMap)
        {
            Bounce s = new Bounce();
            s.counter = counter;
            return s;
        }
    }
}