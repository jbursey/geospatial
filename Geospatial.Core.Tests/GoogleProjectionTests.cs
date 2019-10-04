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
    }
}
