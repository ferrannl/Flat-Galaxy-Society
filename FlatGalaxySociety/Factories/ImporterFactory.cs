using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class ImporterFactory
    {
        private static ImporterFactory instance;

        public static ImporterFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ImporterFactory();
                }
                return instance;
            }
        }

    public Importer CreateImporter(string importType)
    {
        if (importType.Equals("disc"))
        {
            return new DiscImporter();
        }
        else if (importType.Equals("http"))
        {
            return new HttpImporter();
        }
        throw new Exception("Importeer type wordt niet ondersteund.");
    }
}
}