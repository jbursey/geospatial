using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    /// <summary>
    /// Follows the well known binary setup
    /// </summary>
    public class Polygon
    {
        public Polygon()
        {

        }

        public bool ContainsPoint(Point p)
        {
            return false;
        }

        public bool ContainsPoly(Polygon poly)
        {
            return false;
        }

        public bool Intersects(Polygon poly)
        {
            return false;
        }

        public double GetArea()
        {
            return 0;
        }

        public MBR GetMBR()
        {
            return new MBR();
        }
    }
}
