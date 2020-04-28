using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanceFlow.Models
{
    public class Extensions //умное округление 
    {
        public static Double? RoundSmart(object input)
        {
            if (input is null) return null;

            if (Double.TryParse(input?.ToString(), out double value))
            {
                double absValue = Math.Abs(value);

                if (absValue <= 0.000001) value = Math.Round(value, 8);
                else if (absValue <= 0.00001) value = Math.Round(value, 7);
                else if (absValue <= 0.0001) value = Math.Round(value, 6);
                else if (absValue <= 0.001) value = Math.Round(value, 5);
                else if (absValue <= 0.01) value = Math.Round(value, 4);
                else if (absValue <= 0.1) value = Math.Round(value, 3);
                else if (absValue <= 100) value = Math.Round(value, 2);
                else if (absValue <= 500) value = Math.Round(value, 1);
                else value = Math.Round(value);

                return value;
            }

            return null;
        }
    }

}
