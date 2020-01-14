using System;
using System.Collections.ObjectModel;

namespace GraduatedCylinder.Geo
{
    public class GeoTrail
    {
        private Collection<Datum> _trail = new Collection<Datum>();

        public class Datum
        {
            private readonly Heading _heading;
            private readonly GeoPosition _location;
            private readonly Speed _speed;
            private readonly DateTime _time;

            public Datum(DateTime time,
                         Latitude latitude,
                         Longitude longitude,
                         Length altitude = null,
                         Speed speed = null,
                         Heading heading = null) {
                _time = time;
                _location = new GeoPosition(latitude, longitude, altitude);
                _speed = speed;
                _heading = heading;
            }

            public Heading Heading {
                get { return _heading; }
            }

            public GeoPosition Location {
                get { return _location; }
            }

            public Speed Speed {
                get { return _speed; }
            }

            public DateTime Time {
                get { return _time; }
            }
        }
    }
}