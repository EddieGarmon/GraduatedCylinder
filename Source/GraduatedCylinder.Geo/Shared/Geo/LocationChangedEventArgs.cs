using System;
using System.Collections.Generic;
using System.Text;

namespace GraduatedCylinder.Geo
{
    public class LocationChangedEventArgs
    {
        public LocationChangedEventArgs(GeoPosition position, Heading heading) {
            Position = position;
            Heading = heading;
        }

        public GeoPosition Position { get; set; }

        public Heading Heading { get; set; }
    }
}
