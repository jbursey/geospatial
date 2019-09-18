using Geospatial.Algorithms.Trees;
using Geospatial.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Geospatial.Algorithms.Tests
{
    public class QuadTreeTests
    {
        
        [Fact]
        public void QuadTree_Insertion_Test()
        {
            QuadTree<Point> qt = new QuadTree<Point>(new Point(Constants.MIN_LNG, Constants.MIN_LAT), new Point(Constants.MAX_LNG, Constants.MAX_LAT), 2);

            Point p = new Point(-30, 7);
            qt.Insert(p);

            Assert.False(qt.SubdivisionOccurred);

            Point p2 = new Point(-30.5, 7);
            qt.Insert(p2);

            Assert.False(qt.SubdivisionOccurred);

            Point p3 = new Point(30, 7);
            qt.Insert(p3);

            Assert.True(qt.SubdivisionOccurred);
        }
    }
}
