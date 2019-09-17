using System;

namespace Geospatial.Core
{
    public struct Point : IEquatable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            double epsilom = 0.00000001;

            if ((this.X - other.X) < epsilom)
            {
                if((this.Y - other.Y) < epsilom)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
