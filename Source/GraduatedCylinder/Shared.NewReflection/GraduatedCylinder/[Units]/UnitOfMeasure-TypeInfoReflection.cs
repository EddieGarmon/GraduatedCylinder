using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GraduatedCylinder
{
    public partial class UnitOfMeasure
    {
        public static UnitOfMeasure FindFirst(string abbreviationOrName) {
            IEnumerable<DimensionType> dimensions = typeof(DimensionType).GetTypeInfo()
                                                                         .DeclaredFields.Where(f => f.IsPublic && f.IsStatic && f.IsLiteral)
                                                                         .Select(field => (DimensionType)field.GetValue(null));

            return dimensions.Select(dimensionType => Find(dimensionType, abbreviationOrName))
                             .FirstOrDefault(result => result != null);
        }

        private static bool IsEnum(Type type) {
            return type.GetTypeInfo()
                       .IsEnum;
        }
    }
}