﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using JsonTest;
//
//    var weatherModel = WeatherModel.FromJson(jsonString);
// 
// generate from https://app.quicktype.io/

using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace JsonTest
{
    public partial class WeatherModel
    {
        [JsonProperty("publishingOffice")]
        public string PublishingOffice { get; set; }

        [JsonProperty("reportDatetime")]
        public DateTimeOffset ReportDatetime { get; set; }

        [JsonProperty("timeSeries")]
        public TimeSery[] TimeSeries { get; set; }

        [JsonProperty("tempAverage", NullValueHandling = NullValueHandling.Ignore)]
        public PAverage TempAverage { get; set; }

        [JsonProperty("precipAverage", NullValueHandling = NullValueHandling.Ignore)]
        public PAverage PrecipAverage { get; set; }
    }

    public partial class PAverage
    {
        [JsonProperty("areas")]
        public PrecipAverageArea[] Areas { get; set; }
    }

    public partial class PrecipAverageArea
    {
        [JsonProperty("area")]
        public AreaArea Area { get; set; }

        [JsonProperty("min")]
        public string Min { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }
    }

    public partial class AreaArea
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Code { get; set; }
    }

    public partial class TimeSery
    {
        [JsonProperty("timeDefines")]
        public DateTimeOffset[] TimeDefines { get; set; }

        [JsonProperty("areas")]
        public TimeSeryArea[] Areas { get; set; }
    }

    public partial class TimeSeryArea
    {
        [JsonProperty("area")]
        public AreaArea Area { get; set; }

        [JsonProperty("weatherCodes", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] WeatherCodes { get; set; }

        [JsonProperty("weathers", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Weathers { get; set; }

        [JsonProperty("winds", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Winds { get; set; }

        [JsonProperty("waves", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Waves { get; set; }

        [JsonProperty("pops", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Pops { get; set; }

        [JsonProperty("temps", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DecodeArrayConverter))]
        public long[] Temps { get; set; }

        [JsonProperty("reliabilities", NullValueHandling = NullValueHandling.Ignore)]
        public Reliability[] Reliabilities { get; set; }

        [JsonProperty("tempsMin", NullValueHandling = NullValueHandling.Ignore)]
        public string[] TempsMin { get; set; }

        [JsonProperty("tempsMinUpper", NullValueHandling = NullValueHandling.Ignore)]
        public string[] TempsMinUpper { get; set; }

        [JsonProperty("tempsMinLower", NullValueHandling = NullValueHandling.Ignore)]
        public string[] TempsMinLower { get; set; }

        [JsonProperty("tempsMax", NullValueHandling = NullValueHandling.Ignore)]
        public string[] TempsMax { get; set; }

        [JsonProperty("tempsMaxUpper", NullValueHandling = NullValueHandling.Ignore)]
        public string[] TempsMaxUpper { get; set; }

        [JsonProperty("tempsMaxLower", NullValueHandling = NullValueHandling.Ignore)]
        public string[] TempsMaxLower { get; set; }
    }

    public enum Reliability { A, B, C, Empty };

    public partial class WeatherModel
    {
        public static WeatherModel[] FromJson(string json) => JsonConvert.DeserializeObject<WeatherModel[]>(json, JsonTest.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this WeatherModel[] self) => JsonConvert.SerializeObject(self, JsonTest.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ReliabilityConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class ReliabilityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Reliability) || t == typeof(Reliability?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "":
                    return Reliability.Empty;
                case "A":
                    return Reliability.A;
                case "B":
                    return Reliability.B;
                case "C":
                    return Reliability.C;
            }
            throw new Exception("Cannot unmarshal type Reliability");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Reliability)untypedValue;
            switch (value)
            {
                case Reliability.Empty:
                    serializer.Serialize(writer, "");
                    return;
                case Reliability.A:
                    serializer.Serialize(writer, "A");
                    return;
                case Reliability.B:
                    serializer.Serialize(writer, "B");
                    return;
                case Reliability.C:
                    serializer.Serialize(writer, "C");
                    return;
            }
            throw new Exception("Cannot marshal type Reliability");
        }

        public static readonly ReliabilityConverter Singleton = new ReliabilityConverter();
    }

    internal class DecodeArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long[]);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            reader.Read();
            var value = new List<long>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                var converter = ParseStringConverter.Singleton;
                var arrayItem = (long)converter.ReadJson(reader, typeof(long), null, serializer);
                value.Add(arrayItem);
                reader.Read();
            }
            return value.ToArray();
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (long[])untypedValue;
            writer.WriteStartArray();
            foreach (var arrayItem in value)
            {
                var converter = ParseStringConverter.Singleton;
                converter.WriteJson(writer, arrayItem, serializer);
            }
            writer.WriteEndArray();
            return;
        }

        public static readonly DecodeArrayConverter Singleton = new DecodeArrayConverter();
    }
}
