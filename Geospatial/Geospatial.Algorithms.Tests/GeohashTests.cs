using Geospatial.Core;
using System;
using System.Collections.Generic;
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

        [Fact]
        public void Geohash_Stress()
        {
            Random rand = new Random();
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            List<string> hashes = new List<string>();            
            for(int i = 0; i < 100; i++)
            {
                double x = rand.Next(-179, 179);
                double y = rand.Next(-85, 85);
                string hash = Geohash.FromPoint(new Point(x, y), 6);
                //hashes[i] = hash;
                hashes.Add(hash);
            }

            sw.Stop();
            long ms = sw.ElapsedMilliseconds;            

            int stop = 0;
        }
    }
}
