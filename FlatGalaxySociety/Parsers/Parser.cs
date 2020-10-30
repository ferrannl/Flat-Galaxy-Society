using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public abstract class Parser
    {
        protected abstract string FileType();

        public bool CanParse(string fileType)
        {
            return fileType.ToLower().Equals(FileType());
        }

        public abstract void Parse(List<string> content, out List<List<KeyValuePair<string, string>>> starList, out List<KeyValuePair<string, string>> neighbourList);
    }
}