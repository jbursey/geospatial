using Geospatial.Core;
using Geospatial.Core.Projections;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Geospatial.Tiles.Raster
{
    public class RasterTileRenderer
    {
        PixelProjection _projection;

        public RasterTileRenderer()
        {
            _projection = new PixelProjection();
        }

        public byte[] RenderPolygons(List<Polygon> polygons, Color fillColor, int tileX, int tileY, int zoom)
        {
            Bitmap bitmap = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                
                foreach(var poly in polygons)
                {                    
                    foreach(var ring in poly.LinearRings)
                    {
                        List<PointF> points = new List<PointF>();
                        foreach(var p in ring)
                        {
                            Geospatial.Core.Point pixelPoint = _projection.Convert(p, tileX, tileY, zoom);
                            PointF pf = new PointF((float)pixelPoint.X, (float)pixelPoint.Y);
                            points.Add(pf);
                        }

                        g.FillPolygon(new SolidBrush(fillColor), points.ToArray());
                    }
                }                
            }

            bitmap.Save(@"E:\img.png", System.Drawing.Imaging.ImageFormat.Png);

            return null;
        }
    }
}
