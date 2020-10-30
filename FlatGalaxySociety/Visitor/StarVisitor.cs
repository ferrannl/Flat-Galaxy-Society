using FlatGalaxySociety.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Visitor
{
    public class StarVisitor : IVisitor
    {
        private MainViewModel main;
        public StarVisitor(MainViewModel main)
        {
            this.main = main;
            main.ObservableStars = new ObservableCollection<Star>();
        }
        public void Visit(Planet planet)
        {
            main.ObservableStars.Add(planet);
        }

        public void Visit(Asteroid asteroid)
        {
            main.ObservableStars.Add(asteroid);
        }
    }
}
