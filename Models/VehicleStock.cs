namespace CustomJsonConverterExample
{
    public class VehicleStock<T> where T : Vehicle
    {
        public string StockLocation { get; set; }

        public T Vehicle { get; set; }
    }
}
