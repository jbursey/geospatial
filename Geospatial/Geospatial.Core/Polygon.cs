using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    /// <summary>
    /// Follows the well known binary setup
    /// </summary>
    public class Polygon : ISpatialElement, IQuadTreeElement
    {
        public Polygon()
        {
            LinearRings = new List<List<Point>>();
        }

        public List<List<Point>> LinearRings { get; set; }
        public List<Point> ExteriorRing
        {
            get
            {
                if (LinearRings.Count > 0)
                {
                    return LinearRings[0];
                }

                return new List<Point>();
            }
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
            double minX = 99999999999;
            double minY = 99999999999;
            double maxX = -99999999999;
            double maxY = -99999999999;

            MBR mbr = new MBR();

            foreach(var ring in LinearRings)
            {
                foreach(var p in ring)
                {
                    if(p.X < minX)
                    {
                        minX = p.X;
                    }
                    if(p.Y < minY)
                    {
                        minY = p.Y;
                    }
                    if(p.X > maxX)
                    {
                        maxX = p.X;
                    }
                    if(p.Y > maxY)
                    {
                        maxY = p.Y;
                    }

                }
            }

            mbr.Southwest = new Point(minX, minY);
            mbr.Northeast = new Point(maxX, maxY);

            return mbr;
        }

        public bool ContainedWithin(double swX, double swY, double neX, double neY)
        {            
            foreach(var ring in LinearRings)
            {
                foreach(var p in ring)
                {
                    if(swX <= p.X && swY <= p.Y && neX >= p.X && neY >= p.Y)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// This will check if the current polygon intersects in anyway with the parameter polygon
        /// </summary>
        /// <param name="polygon">The polygon you want to see if it contains any point</param>
        /// <returns></returns>
        public bool ContainsAny(Polygon polygon)
        {
            foreach (var ring in LinearRings)
            {
                foreach (var p in ring)
                {
                    if (polygon.ContainsPoint(p))
                    {
                        return true;
                    }
                }
            }

            return true;
        }
    }
}
