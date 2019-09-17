using Geospatial.Core;
using System;
using Xunit;

namespace Geospatial.Algorithms.Tests
{
    public class GethashTests
    {
        [Fact]
        public void Geohash_To_Point()
        {
            string hash = "9vfg"; //haslet/keller/grapevine

            Point point = Geohash.ToPoint(hash);

            int stop = 0;
        }

        [Fact]
        public void Geohash_To_Point2()
        {
            string hash = "9ven09qv"; //31.99999809, -96.99983597

            Point point = Geohash.ToPoint(hash);

            int stop = 0;
        }

        [Fact]
        public void Geohash_To_Point3()
        {
            string hash = "9v";
            Point point = Geohash.ToPoint(hash);

            int stop = 0;
        }

        [Fact]
        public void Point_To_Geohash()
        {
            Point p = new Point(-97.0, 32.0);
            string hash = Geohash.FromPoint(p, 5);
        }
    }
}
