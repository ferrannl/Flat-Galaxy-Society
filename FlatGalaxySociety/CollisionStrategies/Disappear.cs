using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Disappear : CollisionStrategy
    {

        public override void OnCollision(Galaxy galaxy, Star star)
        {
            if (star.GetType() == typeof(Planet))
            {
                List<Planet> planets = galaxy.stars.Where(s => s.GetType() == typeof(Planet)).Select(s => (Planet)s).ToList();
                planets.ForEach(p => { if (p.neighbours.Contains(star)) { p.neighbours.Remove(star); } });
            }
            galaxy.stars.Remove(star);
        }

        public override string Type()
        {
            return "disappear";
        }

        public override CollisionStrategy Clone(Dictionary<object, object> objectMap)
        {
            return new Disappear();
        }
    }
}