using FlatGalaxySociety.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Planet : Star
    {
        public string name;
        public List<Star> neighbours;
        public Planet(string name, double x, double y, double vx, double vy, double radius, CollisionStrategy collisionStrategy, string color) : base(x, y, vx, vy, radius, collisionStrategy, color)
        {
            this.name = name;
            neighbours = new List<Star>();
        }

        public override Star Clone(Dictionary<object, object> objectMap)
        {
            Planet copy;
            if (objectMap.ContainsKey(this))
            {
                copy = (Planet)objectMap[this];
            }
            else
            {
                copy = new Planet(name, x, y, vx, vy, radius, collisionStrategy.Clone(null), color);
                objectMap.Add(this, copy);
            }
            neighbours.ForEach(n =>
            {
                Planet p;
                if (objectMap.ContainsKey(n))
                {
                    p = (Planet)objectMap[n];
                }
                else
                {
                    p = (Planet)n.Clone(objectMap);
                }
                copy.neighbours.Add(p);
            });

            return copy;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}