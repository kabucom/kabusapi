using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class SymbolElements
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }

        [DataMember(Name = "DisplayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "Exchange")]
        public int Exchange { get; set; }

        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }

        [DataMember(Name = "BisCategory")]
        public string BisCategory { get; set; }

        [DataMember(Name = "TotalMarketValue")]
        public decimal TotalMarketValue { get; set; }

        [DataMember(Name = "TotalStocks")]
        public double TotalStocks { get; set; }

        [DataMember(Name = "TradingUnit")]
        public double TradingUnit { get; set; }

        [DataMember(Name = "FiscalYearEndBasic")]
        public double FiscalYearEndBasic { get; set; }

        [DataMember(Name = "PriceRangeGroup")]
        public string PriceRangeGroup { get; set; }

        [DataMember(Name = "KCMarginBuy")]
        public bool KCMarginBuy { get; set; }

        [DataMember(Name = "KCMarginSell")]
        public bool KCMarginSell { get; set; }

        [DataMember(Name = "MarginBuy")]
        public bool MarginBuy { get; set; }

        [DataMember(Name = "MarginSell")]
        public bool MarginSell { get; set; }

        [DataMember(Name = "UpperLimit")]
        public double UpperLimit { get; set; }

        [DataMember(Name = "LowerLimit")]
        public double LowerLimit { get; set; }

        [DataMember(Name = "Underlyer")]
        public string Underlyer { get; set; }

        [DataMember(Name = "DerivMonth")]
        public string DerivMonth { get; set; }

        [DataMember(Name = "DerivWeekly")]
        public int DerivWeekly { get; set; }

        [DataMember(Name = "TradeStart")]
        public int TradeStart { get; set; }

        [DataMember(Name = "TradeEnd")]
        public int TradeEnd { get; set; }

        [DataMember(Name = "StrikePrice")]
        public double StrikePrice { get; set; }

        [DataMember(Name = "PutOrCall")]
        public int PutOrCall { get; set; }

        [DataMember(Name = "ClearingPrice")]
        public decimal ClearingPrice { get; set; }
    }
    public class SymbolResult
    {
        private const int SymbolCol = 25;
        private static object SymbolToArray(dynamic objectJson)
        {

            SymbolElements SymbolData = (SymbolElements)objectJson;

            object[] array = new object[SymbolCol];
            array[0] = SymbolData.Symbol;
            array[1] = SymbolData.SymbolName;
            array[2] = SymbolData.DisplayName;
            array[3] = SymbolData.Exchange;
            array[4] = SymbolData.ExchangeName;
            array[5] = SymbolData.BisCategory;
            array[6] = SymbolData.TotalMarketValue;
            array[7] = SymbolData.TotalStocks;
            array[8] = SymbolData.TradingUnit;
            array[9] = SymbolData.FiscalYearEndBasic;
            array[10] = SymbolData.PriceRangeGroup;
            array[11] = SymbolData.KCMarginBuy;
            array[12] = SymbolData.KCMarginSell;
            array[13] = SymbolData.MarginBuy;
            array[14] = SymbolData.MarginSell;
            array[15] = SymbolData.UpperLimit;
            array[16] = SymbolData.LowerLimit;
            array[17] = SymbolData.Underlyer;
            array[18] = SymbolData.DerivMonth;
            array[19] = SymbolData.DerivWeekly;
            array[20] = SymbolData.TradeStart;
            array[21] = SymbolData.TradeEnd;
            array[22] = SymbolData.StrikePrice;
            array[23] = SymbolData.PutOrCall;
            array[24] = SymbolData.ClearingPrice;

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object SymbolCheck(string value)
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
            ret = SymbolToArray(objectJson);
            return ret;
        }
    }
}
