using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    public class MultiPolygon
    {
        public MultiPolygon()
        {
            Polygons = new List<Polygon>();
        }

        public List<Polygon> Polygons { get; set; }
    }
}
