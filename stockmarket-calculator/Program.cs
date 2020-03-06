using System;

namespace stockmarket_calculator
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var stockmarketData = await StockmarketRawDataHelper.GetStockmarketDataAsync();

            var movingAverage = StockMovingAveragesCalculation.CalculateExponentialMovingAverage(10, stockmarketData);
        }
    }
}
