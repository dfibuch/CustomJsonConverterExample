using System;

namespace CustomJsonConverterExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var stockList = DataSource.GetVehicleStockData();

            foreach (var stock in stockList)
            {
                if (stock.Vehicle is SUV suv)
                {
                    Console.WriteLine($"{suv.Make} {suv.Model} ({suv.EngineSize}L) with {suv.NumberOfDoors} doors");
                }

                if (stock.Vehicle is Motorbike motorbike)
                {
                    Console.WriteLine($"{motorbike.Make} {motorbike.Model} ({motorbike.EngineSize}L) with windshield = {motorbike.HasWindshield}" );
                }
            }

            Console.Read();
        }
    }
}
