using System;
using System.Collections.Generic;
using System.IO;

namespace FlatGalaxySociety
{
    public abstract class Reader
    {
        protected abstract string ImportType();

        public bool CanRead(string filePath)
        {
            return filePath.StartsWith(ImportType());
        }

        public List<string> Read(string filePath)
        {
            string path = RemoveImportType(filePath);
            List<string> result = new List<string>();
            result.Add(GetType(path));
            result.AddRange(DoRead(path));
            return result;
        }

        public string RemoveImportType(string filePath)
        {
            return filePath.Substring(ImportType().Length);
        }

        public string GetType(string filePath)
        {
            string[] words = filePath.Split('.');
            return words[words.Length - 1];
        }

        public abstract List<string> DoRead(string filePath);

        public List<string> GetLines(StreamReader file)
        {
            int counter = 0;
            string ln;
            List<string> lines = new List<string>();

            while ((ln = file.ReadLine()) != null)
            {
                lines.Add(ln);
                counter++;
            }
            return lines;
        }
    }
}