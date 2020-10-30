using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Normal : ISpeedState
    {
        public string GetState()
        {
            return "normal";
        }
    }
}