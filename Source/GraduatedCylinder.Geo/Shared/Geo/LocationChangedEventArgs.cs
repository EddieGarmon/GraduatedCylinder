using System;
using System.Collections.Generic;
using System.Text;

namespace GraduatedCylinder.Geo
{
    public class LocationChangedEventArgs
    {
        private readonly GeoPosition _position;
        private readonly Heading _heading;

        public LocationChangedEventArgs(GeoPosition position, Heading heading) {
            _position = position;
            _heading = heading;
        }

        public GeoPosition Position {
            get { return _position; }
        }

        public Heading Heading {
            get { return _heading; }
        }
    }
}