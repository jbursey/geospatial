using Geospatial.Core;
using Geospatial.IO;
using Geospatial.Tiles.Raster;
using System;
using System.Collections.Generic;
using Xunit;

namespace Geospatial.Tiles.Tests
{
    public class RasterTileTests
    {
        [Fact]
        public void RasterTile_Counties()
        {
            string path = @"Z:\geospatial\Geospatial\census_shp_files\cb_2018_us_county_20m\cb_2018_us_county_20m.shp";
            byte[] data = System.IO.File.ReadAllBytes(path);

            ShpReader reader = new ShpReader();
            reader.Parse(data);

            List<Polygon> polys = reader.OutPolygons;

            RasterTileRenderer renderer = new RasterTileRenderer();
            renderer.RenderPolygons(polys, 0, 0, 1);
            renderer.RenderPolygons(polys, 6, 13, 5);
            renderer.RenderPolygons(polys, 7, 13, 5);
            renderer.RenderPolygons(polys, 8, 13, 5);
            //renderer.RenderPolygons(polys, System.Drawing.Color.Blue, 0, 0, 1);
        }
    }
}
