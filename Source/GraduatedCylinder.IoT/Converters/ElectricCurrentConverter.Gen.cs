using System;
using GraduatedCylinder.Units;

namespace GraduatedCylinder.Converters
{
    internal static partial class ElectricCurrentConverter
    {

        //todo: auto generate these methods from reflecting each units enumerations

        public static ElectricCurrent FromBase(float baseValue, ElectricCurrentUnits wantedUnits) {
            switch (wantedUnits) {
                //inline scale and offset calculations here.
            }
            throw new NotImplementedException("ElectricCurrentConverter.FromBase");
        }

        public static float ToBase(ElectricCurrent value) {
            switch (value.Units) {
                //inline scale and offset calculations here.
            }
            throw new NotImplementedException("ElectricCurrentConverter.ToBase");
        }

    }
}