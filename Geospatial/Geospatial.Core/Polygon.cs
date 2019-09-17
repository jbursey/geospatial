using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    /// <summary>
    /// This class follows the same structure as a WKB structured polygon
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
