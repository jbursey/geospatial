using System;
using Xunit;
using static Geospatial.IO.ShpReader;

namespace Geospatial.IO.Tests
{
    public class ShpReaderTests
    {
        [Fact]
        [Trait("Category", "FileSystem")]
        public void Shp_Parse_States()
        {
                          //Z:\geospatial\Geospatial\census_shp_files\cb_2018_us_state_5m\cb_2018_us_state_5m.shp
            string path = @"Z:\geospatial\Geospatial\census_shp_files\cb_2018_us_state_5m\cb_2018_us_state_5m.shp";
            byte[] data = System.IO.File.ReadAllBytes(path);

            ShpReader reader = new ShpReader();
            reader.Parse(data);

            Assert.NotNull(reader.OutPolygons);
            Assert.True(reader.OutPolygons.Count == 56);
        }
    }
}
