using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GraduatedCylinder.Json
{
    public class LengthConverter : JsonConverter<Length>
    {

        public int Precision { get; set; } = 2;

        public LengthUnit Units { get; set; } = LengthUnit.Meter;

        public override Length Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            string value = reader.GetString();
            return Length.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, Length value, JsonSerializerOptions options) {
            writer.WriteStringValue(value.ToString(Units, Precision));
        }

    }
}