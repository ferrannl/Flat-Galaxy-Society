using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Memento
{
    public interface IMemento<T>
    {
        T GetState();
        DateTime GetDate();
    }
}
