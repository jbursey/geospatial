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



    #region 
    public class std_vector<T>
    {

    }
    #endregion

}
