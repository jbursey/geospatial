using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Geospatial.Core.Tests
{
    public class PolygonTests
    {
        [Fact]
        public void Polygon_ContainsPointSimple()
        {
            List<Point> points = new List<Point>();
            points.Add(new Point(0, 0));
            points.Add(new Point(0, 10));
            points.Add(new Point(10, 10));
            points.Add(new Point(10, 0));
            points.Add(new Point(0, 0));

            Polygon poly = new Polygon();
            poly.LinearRings.Add(points);

            Point itDoes = new Point(5, 5);

            bool didIt = poly.ContainsPoint(itDoes);
            Assert.True(didIt);

            Point nuhUh = new Point(-500, 650);
            bool noItDidnt = poly.ContainsPoint(nuhUh);
            Assert.False(noItDidnt);
        }
    }
}
