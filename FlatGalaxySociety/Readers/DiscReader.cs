using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class DiscReader : Reader
    {
        protected override string ImportType()
        {
            return "disc";
        }

        public override List<string> DoRead(string filePath)
        {
            if (File.Exists(filePath))
            {
                using (var file = new StreamReader(filePath))
                {
                    var lines = GetLines(file);
                    file.Close();
                    return lines;
                }
            }
            throw new Exception("Bestand bestaat niet.");
        }
    }
}