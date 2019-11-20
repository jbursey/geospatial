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

        /// <summary>
        /// Uses the raycasting algorithm
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool ContainsPoint(Point p)
        {
            //the point must at least be in the bounding box to continue below
            MBR mbr = this.GetMBR();
            if(!mbr.ContainsPoint(p))
            {
                return false;
            }

            #region Partial Differential Equation Theory or simple line
            //---Line intersection
            /*
             * Lets consider 2 lines
             * Y = X + 1
             * Y = -5X -2
             * 
             * To see if they intersect lets set them equal to each other
             * X + 1 = -5X - 2
             * 
             * Solve for X
             * 
             * 6X = -3
             * X = -1/2
             * 
             * Plug back into original equations
             * 
             * Y = 1/2
             * 
             * These lines cross at (-1/2, 1/2)
             */

            //---Finding the intercept
            /*
             * Equation of a line --> Y = mX + b
             * 
             * m = (Y2 - Y1) / (X2 - X1)
             * 
             * b = Y - mX
             * 
             * Lets consider the 2 points
             * (1, 3) and (2,5)
             * 
             * m = 2
             * 
             * b = 3 - 2(1) = 1
             * 
             * Line --> Y = 2X + 1
             */
            #endregion

            Point rayEnd = new Point(p.X + 1000000, p.Y);
            LineSegment ray = new LineSegment(p, rayEnd);
            int crossCount = 0;
            bool itDoes = false;

            foreach(List<Point> ring in this.LinearRings)
            {
                for(int i = 0; i < ring.Count - 1; i++)
                {
                    Point current = ring[i];
                    Point next = ring[i + 1];
                    LineSegment segment = new LineSegment(current, next);

                    //--does the "segment" intersect the "ray"
                    if(segment.Intersects(ray))
                    {
                        ++crossCount;
                        itDoes = !itDoes;
                    }
                }
            }

            return itDoes;
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
