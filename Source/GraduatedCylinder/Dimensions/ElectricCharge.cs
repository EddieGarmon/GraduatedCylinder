#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct ElectricCharge : IDimension<ElectricCharge, ElectricChargeUnit>
{

#if GraduatedCylinder
    public static ElectricCharge ElementaryCharge { get; } = new(1.602_176_634e-19, ElectricChargeUnit.Coulomb);
#endif
#if Pipette
    public static ElectricCharge ElementaryCharge { get; } = new(1.602_176_634e-19f, ElectricChargeUnit.Coulomb);
#endif

}