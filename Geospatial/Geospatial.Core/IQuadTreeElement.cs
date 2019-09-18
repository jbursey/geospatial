using System;
using System.Collections.Generic;
using System.Text;

namespace Geospatial.Core
{
    public interface IQuadTreeElement
    {
        bool ContainedWithin(double swX, double swY, double neX, double neY);
        bool ContainsAny(Polygon polygon);
    }
}
