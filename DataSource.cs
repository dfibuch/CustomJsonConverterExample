namespace CustomJsonConverterExample
{
    using System.Collections.Generic;
    using Citrus.NewPay.TestClient.Services;
    using Newtonsoft.Json;

    public class DataSource
    {
        private static readonly VehicleStock<SUV> Jeep = new()
        {
            StockLocation = "London",
            Vehicle = new SUV { Make = "Jeep", Model = "Wrangler", EngineSize = "3", NumberOfDoors = 5 }
        };

        private static readonly VehicleStock<Motorbike> Yamaha = new()
        {
            StockLocation = "Berlin",
            Vehicle = new Motorbike { Make = "Yamaha", Model = "R1", EngineSize = "1", HasWindshield = false }
        };

        // These are default CosmosSerializer settings plus a custom JsonConverter
        private static readonly JsonSerializerSettings JsonDeserializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Include,
            Formatting = Formatting.None,
            ContractResolver = null,
            Converters = new List<JsonConverter>()
            {
                new VehicleConverter()
            }
        };

        // This simulates data being stored in the database, e.g. Cosmos
        private static List<string> GetSerializedData()
        {
            var serializeJsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var serializedJeep = JsonConvert.SerializeObject(Jeep, serializeJsonSettings);
            var serializedYamaha = JsonConvert.SerializeObject(Yamaha, serializeJsonSettings);

            return new List<string> { serializedJeep, serializedYamaha };
        }

        public static List<VehicleStock<Vehicle>> GetVehicleStockData()
        {
            var list = new List<VehicleStock<Vehicle>>();

            foreach(var item in GetSerializedData())
            {
                list.Add(JsonConvert.DeserializeObject<VehicleStock<Vehicle>>(item, JsonDeserializerSettings));
            }

            return list;
        }
    }
}
