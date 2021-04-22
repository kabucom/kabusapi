using System;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class PrimaryExchangeElelment
    {
        [DataMember(Name ="Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name ="PrimaryExchange")]
        public string PrimaryExchange { get; set; }
             
    }
    public class PrimaryExchangeResult
    {
        private const int ResCol = 2;
        
        private static object PrimaryExchangeToArray(dynamic objectJson)
        {
            PrimaryExchangeElelment primaryExchangeData = (PrimaryExchangeElelment)objectJson;
            object[] array = new object[ResCol];
            array[0] = primaryExchangeData.Symbol;
            array[1] = primaryExchangeData.PrimaryExchange;
            return array;
        }
        [ExcelFunction(IsHidden = true)]
        public static object PrimaryExchangeCheck(string value)
        {
            var JsonObj = DynamicJson.Parse(value);
            object ret;
            if (JsonObj.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            ret = PrimaryExchangeToArray(JsonObj);
            return ret;
        }
    }
}
