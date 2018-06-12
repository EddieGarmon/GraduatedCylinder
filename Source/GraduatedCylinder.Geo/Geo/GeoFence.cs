using System;
using System.Collections.Generic;
using System.Linq;

namespace GraduatedCylinder.Geo
{
    public partial class GeoFence
    {
        public static Circle AsCircle(string id, GeoPosition center, Length radius) {
            return new Circle(id, center, radius);
        }

        public static Polygon AsPolygon(string id, IEnumerable<GeoPosition> corners) {
            return AsPolygon(id, corners.ToList());
        }

        public static Polygon AsPolygon(string id, List<GeoPosition> corners) {
            return new Polygon(id, corners);
        }

        //todo:
        //public static IGeoFence Parse(string value) {
        //    throw new NotImplementedException("GeoFence.Parse");
        //}
    }
}