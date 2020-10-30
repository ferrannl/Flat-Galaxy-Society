using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace FlatGalaxySociety
{
    public class HttpReader : Reader
    {
        protected override string ImportType()
        {
            return "http";
        }

        public override List<string> DoRead(string filePath)
        {
            WebRequest webRequest = WebRequest.Create(filePath);
            using (var response = webRequest.GetResponse())
            using (var content = response.GetResponseStream())
            using (var file = new StreamReader(content))
            {
                var lines = GetLines(file);
                file.Close();
                return lines;
            }
            throw new Exception("URI is niet geldig.");
        }
    }
}