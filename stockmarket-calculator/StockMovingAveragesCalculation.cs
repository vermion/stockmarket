using stockmarket_calculator.Models;
using System.Collections.Generic;
using System.Linq;

namespace stockmarket_calculator
{
    public static class StockMovingAveragesCalculation
    {
        public static double CalculateExponentialMovingAverage(int numberOfDays, List<StockmarketRawData> historicalDataList)
        {
            double yesterdaysEMA = 0;
            if (historicalDataList.Count >= numberOfDays)
            {
                double eMA = 0;
                double sumOfEMA = 0;
                for (int i = 0; i < numberOfDays; i++)
                {
                    if (i == 0)
                    {
                        yesterdaysEMA = CalculateSimpleMovingAverage(numberOfDays, historicalDataList);
                    }
                    eMA = ExponentialMovingAverageFormula(historicalDataList[i].IndexValue, yesterdaysEMA, numberOfDays);
                    sumOfEMA = sumOfEMA + eMA;
                    yesterdaysEMA = eMA;
                }

                return sumOfEMA / numberOfDays;
            }
            else
                return 0;
        }

        private static double ExponentialMovingAverageFormula(double todaysPrice, double yesterdaysEMA, double numberOfDays)
        {
            double multiplier = (2 / (numberOfDays + 1));
            return (todaysPrice - yesterdaysEMA) * multiplier + yesterdaysEMA;
        }

        private static double CalculateSimpleMovingAverage(int numberOfdaya, List<StockmarketRawData> historicalDataList)
        {
            return historicalDataList.Select(x => x.IndexValue).Average();
        }
    }
}