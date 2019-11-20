using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    public class MBR
    {
        public MBR()
        {
            
        }

        public Point Northeast { get; set; }
        public Point Southwest { get; set; }

        public bool ContainsPoint(Point p)
        {
            if(p.X >= Southwest.X && p.X <= Northeast.X && p.Y >= Southwest.Y && p.Y <= Northeast.Y)
            {
                return true;
            }

            return false;
        }

        public Polygon ToPolygon()
        {
            Polygon p = new Polygon();

            List<Point> points = new List<Point>();

            Point nw = new Point(Southwest.X, Northeast.Y);
            Point se = new Point(Northeast.X, Southwest.Y);

            points.Add(nw);
            points.Add(Northeast);
            points.Add(se);
            points.Add(Southwest);
            points.Add(nw);

            return p;
        }
    }

}
