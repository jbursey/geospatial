using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Geospatial.Core.Tests
{
    public class LineSegmentTests
    {
        [Fact]
        public void LineSegmentSimple()
        {
            LineSegment segment = new LineSegment(0, 0, 1, 1);

            Assert.Equal(1.0, segment.Slope);
            Assert.Equal(0, segment.Intercept);
        }

        [Fact]
        public void LineSegmentSimple2()
        {
            LineSegment segment = new LineSegment(1, 3, 2, 5);
            Assert.Equal(2.0, segment.Slope);
            Assert.Equal(0, segment.Intercept);
        }

        [Fact]
        public void LineSegmentIntersects()
        {
            LineSegment one = new LineSegment(0, 0, -1, 1);
            LineSegment two = new LineSegment(0, 10, 5, 15);

            one.Intersects(two);
        }

        [Fact]
        public void LineSegmentIntersectsParallel()
        {
            LineSegment one = new LineSegment(0, 10, 20, 10);
            LineSegment two = new LineSegment(0, -10, 30, -10);

            bool didIt = one.Intersects(two);

            Assert.False(didIt);
        }

        [Fact]
        public void LineSegmentIntersectsNorthSouth()
        {
            LineSegment vert = new LineSegment(0, -10, 0, 10);
            LineSegment horz = new LineSegment(-10, 0, 10, 0);

            bool didIt = vert.Intersects(horz);
            Assert.True(didIt);
        }

        [Fact]
        public void LineSegmentIntersectsVertical()
        {
            LineSegment vert1 = new LineSegment(0, -10, 0, 10);
            LineSegment vert2 = new LineSegment(5, -10, 5, 10);

            bool didIt = vert1.Intersects(vert2);
            Assert.False(didIt);
        }
    }
}
