using Geospatial.Core.Projections;
using System;
using Xunit;

namespace Geospatial.Core.Tests
{
    public class MercatorProjectionTests
    {
        [Fact]
        public void MercatorProjection_Test_Simple()
        {
            Point p = new Point(0, 0);

            MercatorProjection proj = new MercatorProjection();
            Point mercPoint = proj.Convert(p);

            int stop = 0;
        }

    }
}
