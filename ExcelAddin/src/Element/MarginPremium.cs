using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class MarginPremiumElements
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "GeneralMargin")]
        public Margin GeneralMargin { get; set; }
        [DataMember(Name = "DayTrade")]
        public Margin DayTrade { get; set; }
    }

    [DataContract]
    public class Margin
    {
        [DataMember(Name = "MarginPremiumType")]
        public int MarginPremiumType { get; set; }
        [DataMember(Name = "MarginPremium")]
        public double MarginPremium { get; set; }
        [DataMember(Name = "UpperMarginPremium")]
        public double UpperMarginPremium { get; set; }
        [DataMember(Name = "LowerMarginPremium")]
        public double LowerMarginPremium { get; set; }
        [DataMember(Name = "TickMarginPremium")]
        public double TickMarginPremium { get; set; }
    }

    public class MarginPremiumResult
    {
        private const int MarginCol = 11;

        [ExcelFunction(IsHidden = true)]
        public static object MarginPremiumToArray(dynamic objectJson)
        {
            MarginPremiumElements MarginPremiumData = (MarginPremiumElements)objectJson;
            object[] array = new object[MarginCol];
            array[0] = MarginPremiumData.Symbol;
            array[1] = MarginPremiumData.GeneralMargin.MarginPremiumType;
            array[2] = MarginPremiumData.GeneralMargin.MarginPremium;
            array[3] = MarginPremiumData.GeneralMargin.UpperMarginPremium;
            array[4] = MarginPremiumData.GeneralMargin.LowerMarginPremium;
            array[5] = MarginPremiumData.GeneralMargin.TickMarginPremium;
            array[6] = MarginPremiumData.DayTrade.MarginPremiumType;
            array[7] = MarginPremiumData.DayTrade.MarginPremium;
            array[8] = MarginPremiumData.DayTrade.UpperMarginPremium;
            array[9] = MarginPremiumData.DayTrade.LowerMarginPremium;
            array[10] = MarginPremiumData.DayTrade.TickMarginPremium;
            return array;

        }

        [ExcelFunction(IsHidden = true)]
        public static object MarginPremiumCheck(string value)
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
            ret = MarginPremiumToArray(objectJson);
            return ret;
        }
    }
}
