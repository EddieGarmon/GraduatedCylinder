using System;
using System.Diagnostics;
using GraduatedCylinder.Geo;

namespace GraduatedCylinder.Devices.Gps.Nmea
{
    internal class SentenceHelper
    {
        /// <summary>
        /// Parses the latitude.
        /// formats supported:
        /// 0) [empty] = latitude 0
        /// 1) dd
        /// 2) ddmm
        /// 3) ddmm.mmmm
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public static Latitude ParseLatitude(string value, string direction) {
            double degrees = 0,
                   minutes = 0;
            int length = value.Length;
            if (length >= 2) {
                double.TryParse(value.Substring(0, 2), out degrees);
            }
            if (length >= 4) {
                double.TryParse(value.Substring(2), out minutes);
                degrees += (minutes / 60);
            }
            return (direction == "S") ? -degrees : degrees;
        }

        public static Length ParseLength(string value, string units) {
            if (units != "M") {
                Debug.Assert(false, "Units other than meters.");
                return null;
            }
            double length;
            return double.TryParse(value, out length) ? new Length(length, LengthUnit.Meter) : null;
        }

        /// <summary>
        /// Parses the longitude.
        /// formats supported:
        /// 0) [empty] = longitude 0
        /// 1) ddd
        /// 2) dddmm
        /// 3) dddmm.mmmm
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="direction">The direction.</param>
        /// <returns></returns>
        public static Longitude ParseLongitude(string value, string direction) {
            double degrees = 0,
                   minutes = 0;
            int length = value.Length;
            if (length >= 3) {
                double.TryParse(value.Substring(0, 3), out degrees);
            }
            if (length >= 5) {
                double.TryParse(value.Substring(3), out minutes);
                degrees += (minutes / 60);
            }
            return (direction == "W") ? -degrees : degrees;
        }

        /// <summary>
        /// Parses the utc date.
        /// formats supported:
        /// ddmmyy
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime ParseUtcDate(string value) {
            if (value.Length != 6) {
                return DateTime.MinValue.Date;
            }

            int.TryParse(value.Substring(0, 2), out int day);
            int.TryParse(value.Substring(2, 2), out int month);
            int.TryParse(value.Substring(4), out int year);
            // NB: Fix this after year 2100
            year += 2000;
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Parses the utc time.
        /// formats supported:
        /// 0) [empty] = time 0
        /// 1) hh
        /// 2) hhmm
        /// 3) hhmmss
        /// 4) hhmmss.sss
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TimeSpan ParseUtcTime(string value) {
            int hours = 0,
                minutes = 0,
                seconds = 0,
                milliseconds = 0;
            int length = value.Length;
            if (length >= 2) {
                int.TryParse(value.Substring(0, 2), out hours);
            }
            if (length >= 4) {
                int.TryParse(value.Substring(2, 2), out minutes);
            }
            if (length >= 6) {
                int.TryParse(value.Substring(4, 2), out seconds);
            }
            if (length >= 10) {
                int.TryParse(value.Substring(7, 3), out milliseconds);
            }
            return new TimeSpan(0, hours, minutes, seconds, milliseconds);
        }
    }
}