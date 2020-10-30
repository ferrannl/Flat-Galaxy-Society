using FlatGalaxySociety.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Asteroid : Star
    {
        public Asteroid(double x, double y, double vx, double vy, double radius, CollisionStrategy collisionStrategy, string color) : base(x, y, vx, vy, radius, collisionStrategy, color) { }

        public override Star Clone(Dictionary<object, object> objectMap)
        {
            return new Asteroid(x, y, vx, vy, radius, collisionStrategy.Clone(null), color);
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}