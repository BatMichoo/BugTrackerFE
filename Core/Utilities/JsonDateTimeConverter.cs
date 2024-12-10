﻿using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core.Utilities.JsonConverters
{
    public class JsonDateTimeConverter : JsonConverter<DateTime>
    {
        private const string _format = "HH:mm:ss dd/MM/yyyy";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString()!);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}
