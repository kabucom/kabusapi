using System.Collections.Generic;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    public class PositionsElement
    {
        [DataMember(Name = "ExecutionID")]
        public string ExecutionID { get; set; }

        [DataMember(Name = "AccountType")]
        public double AccountType { get; set; }

        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }

        [DataMember(Name = "Exchange")]
        public double Exchange { get; set; }

        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }

        [DataMember(Name = "SecurityType")]
        public double SecurityType { get; set; }

        [DataMember(Name = "ExecutionDay")]
        public double ExecutionDay { get; set; }

        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "LeavesQty")]
        public double LeavesQty { get; set; }

        [DataMember(Name = "HoldQty")]
        public double HoldQty { get; set; }

        [DataMember(Name = "Side")]
        public string Side { get; set; }

        [DataMember(Name = "Expenses")]
        public double Expenses { get; set; }

        [DataMember(Name = "Commission")]
        public double Commission { get; set; }

        [DataMember(Name = "CommissionTax")]
        public double CommissionTax { get; set; }

        [DataMember(Name = "ExpireDay")]
        public double ExpireDay { get; set; }

        [DataMember(Name = "MarginTradeType")]
        public double MarginTradeType { get; set; }

        [DataMember(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }

        [DataMember(Name = "Valuation")]
        public double Valuation { get; set; }

        [DataMember(Name = "ProfitLoss")]
        public double ProfitLoss { get; set; }

        [DataMember(Name = "ProfitLossRate")]
        public double ProfitLossRate { get; set; }
    }

    public class PositionsResult
    {
        private const int PositionCol = 21;
        private static object PositionToArray(dynamic objectJson)
        {

            List<PositionsElement> PositionList = (List<PositionsElement>)objectJson;

            int PositionRows = PositionList.Count;
            if (PositionRows == 0)
                return null;

            object[,] array = new object[PositionRows, PositionCol];
            int row = 0;

            for (int i = 0; i < PositionRows; i++)
            {
                array[row, 0] = PositionList[i].ExecutionID ?? "";
                array[row, 1] = PositionList[i].AccountType;
                array[row, 2] = PositionList[i].Symbol ?? "";
                array[row, 3] = PositionList[i].SymbolName ?? "";
                array[row, 4] = PositionList[i].Exchange;
                array[row, 5] = PositionList[i].ExchangeName ?? "";
                array[row, 6] = PositionList[i].SecurityType;
                array[row, 7] = PositionList[i].ExecutionDay;
                array[row, 8] = PositionList[i].Price;
                array[row, 9] = PositionList[i].LeavesQty;
                array[row, 10] = PositionList[i].HoldQty;
                array[row, 11] = PositionList[i].Side ?? "";
                array[row, 12] = PositionList[i].Expenses;
                array[row, 13] = PositionList[i].Commission;
                array[row, 14] = PositionList[i].CommissionTax;
                array[row, 15] = PositionList[i].ExpireDay;
                array[row, 16] = PositionList[i].MarginTradeType;
                array[row, 17] = PositionList[i].CurrentPrice;
                array[row, 18] = PositionList[i].Valuation;
                array[row, 19] = PositionList[i].ProfitLoss;
                array[row, 20] = PositionList[i].ProfitLossRate;
                row++;
            }

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object PositionCheck(string value)
        {
            var objectJson = DynamicJson.Parse(value);
            object ret;
            if (objectJson.IsDefined("Code"))
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            else if(!CustomRibbon._env)
            {
                return 0;
            }

            // multidimensional arrays
            ret = PositionToArray(objectJson);
            return ret;
        }
    }
}
