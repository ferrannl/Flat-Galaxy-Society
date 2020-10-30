using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class ReaderFactory
    {
        private static ReaderFactory instance;

        public static ReaderFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReaderFactory();
                }
                return instance;
            }
        }

        public Reader CreateReader(string filePath)
        {
            Type type = typeof(Reader);
            IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (Type t in types)
            {
                if (!t.IsAbstract)
                {
                    Reader reader = (Reader)Activator.CreateInstance(t);
                    if (reader.CanRead(filePath))
                    {
                        return reader;
                    }
                }
            }

            throw new Exception("Bestand type wordt niet ondersteund.");
        }
    }
}