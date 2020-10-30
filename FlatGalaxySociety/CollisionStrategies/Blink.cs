using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Blink : CollisionStrategy
    {
        private const string BLINK_COLOR = "yellow";
        public string starColor = null;

        public string StarColor
        {
            get { return starColor; }
            set { if (string.IsNullOrWhiteSpace(starColor)) { starColor = value; }; }
        }

        public override void OnCollision(Galaxy galaxy, Star star)
        {
            SetInitialStarColor(star);
            star.color = BLINK_COLOR;
        }

        public override void OnNoCollision(Star star)
        {
            SetInitialStarColor(star);
            star.color = starColor;
        }

        private void SetInitialStarColor(Star star)
        {
            if (string.IsNullOrEmpty(StarColor))
            {
                StarColor = star.color;
            }
        }

        public override string Type()
        {
            return "blink";
        }

        public override CollisionStrategy Clone(Dictionary<object, object> objectMap)
        {
            Blink s = new Blink();
            s.starColor = starColor;
            return s;
        }
    }
}