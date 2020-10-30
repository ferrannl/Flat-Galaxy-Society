using System;
using FlatGalaxySociety.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class GalaxyBuilder
    {
        private StarFactory starFactory;
        private Galaxy galaxy;

        public GalaxyBuilder(Galaxy galaxy)
        {
            this.galaxy = galaxy;
            starFactory = StarFactory.Instance;
        }

        public void AddStar(List<KeyValuePair<string, string>> star)
        {
            try
            {
                Star s = starFactory.CreateStar(
                    star.Where(s1 => s1.Key.Equals("type")).First().Value,
                    star.Where(s2 => s2.Key.Equals("name")).First().Value,
                    ToDouble(star.Where(s3 => s3.Key.Equals("x")).First().Value),
                    ToDouble(star.Where(s4 => s4.Key.Equals("y")).First().Value),
                    ToDouble(star.Where(s5 => s5.Key.Equals("vx")).First().Value),
                    ToDouble(star.Where(s6 => s6.Key.Equals("vy")).First().Value),
                    int.Parse(star.Where(s7 => s7.Key.Equals("radius")).First().Value),
                    star.Where(s8 => s8.Key.Equals("oncollision")).First().Value,
                    star.Where(s9 => s9.Key.Equals("color")).First().Value
                    );
                galaxy.stars.Add(s);
            }
            catch (Exception e)
            {
                throw new Exception("Bestand inhoud is niet valide.");
            }
        }

        private static double ToDouble(string s)
        {
            s = s.Replace('.', ',');
            if (double.TryParse(s, out var result))
                return result;
            throw new ArgumentException("Failed to parse a string to a double!");
        }

        public void LinkStars(string starName1, string starName2)
        {
            List<Planet> planets = galaxy.stars.Where(s => s.GetType() == typeof(Planet)).Select(s => (Planet)s).ToList();

            Planet p1 = planets.Where(p => p.name.Equals(starName1)).FirstOrDefault();
            Planet p2 = planets.Where(p => p.name.Equals(starName2)).FirstOrDefault();
            if (p1 != null && p2 != null)
            {
                p1.neighbours.Add(p2);
            }
            else
            {
                throw new InvalidLinkAttemptException("Invalid linkattempt, could not find planet. Planet1 = " + p1 + " Planet 2 = " + p2);
            }
        }

        public Galaxy Build()
        {
            return galaxy;
        }
    }
}