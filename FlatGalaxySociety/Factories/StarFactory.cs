using FlatGalaxySociety.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class StarFactory
    {
        private static StarFactory instance;

        public static StarFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StarFactory();
                }
                return instance;
            }
        }

        public virtual Star CreateStar(string starType, string name, double x, double y, double vx, double vy, double radius, string oncollision, string color)
        {
            CollisionStrategy strategy = CollisionStrategyFactory.Instance.CreateStrategy(oncollision);

            switch (starType.ToLower())
            {
                case "planet":
                    return new Planet(name, x, y, vx, vy, radius, strategy, color);
                case "asteroid":
                    return new Asteroid(x, y, vx, vy, radius, strategy, color);
                default:
                    throw new Exception("Ster type wordt niet ondersteund.");
            }
        }
    }
}