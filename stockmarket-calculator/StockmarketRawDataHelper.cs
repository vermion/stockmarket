using CsvHelper;
using Newtonsoft.Json;
using stockmarket_calculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace stockmarket_calculator
{
    public static class StockmarketRawDataHelper
    {
        public static async Task<List<StockmarketRawData>> GetStockmarketDataAsync()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.quandl.com/api/v3/");

            var response = await httpClient.GetAsync("datasets/NASDAQOMX/OMXS30.csv?api_key=zGazJA6vDcAA6uCMD-s9");

            response.EnsureSuccessStatusCode();
            var responseStream = await response.Content.ReadAsStringAsync();

            StringReader reader = new StringReader(responseStream);
            reader.ReadLine(); // Skip header.
            reader.ReadLine(); // Skip line with corrupt values.

            List<StockmarketRawData> stockmarketRawData = new List<StockmarketRawData>();
            for (int i = 0; i < 10; i++)
            {
                var line = reader.ReadLine();
                var splitString = line.Split(",");

                var model = new StockmarketRawData
                {
                    TradeDate = DateTime.Parse(splitString[0]),
                    IndexValue = Double.Parse(splitString[1])
                };
                stockmarketRawData.Add(model);
            }

            return stockmarketRawData;
        }
    }
}
