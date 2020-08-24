using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraduatedCylinder.Json
{
    public class ElectricCurrentConverter : JsonConverter<ElectricCurrent>
    {

        public int Precision { get; set; } = 2;

        public ElectricCurrentUnit Units { get; set; } = ElectricCurrentUnit.Ampere;

        public override ElectricCurrent Read(ref Utf8JsonReader reader,
                                             Type typeToConvert,
                                             JsonSerializerOptions options) {
            string value = reader.GetString();
            return ElectricCurrent.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, ElectricCurrent value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString(Units, Precision));
        }

    }
}