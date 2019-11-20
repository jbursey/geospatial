using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    public class LineSegment
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public double Slope { get; set; }

        public double Intercept { get; set; }

        public LineSegment(double x1, double y1, double x2, double y2)
        {
            this.A = new Point(x1, y1);
            this.B = new Point(x2, y2);

            this.Slope = (B.Y - A.Y) / (B.X - A.X);
            this.Intercept = B.Y - (this.Slope * B.X);
        }

        public LineSegment(Point a, Point b) : this(a.X, a.Y, b.X, b.Y)
        {

        }

        public bool Intersects(LineSegment line)
        {
            /*
             * This line  --> Y = mX + b
             * Other line --> Y = nX + c
             * 
             * mX + b = nX + c
             * mX = nX + c - b
             * 
             * mX - nX = c - b
             * 
             * X(m-n) = c - b
             * 
             * X = (c - b) / (m - n)
             */

            double intersectionX = (line.Intercept - this.Intercept) / (this.Slope - line.Slope);
            double intersectionY = (this.Slope * intersectionX) + this.Intercept;

            //--check for inf            

            //--check if intersectionX and Y are "within" the segment
            if(intersectionX >= this.A.X && intersectionX <= this.B.X)
            {
                if(intersectionY >= this.A.Y && intersectionY <= this.B.Y)
                {
                    return true;
                }
            }

            return false;
        }


    }
}
