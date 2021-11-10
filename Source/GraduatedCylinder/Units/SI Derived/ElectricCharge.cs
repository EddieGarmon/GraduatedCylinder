namespace GraduatedCylinder;

public partial struct ElectricCharge:IDimension<ElectricCharge,ElectricChargeUnit>
{

    public static ElectricCharge ElementaryCharge { get; } =
        new ElectricCharge(1.602e-19f, ElectricChargeUnit.Coulomb);

}