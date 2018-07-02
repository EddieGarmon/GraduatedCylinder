using System;
using System.Diagnostics;

namespace GraduatedCylinder
{
    internal class UnitOfMeasureLookup
    {
        private readonly SafeDictionary<string, UnitOfMeasure> _byAbbreviation =
            new SafeDictionary<string, UnitOfMeasure>();

        private readonly SafeDictionary<string, UnitOfMeasure> _byName = new SafeDictionary<string, UnitOfMeasure>();
        private readonly SafeDictionary<int, UnitOfMeasure> _byValue = new SafeDictionary<int, UnitOfMeasure>();
        private readonly DimensionType _dimensionType;

        public UnitOfMeasureLookup(DimensionType dimensionType) {
            _dimensionType = dimensionType;
        }

        public DimensionType DimensionType {
            get { return _dimensionType; }
        }

        public void Add(UnitOfMeasure unitOfMeasure) {
            try {
                _byAbbreviation.Add(unitOfMeasure.Abbreviation, unitOfMeasure);
                _byName.Add(unitOfMeasure.Name, unitOfMeasure);
                _byValue.Add(unitOfMeasure.EnumValue, unitOfMeasure);
            } catch (Exception) {
                string message = string.Format("UoM: {0} {1} ({2})",
                                               unitOfMeasure.Name,
                                               unitOfMeasure.Abbreviation,
                                               unitOfMeasure.EnumValue);
                Debug.WriteLine(message);
                throw;
            }
        }

        public UnitOfMeasure ByAbbreviation(string abbreviation) {
            return _byAbbreviation[abbreviation];
        }

        public UnitOfMeasure ByAbbreviationOrName(string abbreviationOrName) {
            return _byAbbreviation[abbreviationOrName] ?? _byName[abbreviationOrName];
        }

        public UnitOfMeasure ByName(string name) {
            return _byName[name];
        }

        public UnitOfMeasure ByValue(int value) {
            return _byValue[value];
        }

        internal void SetBase(int baseValue) {
            _byName.Add(UnitOfMeasure.BaseUnit, _byValue[baseValue]);
            UnitOfMeasure baseUnits = _byValue[baseValue];
            foreach (UnitOfMeasure unitOfMeasure in _byValue.Values) {
                unitOfMeasure.BaseUnits = baseUnits;
            }
        }
    }
}