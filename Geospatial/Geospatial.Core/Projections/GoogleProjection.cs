using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core.Projections
{
    public class GoogleProjection
    {
        private MercatorProjection _mercatorProj;
        public GoogleProjection()
        {
            _mercatorProj = new MercatorProjection();
        }

        /// <summary>
        /// Google projection is always positive with +Y being down instead of up
        /// </summary>
        /// <param name="mercPoint"></param>
        /// <returns></returns>
        public Point Convert(Point point)
        {
            point = _mercatorProj.Convert(point);

            double width = _mercatorProj.EarthWidthMeters();
            double height = _mercatorProj.EarthHeightMeters();

            double x = point.X + (width / 2.0);
            double y = point.Y - (height / 2.0);
            //y = -y;
            return new Point(x, y);
        }
    }
}
