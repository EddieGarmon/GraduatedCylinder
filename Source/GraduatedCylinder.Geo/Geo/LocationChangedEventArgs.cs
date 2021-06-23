using System;
using GraduatedCylinder.Devices.Gps;

namespace GraduatedCylinder.Geo
{
    public class LocationChangedEventArgs
    {

        public LocationChangedEventArgs(DateTimeOffset time,
                                        GeoPosition position,
                                        Heading heading,
                                        Speed speed,
                                        GpsFixType fixType) {
            Time = time;
            Position = position;
            Heading = heading;
            Speed = speed;
            FixType = fixType;
        }

        public GpsFixType FixType { get; }

        public Heading Heading { get; }

        public GeoPosition Position { get; }

        public Speed Speed { get; }

        public DateTimeOffset Time { get; }

    }
}