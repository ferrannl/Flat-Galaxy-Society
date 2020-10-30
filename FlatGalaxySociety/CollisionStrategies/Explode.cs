using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Explode : CollisionStrategy
    {
        private readonly int amount = 5;

        public override void OnCollision(Galaxy galaxy, Star star)
        {
            string type = star.GetType().Name;
            string name = star.GetType() == typeof(Planet) ? ((Planet)star).name : "";
            double radius = star.radius > 5 ? Math.Abs(star.radius / amount) : star.radius;
            string oncollision = "bounce";

            var starPoints = CalculateCirclePoints(amount, star.radius, star.x, star.y);

            double velocity = Math.Sqrt(star.vx * star.vx + star.vy * star.vy);
            var velocityPoints = CalculateCirclePoints(amount, velocity, star.x, star.y);

            for (var i = 0; i < amount; i++)
            {
                var vx = velocityPoints[i].Key - star.x;
                var vy = velocityPoints[i].Value - star.y;
                galaxy.stars.Add(StarFactory.Instance.CreateStar(type, name, starPoints[i].Key, starPoints[i].Value, vx, vy, radius, oncollision, star.color));
            }

            galaxy.stars.Remove(star);
        }

        public override string Type()
        {
            return "explode";
        }

        private List<KeyValuePair<double, double>> CalculateCirclePoints(int amount, double radius, double x, double y)
        {
            var points = new List<KeyValuePair<double, double>>();
            double slice = 2 * Math.PI / amount;
            for (int i = 0; i < amount; i++)
            {
                double angle = slice * i;
                double newX = x + radius * Math.Cos(angle);
                double newY = y + radius * Math.Sin(angle);
                points.Add(new KeyValuePair<double, double>(newX, newY));
            }
            return points;
        }

        public override CollisionStrategy Clone(Dictionary<object, object> objectMap)
        {
            return new Explode();
        }
    }
}
