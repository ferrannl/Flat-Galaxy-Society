using System;
using FlatGalaxySociety.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlatGalaxySociety.Models;
using System.Linq;
using FlatGalaxySociety.Memento;
using FlatGalaxySociety.Utils.Interfaces;
using FlatGalaxySociety.Visitor;

namespace FlatGalaxySociety
{
    public class Galaxy : ICloneable<Galaxy>
    {
        public readonly static int WIDTH = 800;
        public readonly static int HEIGHT = 600;
        public MainViewModel mainViewModel;
        public virtual List<Star> stars { get; set; }

        public Galaxy(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            stars = new List<Star>();
        }

        public void Tick()
        {
            foreach (Star s in stars)
            {
                s.Step();
                s.CheckCollisionWall();
            }
            foreach (KeyValuePair<Star, bool> c in CheckCollision())
            {
                if (c.Value)
                {
                    c.Key.OnCollision(this);
                }
                else
                {
                    c.Key.OnNoCollision();
                }
            }
        }

        public IMemento<Galaxy> Save()
        {
            return new GalaxyMemento(Clone(null));
        }

        private List<KeyValuePair<Star, bool>> CheckCollision()
        {
            var stars = new List<KeyValuePair<Star, bool>>();
            foreach (Star s1 in this.stars)
            {
                bool colliding = false;
                foreach (Star s2 in this.stars)
                {
                    if (s1 != s2)
                    {
                        if (s1.HasCollision(s2))
                        {
                            colliding = true;
                        }
                    }
                }
                stars.Add(new KeyValuePair<Star, bool>(s1, colliding));
            }
            return stars;
        }

        public void Draw()
        {
            try
            {
                StarVisitor starVisitor = new StarVisitor(mainViewModel);
                ConnectionVisitor connectionVisitor = new ConnectionVisitor(mainViewModel);
                foreach (Star star in stars)
                {
                    star.Accept(starVisitor);
                    star.Accept(connectionVisitor);
                }
                mainViewModel.RaisePropertyChanged(() => mainViewModel.ObservableStars);
                mainViewModel.RaisePropertyChanged(() => mainViewModel.ObservableConnections);
            }
            catch (Exception e) { }
        }

        public Galaxy Clone(Dictionary<object, object> objectMap)
        {
            Galaxy g = new Galaxy(mainViewModel);
            var map = new Dictionary<object, object>();
            stars.ForEach(s => g.stars.Add(s.Clone(map)));
            return g;
        }
    }
}
