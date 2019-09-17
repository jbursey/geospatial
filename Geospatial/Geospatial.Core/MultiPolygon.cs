using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    /// <summary>
    /// Follows the well known binary setup
    /// </summary>
    public class MultiPolygon
    {
        public MultiPolygon()
        {
            Polygons = new List<Polygon>();
        }

        public List<Polygon> Polygons { get; set; }
    }
}
