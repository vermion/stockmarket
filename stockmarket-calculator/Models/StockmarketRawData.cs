using CsvHelper.Configuration;
using System;

namespace stockmarket_calculator.Models
{
    public class StockmarketRawData
    {
        public DateTime TradeDate { get; set; }
        public double IndexValue { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public string TotalMarketValue { get; set; }
        public double DividendMarketValue { get; set; }
    }
}
