#if GraduatedCylinder
namespace GraduatedCylinder;
#endif
#if Pipette
namespace Pipette;
#endif

public partial struct VolumetricFlowRate : IDimension<VolumetricFlowRate, VolumetricFlowRateUnit>
{

    public static Volume operator *(VolumetricFlowRate volumetricFlowRate, Time time) {
        volumetricFlowRate = volumetricFlowRate.In(VolumetricFlowRateUnit.CubicMetersPerSecond);
        time = time.In(TimeUnit.Second);
        return new Volume(volumetricFlowRate.Value * time.Value, VolumeUnit.CubicMeters);
    }

}