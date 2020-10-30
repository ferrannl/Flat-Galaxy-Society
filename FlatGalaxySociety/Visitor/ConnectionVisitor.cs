using FlatGalaxySociety.Models;
using FlatGalaxySociety.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Visitor
{
    public class ConnectionVisitor : IVisitor
    {
        private MainViewModel main;
        public ConnectionVisitor(MainViewModel main)
        {
            this.main = main;
            main.ObservableConnections = new ObservableCollection<Connection>();
        }

        public void Visit(Planet planet)
        {
            foreach (Star n in planet.neighbours)
            {
                main.ObservableConnections.Add(new Connection(planet.x, planet.y, n.x, n.y));
            }
        }

        public void Visit(Asteroid asteroid)
        {
        }
    }
}
