using Geospatial.Core.Projections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Geospatial.Core.Tests
{
    public class PixelProjectionTests
    {
        [Fact]
        public void PixelProjection_Tile_0_0()
        {
            PixelProjection projection = new PixelProjection();
            Point p = new Point(-97.0, 32.0); //texas dfw area

            Point pixel = projection.Convert(p, 7, 13, 5);

            int stop = 0;
        }
    }
}
