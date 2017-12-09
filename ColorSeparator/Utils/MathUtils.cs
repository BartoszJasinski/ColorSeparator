using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSeparator.Utils
{
    class MathUtils
    {

        public static double ConvertRange(double originalMin, double originalMax, double newMin, double newMax, double value)
        {
            double scale = (newMax - newMin) / (originalMax - originalMin);
            return (newMin + ((value - originalMin) * scale));
        }
    }
}
