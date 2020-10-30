using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public abstract class Importer
    {
        public string Import()
        {
            string path = OpenPrompt();
            return PrependType(path);
        }

        public abstract string OpenPrompt();

        public abstract string PrependType(string path);
    }
}