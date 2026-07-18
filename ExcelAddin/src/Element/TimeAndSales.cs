using System.Collections.Generic;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class TimeAndSalesElement
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Exchange")]
        public int Exchange { get; set; }

        [DataMember(Name = "TradingPriceCount")]
        public int TradingPriceCount { get; set; }

        [DataMember(Name = "TradingPrice")]
        public List<TradingPriceList> TradingPrice { get; set; }
    }

    [DataContract]
    public class TradingPriceList
    {
        [DataMember(Name = "Time")]
        public string Time { get; set; }

        [DataMember(Name = "Volume")]
        public int Volume { get; set; }

        [DataMember(Name = "Price")]
        public int Price { get; set; }
    }


    public class TimeAndSalesResult
    {
        private const int TimeAndSalesCol = 6;

        private static object TimeAndSalesToArray(dynamic objectJson)
        {
            TimeAndSalesElement timeAndSalesData = (TimeAndSalesElement)objectJson;

            if (timeAndSalesData.TradingPrice.Count == 0)
            {
                object[] array = new object[3];
                array[0] = timeAndSalesData.Symbol;
                array[1] = timeAndSalesData.Exchange;
                array[2] = timeAndSalesData.TradingPriceCount;
                return array;
            }
            else
            {
                object[,] array = new object[timeAndSalesData.TradingPrice.Count, TimeAndSalesCol];

                int row = 0;

                array[row, 0] = timeAndSalesData.Symbol;
                array[row, 1] = timeAndSalesData.Exchange;
                array[row, 2] = timeAndSalesData.TradingPriceCount;
                foreach (var tradingPrice in timeAndSalesData.TradingPrice)
                {
                    if (row > 0)
                    {
                        // 2行目以降は空
                        array[row, 0] = "";
                        array[row, 1] = "";
                        array[row, 2] = "";
                    }
                    array[row, 3] = tradingPrice.Time;
                    array[row, 4] = tradingPrice.Volume;
                    array[row, 5] = tradingPrice.Price;
                    row++;
                }
                return array;
            }
        }

        [ExcelFunction(IsHidden = true)]
        public static object TimeAndSalesCheck(string value)
        {
            var objectJson = DynamicJson.Parse(value);
            object ret;
            if (objectJson.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }

            // multidimensional arrays
            ret = TimeAndSalesToArray(objectJson);
            return ret;
        }
    }
}
