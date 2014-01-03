using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Caliburn.Micro;
using GraduatedCylinder;

namespace JustUnits
{
    public class ShellViewModel : PropertyChangedBase,
                                  IShell
    {
        private readonly List<string> _dimensions = EnumReflector.DescribeAllValues<DimensionType>()
                                                                 .Select(x => x.Name)
                                                                 .Where(x => x != "Unknown")
                                                                 .Where(x => x != "SpeedSquared")
                                                                 .ToList();
        private readonly BindableCollection<ResultViewModel> _results = new BindableCollection<ResultViewModel>();

        private DimensionType _currentDimension;
        private List<string> _outputs;
        private string _selectedDimension;
        private string _selectedSourceUnit;
        private List<string> _sourceUnits;
        private string _userInput;

        public List<string> Dimensions {
            get { return _dimensions; }
        }

        public BindableCollection<ResultViewModel> Results {
            get { return _results; }
        }

        public string SelectedDimension {
            get { return _selectedDimension; }
            set {
                _selectedDimension = value;
                NotifyOfPropertyChange(() => SelectedDimension);
                _currentDimension = EnumReflector.Parse<DimensionType>(value);
                EnumValueDescriptor<DimensionType> dimensionDescriptor = EnumReflector.Describe(_currentDimension);
                UnitsTypeAttribute attribute = dimensionDescriptor.GetAttributes<UnitsTypeAttribute>()[0];
                Type unitsType = attribute.UnitsType;

                List<EnumValueDescriptor<int>> units = EnumReflector.DescribeAllValuesAsInt32(unitsType)
                                                                    .ToList();
                _sourceUnits = units.Select(x => x)
                                    .Where(x => x.Name != "BaseUnit")
                                    .Select(x => x.GetAttributes<UnitAbbreviationAttribute>()[0].Value)
                                    .ToList();
                NotifyOfPropertyChange(() => SourceUnits);
                SelectedSourceUnit = _sourceUnits[0];

                _results.Clear();
                _results.AddRange(units.Where(enumValue => enumValue.Name != "BaseUnit")
                                       .Select(enumValue => enumValue.GetAttributes<UnitAbbreviationAttribute>()[0].Value)
                                       .Select(abbreviation => new ResultViewModel(UnitOfMeasure.Find(_currentDimension, abbreviation)))
                                       .ToList());
            }
        }

        public string SelectedSourceUnit {
            get { return _selectedSourceUnit; }
            set {
                _selectedSourceUnit = value;
                NotifyOfPropertyChange(() => SelectedSourceUnit);
                //todo: handle user choosing a source units
            }
        }

        public List<string> SourceUnits {
            get { return _sourceUnits; }
        }

        public string UserInput {
            get { return _userInput; }
            set {
                _userInput = value;
                NotifyOfPropertyChange(() => UserInput);
                //todo: handle user editing 
            }
        }
    }
}