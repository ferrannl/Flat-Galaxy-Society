using FlatGalaxySociety.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatGalaxySociety.Models
{
    public class Shortcut : ICloneable<Shortcut>
    {
        public string Name { get; set; }
        public ICommand Command { get; set; }
        public Key Key { get; set; }
        public char KeyChar { get; set; }

        public Shortcut(string name, ICommand command, Key key)
        {
            Name = name;
            Command = command;
            Key = key;
            KeyChar = (char)KeyInterop.VirtualKeyFromKey(key);
        }

        public Shortcut Clone(Dictionary<object, object> objectMap)
        {
            return new Shortcut(Name, Command, Key);
        }
    }
}
