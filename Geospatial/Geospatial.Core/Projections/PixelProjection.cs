using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core.Projections
{
    public class PixelProjection
    {
        private GoogleProjection _googleProjection;
        private const int TILE_SIZE = 256;
        private int WORLD_WIDTH_METERS;
        private int WORLD_HEIGHT_METERS;

        public PixelProjection()
        {
            _googleProjection = new GoogleProjection();
        }

        /// <summary>
        /// This method assumes 256px by 256px tile sizes. So here are a few examples to consider.
        /// Zoom 0: A single tile at 256px in width and height. So then pixel resolution = 256 / worldWidthMeters and 256 / worldheightMeters        
        /// </summary>
        /// <param name="point"></param>
        /// <param name="tileX"></param>
        /// <param name="tileY"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        public Point Convert(Point point, int tileX, int tileY, int zoom)
        {
            /*
             * Lets say we wanted to plot at tile 0,0 zoom 0 the point 32.0 latitude, -97.0 longitude.
             * single tile of 256px by 256px.
             * Algorithm:
             *    - convert point lat, lng to google coordinates
             *    - pixX = googleX / worldWidthMeters
             *    - pixY = googleY / worldHeightMeters
             */

            Point googPoint = _googleProjection.Convert(point);
            int numTiles = (int)Math.Pow(2, zoom);

            double xRatio = googPoint.X / Constants.WORLD_WIDTH_METERS;
            double yRatio = googPoint.Y / Constants.WORLD_HEIGHT_METERS;

            int xPixels = TILE_SIZE * numTiles;
            int yPixels = xPixels; //due to it being a square.

            int xPixel = (int)(xPixels * xRatio);
            int yPixel = (int)(yPixels * yRatio);

            int actualX = xPixel % TILE_SIZE;
            int actualY = yPixel % TILE_SIZE;

            return new Point(actualX, actualY);
        }
    }
}
