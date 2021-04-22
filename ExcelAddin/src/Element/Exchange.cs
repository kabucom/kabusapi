using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class ExchangeElement
    {
        [DataMember(Name ="Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name ="BidPrice")]
        public double BidPrice { get; set; }
        [DataMember(Name ="Spread")]
        public double Spread { get; set; }
        [DataMember(Name ="AskPrice")]
        public double AskPrice { get; set; }
        [DataMember(Name ="Change")]
        public double Change { get; set; }
        [DataMember(Name ="Time")]
        public string Time { get; set; }
    }

    public class ExchangeResult
    {
        private const int ResCol = 6;
        private static object ExchangeToArray(dynamic JsonObj)
        {
            ExchangeElement ExchangeData = (ExchangeElement)JsonObj;
            object[] Array = new object[ResCol];
            Array[0] = ExchangeData.Symbol;
            Array[1] = ExchangeData.BidPrice;
            Array[2] = ExchangeData.Spread;
            Array[3] = ExchangeData.AskPrice;
            Array[4] = ExchangeData.Change;
            Array[5] = ExchangeData.Time;
            return Array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object ExchangeCheck(string value)
        {
            var JsonObj = DynamicJson.Parse(value);
            object ret;
            if (JsonObj.IsDefined("Code"))
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            ret = ExchangeToArray(JsonObj);
            return ret;
        }
    }
}
