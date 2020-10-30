using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace FlatGalaxySociety
{
    public class XmlParser : Parser
    {
        protected override string FileType()
        {
            return "xml";
        }

        public override void Parse(List<string> content, out List<List<KeyValuePair<string, string>>> starList, out List<KeyValuePair<string, string>> neighbourList)
        {
            try
            {
                starList = new List<List<KeyValuePair<string, string>>>();
                neighbourList = new List<KeyValuePair<string, string>>();

                XmlDocument xml = new XmlDocument();
                xml.LoadXml(string.Join("", content.Skip(2)));

                XmlNodeList xnList = xml.SelectNodes("/galaxy/planet");
                foreach (XmlNode xn in xnList)
                {
                    starList.Add(getStar(xn));
                    neighbourList.AddRange(getNeighbours(xn));
                }

                xnList = xml.SelectNodes("/galaxy/asteroid");
                foreach (XmlNode xn in xnList)
                {
                    starList.Add(getStar(xn));
                }
            }
            catch (Exception e)
            {
                throw new Exception("Bestands inhoud is niet valide.");
            }
        }

        private List<KeyValuePair<string, string>> getStar(XmlNode xn)
        {
            var star = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("type", xn.LocalName),
                new KeyValuePair<string, string>("name", xn["name"] != null ? xn["name"].InnerText : ""),
                new KeyValuePair<string, string>("x", xn["position"]["x"].InnerText),
                new KeyValuePair<string, string>("y", xn["position"]["y"].InnerText),
                new KeyValuePair<string, string>("vx", xn["speed"]["x"].InnerText),
                new KeyValuePair<string, string>("vy", xn["speed"]["y"].InnerText),
                new KeyValuePair<string, string>("radius", xn["position"]["radius"].InnerText),
                new KeyValuePair<string, string>("color", xn["color"].InnerText),
                new KeyValuePair<string, string>("oncollision", xn["oncollision"].InnerText)
            };
            return star;
        }

        private List<KeyValuePair<string, string>> getNeighbours(XmlNode xn)
        {
            var neighbours = new List<KeyValuePair<string, string>>();
            var xnList = xn.SelectNodes("neighbours/planet");
            foreach (XmlNode xnNeighbour in xnList)
            {
                neighbours.Add(new KeyValuePair<string, string>(xn["name"].InnerText, xnNeighbour.InnerText));
            }
            return neighbours;
        }
    }
}