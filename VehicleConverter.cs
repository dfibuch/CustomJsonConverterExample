namespace Citrus.NewPay.TestClient.Services
{
    using System;
    using CustomJsonConverterExample;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Handles deserializing of vehicle type without having to specifically ask for them
    /// </summary>
    public class VehicleConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Vehicle);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var item = JObject.Load(reader);
            var type = item["$type"].Value<string>();

            return type switch
            {
                "CustomJsonConverterExample.SUV, CustomJsonConverterExample" => item.ToObject<SUV>(),
                "CustomJsonConverterExample.Motorbike, CustomJsonConverterExample" => item.ToObject<Motorbike>(),
                _ => throw new NotImplementedException($"Vehicle type {type} is currently not supported/implemented."),
            };
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
