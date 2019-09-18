using System;

namespace Geospatial.Core
{
    public struct Point : IEquatable<Point>, ISpatialElement, IQuadTreeElement
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

        public bool ContainedWithin(double swX, double swY, double neX, double neY)
        {
            if(X >= swX && Y >= swY && X <= neX && Y <= neY)
            {
                return true;
            }

            return false;
        }        

        public bool ContainsAny(Polygon polygon)
        {
            if (polygon.ContainsPoint(this))
            {
                return true;
            }

            return false;
        }
    }
}
