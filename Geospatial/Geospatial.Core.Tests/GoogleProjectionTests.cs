using Geospatial.Core.Projections;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Geospatial.Core.Tests
{
    public class GoogleProjectionTests
    {
        [Fact]
        public void GoogleProjection_Max()
        {
            Point max = new Point(Constants.MERCATOR_MAX_LNG, Constants.MERCATOR_MAX_LAT);

            GoogleProjection proj = new GoogleProjection();
            Point googlePoint = proj.Convert(max);

            int stop = 0;
        }

        [Fact]
        public void GoogleProjection_0_0()
        {
            Point worldTopLeft = new Point(Constants.MERCATOR_MIN_LNG, Constants.MERCATOR_MAX_LAT);

            GoogleProjection proj = new GoogleProjection();
            Point googlePonit = proj.Convert(worldTopLeft);

            int stop = 0;
        }

        [Fact]
        public void GoogleProjection_LatLng_0_0()
        {
            Point p = new Point(0, 0);

            GoogleProjection proj = new GoogleProjection();
            Point googlePoint = proj.Convert(p);

            int stop = 0;
        }
    }
}
