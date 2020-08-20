using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{
    public class WalletMarginResult
    {
        [DataMember(Name = "MarginAccountWallet")]
        public double MarginAccountWallet { get; set; }

        [DataMember(Name = "DepositkeepRate")]
        public double DepositkeepRate { get; set; }

        [DataMember(Name = "ConsignmentDepositRate")]
        public double ConsignmentDepositRate { get; set; }

        [DataMember(Name = "CashOfConsignmentDepositRate")]
        public double CashOfConsignmentDepositRate { get; set; }

    }

    public class WalletMargin
    {
        private const int WalletMarginCol = 4;
        private static object WalletMarginToArray(string str)
        {
            var objectJson = DynamicJson.Parse(str);

            WalletMarginResult WalletMarginData = (WalletMarginResult)objectJson;

            object[] array = new object[WalletMarginCol];

            array[0] = WalletMarginData.MarginAccountWallet;
            array[1] = WalletMarginData.DepositkeepRate;
            array[2] = WalletMarginData.ConsignmentDepositRate;
            array[3] = WalletMarginData.CashOfConsignmentDepositRate;

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object WalletMargineResultCheck(string value)
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
            ret = WalletMarginToArray(value);
            return ret;
        }
    }

}
