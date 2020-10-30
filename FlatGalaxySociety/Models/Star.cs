using FlatGalaxySociety.Utils.Interfaces;
using FlatGalaxySociety.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public abstract class Star : ICloneable<Star>
    {
        public virtual double x { get; set; }
        public virtual double y { get; set; }
        public virtual double vx { get; set; }
        public virtual double vy { get; set; }
        public virtual double radius { get; set; }
        public string color { get; set; }

        public CollisionStrategy collisionStrategy;

        public Star(double x, double y, double vx, double vy, double radius, CollisionStrategy collisionStrategy, string color)
        {
            this.x = x;
            this.y = y;
            this.vx = vx;
            this.vy = vy;
            this.radius = radius;
            this.collisionStrategy = collisionStrategy;
            this.color = color;
        }

        private const double multiplier = 0.25;

        public void Step()
        {
            x += vx * multiplier;
            y += vy * multiplier;
        }

        public void CheckCollisionWall()
        {
            if (x <= radius || x + radius >= Galaxy.WIDTH)
                vx = -vx;
            if (y <= radius || y + radius >= Galaxy.HEIGHT)
                vy = -vy;
        }

        public void OnCollision(Galaxy galaxy)
        {
            collisionStrategy.OnCollision(galaxy, this);
        }

        public void OnNoCollision()
        {
            collisionStrategy.OnNoCollision(this);
        }

        public bool HasCollision(Star star)
        {
            return DistanceTo(star) <= radius + star.radius;
        }

        private double DistanceTo(Star star)
        {
            double disWidth = Math.Abs(x - star.x);
            double disHeight = Math.Abs(y - star.y);
            return Math.Sqrt(disWidth * disWidth + disHeight * disHeight);
        }
        public abstract void Accept(IVisitor visitor);

        public abstract Star Clone(Dictionary<object, object> objectMap);

    }
}