using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Memento
{
    class GalaxyMemento : IMemento<Galaxy>
    {
        private Galaxy galaxy;
        private DateTime date;

        public GalaxyMemento(Galaxy galaxy)
        {
            this.galaxy = galaxy;
            date = DateTime.Now;
        }

        public Galaxy GetState()
        {
            return galaxy;
        }

        public DateTime GetDate()
        {
            return date;
        }
    }
}