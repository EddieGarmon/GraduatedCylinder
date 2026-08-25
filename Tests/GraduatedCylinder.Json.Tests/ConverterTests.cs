using System.Text.Json;
using Xunit;

namespace GraduatedCylinder.Json;

public class ConverterTests
{

    [Fact(Skip = "Not Validated")]
    public void TestAbsoluteHumidityJsonConverter() {
        AbsoluteHumidityJsonConverter converter = new() { Precision = 3, Units = AbsoluteHumidityUnit.GramsPerCubicMeter };
        JsonSerializerOptions options = new();
        options.Converters.Add(converter);
        AbsoluteHumidity originalValue = new(12.34567, AbsoluteHumidityUnit.GramsPerCubicMeter);
        string json = JsonSerializer.Serialize(originalValue, options);
        AbsoluteHumidity deserializedValue = JsonSerializer.Deserialize<AbsoluteHumidity>(json, options);
        Assert.Equal(originalValue, deserializedValue);
    }

}