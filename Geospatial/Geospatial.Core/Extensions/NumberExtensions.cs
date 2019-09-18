using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core.Extensions
{
    public static class NumberExtensions
    {
        public static double ToRadians(this int number)
        {
            return number * Constants.PI_180;
        }

        public static double ToDegrees(this int number)
        {
            return number * Constants.TO_DEGREES;
        }

        public static double ToRadians(this double number)
        {
            return number * Constants.PI_180;
        }

        public static double ToDegrees(this double number)
        {
            return number * Constants.TO_DEGREES;
        }
    }
}
