﻿namespace GraduatedCylinder.Geo;

public partial class GeoFence
{

    public class Polygon : IGeoFence
    {

        private readonly List<GeoPosition> _corners;

        public Polygon(string id, List<GeoPosition> corners) {
            Id = id;
            _corners = corners;

            //todo: compute the bounding box for a quick out in IsInside
        }

        public string Id { get; }

        public IEnumerable<GeoPosition> Points => _corners;

        public bool IsInside(GeoPosition position) {
            //todo first check if in bounding box

            bool result = false;
            for (int i = 0, j = _corners.Count - 1; i < _corners.Count; j = i, i++) {
                GeoPosition p1 = _corners[i];
                GeoPosition p2 = _corners[j];
                if ((p1.Latitude < position.Latitude && position.Latitude <= p2.Latitude) ||
                    (p2.Latitude < position.Latitude && position.Latitude <= p1.Latitude)) {
                    if (p1.Longitude + (position.Latitude - p1.Latitude) / (p2.Latitude - p1.Latitude) * (p2.Longitude - p1.Longitude) <
                        position.Longitude) {
                        result = !result;
                    }
                }
            }
            return result;
        }

    }

}