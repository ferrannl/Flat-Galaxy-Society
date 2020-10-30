using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class DiscImporter : Importer
    {
        public override string OpenPrompt()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                return ofd.FileName;
            }
            throw new NoFileSelectedException("Selecteer een bestand.");
        }

        public override string PrependType(string path)
        {
            return $"disc{path}";
        }
    }
}