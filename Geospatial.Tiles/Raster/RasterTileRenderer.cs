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
                    RenderPolygon(poly, fillColor, g, tileX, tileY, zoom);
                }                
            }

            bitmap.Save($@"E:\img_{tileX}_{tileY}_{zoom}.png", System.Drawing.Imaging.ImageFormat.Png);

            return null;
        }

        public byte[] RenderPolygons(List<Polygon> polygons, int tileX, int tileY, int zoom)
        {
            Bitmap bitmap = new Bitmap(256, 256, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Random rand = new Random();

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                foreach (var poly in polygons)
                {
                    int red = rand.Next(0, 255);
                    int green = rand.Next(0, 255);
                    int blue = rand.Next(0, 255);
                    RenderPolygon(poly, Color.FromArgb(255, red, green, blue), g, tileX, tileY, zoom);
                }
            }

            bitmap.Save($@"E:\img_{tileX}_{tileY}_{zoom}.png", System.Drawing.Imaging.ImageFormat.Png);

            return null;
        }

        private void RenderPolygon(Polygon polygon, Color color, Graphics g, int tileX, int tileY, int zoom)
        {
            foreach (var ring in polygon.LinearRings)
            {
                List<PointF> points = new List<PointF>();
                foreach (var p in ring)
                {
                    Geospatial.Core.Point pixelPoint = _projection.Convert(p, tileX, tileY, zoom);
                    PointF pf = new PointF((float)pixelPoint.X, (float)pixelPoint.Y);
                    points.Add(pf);
                }

                g.FillPolygon(new SolidBrush(color), points.ToArray());
            }
        }
    }
}
