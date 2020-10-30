using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatGalaxySociety
{
    public class Pause : ISpeedState
    {
        public string GetState()
        {
            return "pause";
        }
    }
}