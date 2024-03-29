﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    public static class Constants
    {
        public const double MIN_LAT = -90.0;
        public const double MIN_LNG = -180.0;
        public const double MAX_LAT = 90.0;
        public const double MAX_LNG = 180.0;

        public const double EARTH_RADIUS_EQUATOR_METERS = 6378137.0;
        public const double EARTH_RADIUS_POLAR_METERS = 6356752.3;

        public const double WORLD_WIDTH_METERS = 40075016.685578488;
        public const double WORLD_HEIGHT_METERS = 40075017.253858209;

        public const double MERCATOR_MAX_LNG = 180.0;
        public const double MERCATOR_MIN_LNG = -180.0;
        public const double MERCATOR_MAX_LAT = 85.051129;
        public const double MERCATOR_MIN_LAT = -85.051129;

        public const double PI_180 = 0.017453292519943295;
        public const double TO_DEGREES = 57.2957795130823208;
        public const double PI = 3.141592653589793;
    }
}
