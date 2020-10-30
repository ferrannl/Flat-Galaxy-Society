using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Visitor
{
    public interface IVisitor
    {
        void Visit(Planet planet);

        void Visit(Asteroid asteroid);
    }
}
