using System;

namespace GraduatedCylinder
{
    public class PercentGradeUnitConverter : IUnitConverter
    {
        // radians is base unit

        public double FromBaseUnit(double value) {
            return Math.Tan(value) * 100;
        }

        public double ToBaseUnit(double value) {
            return Math.Atan(value / 100);
        }
    }
}