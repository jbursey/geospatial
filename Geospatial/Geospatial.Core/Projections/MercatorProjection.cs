using Geospatial.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core.Projections
{
    /// <summary>
    /// Mercator assumes that 0,0 is roughly off the coast of Africa. All units of measure
    /// in mercator projection are meters from coordinate 0,0
    /// </summary>
    public class MercatorProjection
    {
        public MercatorProjection()
        {

        }

        public Point Convert(Point point)
        {
            //first we need to convert point x y to radians
            double radX = point.X.ToRadians();
            double radY = point.Y.ToRadians();
            double R = Constants.EARTH_RADIUS_EQUATOR_METERS;

            Point radPoint = new Point(radX, radY);

            //x
            double mercX = R * (radX - 0);

            //y
            double pi_4 = Math.PI / 4.0;
            double latTemp = radY / 2.0;

            double mercY = R * Math.Log(Math.Tan(pi_4 + latTemp));


            return new Point(mercX, mercY);
        }

        //private Point? _mercSW;
        //public Point MercatorSW
        //{
        //    get
        //    {
        //        if(!_mercSW.HasValue)
        //        {
        //            Point sw = new Point(Constants.MERCATOR_MIN_LNG, Constants.MERCATOR_MIN_LAT);
        //            Point ne = new Point(Constants.MERCATOR_MAX_LNG, Constants.MERCATOR_MAX_LAT);
        //        }

        //        return _mercSW.Value;
        //    }
        //}

        //public double EarthWidthMeters()
        //{
        //    Point sw = new Point(Constants.MERCATOR_MIN_LNG, Constants.MERCATOR_MIN_LAT);
        //    Point ne = new Point(Constants.MERCATOR_MAX_LNG, Constants.MERCATOR_MAX_LAT);
        //    sw = Convert(sw);
        //    ne = Convert(ne);

        //    return ne.X - sw.X;
        //}

        //public double EarthHeightMeters()
        //{
        //    Point sw = new Point(Constants.MERCATOR_MIN_LNG, Constants.MERCATOR_MIN_LAT);
        //    Point ne = new Point(Constants.MERCATOR_MAX_LNG, Constants.MERCATOR_MAX_LAT);
        //    sw = Convert(sw);
        //    ne = Convert(ne);

        //    return ne.Y - sw.Y;
        //}
    }
}
