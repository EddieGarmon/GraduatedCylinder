using GraduatedCylinder;

namespace JustUnits
{
    public class ResultViewModel
    {
        private readonly UnitOfMeasure _units;

        public ResultViewModel(UnitOfMeasure units) {
            _units = units;
        }

        public UnitOfMeasure Units {
            get { return _units; }
        }

        public string UnitsAbbreviation {
            get { return _units.Abbreviation; }
        }

        public string Value { get; set; }
    }
}