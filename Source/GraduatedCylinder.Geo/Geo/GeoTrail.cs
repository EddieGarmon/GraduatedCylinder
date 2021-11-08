using System;
using System.Collections.ObjectModel;

namespace GraduatedCylinder.Geo
{
    public class GeoTrail
    {

        private Collection<Datum> _trail = new Collection<Datum>();

        public class Datum
        {

            public Datum(DateTime time,
                         Latitude latitude,
                         Longitude longitude,
                         Length altitude ,
                         Speed speed,
                         Heading heading = null) {
                Time = time;
                Location = new GeoPosition(latitude, longitude, altitude);
                Speed = speed;
                Heading = heading;
            }

            public Heading Heading { get; }

            public GeoPosition Location { get; }

            public Speed Speed { get; }

            public DateTime Time { get; }

        }

    }
}