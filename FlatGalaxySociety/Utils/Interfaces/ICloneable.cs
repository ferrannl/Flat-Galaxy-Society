using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Utils.Interfaces
{
    public interface ICloneable<T>
    {
        T Clone(Dictionary<object, object> objectMap);
    }
}
