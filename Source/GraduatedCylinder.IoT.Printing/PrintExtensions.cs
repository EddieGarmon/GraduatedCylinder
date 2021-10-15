using System.Collections.Generic;
using System.Globalization;
using GraduatedCylinder.Units;

namespace GraduatedCylinder.IoT.Printing
{
    public static class PrintExtensions
    {

        static readonly Dictionary<int, string> PrecisionFormats = new Dictionary<int, string>();

        public static string ToString(this ElectricCurrent electricCurrent,
                                      ElectricCurrentUnit units = ElectricCurrentUnit.Unspecified,
                                      int precision = 4) {
            ElectricCurrent inUnits = electricCurrent.Units == units || units == ElectricCurrentUnit.Unspecified ?
                                          electricCurrent :
                                          electricCurrent.In(units);
            return string.Format(GetPrecisionFormat(precision), inUnits.Value, GetAbbreviation(inUnits.Units));
        }

        // todo: generate one of these per 'units' enum
        private static string GetAbbreviation(ElectricCurrentUnit unit) {
            //todo: generate this switch
            switch (unit) {
                case ElectricCurrentUnit.Ampere:
                    return "A";
                default:
                    return unit.ToString();
            }
        }

        private static string GetPrecisionFormat(int precision) {
            if (!PrecisionFormats.TryGetValue(precision, out string format)) {
                format = "{0:N[pre]} {1}".Replace("[pre]", precision.ToString(CultureInfo.InvariantCulture));
                PrecisionFormats.Add(precision, format);
            }
            return format;
        }

    }
}