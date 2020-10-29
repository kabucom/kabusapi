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

    public class WalletFutureResult
    {
        [DataMember(Name = "FutureTradeLimit")]
        public double FutureTradeLimit { get; set; }

        [DataMember(Name = "MarginRequirement")]
        public double MarginRequirement { get; set; }

    }

    public class WalletOptionResult
    {
        [DataMember(Name = "OptionBuyTradeLimit")]
        public double OptionBuyTradeLimit { get; set; }

        [DataMember(Name = "OptionSellTradeLimit")]
        public double OptionSellTradeLimit { get; set; }

        [DataMember(Name = "MarginRequirement")]
        public double MarginRequirement { get; set; }

    }

    public class WalletResult
    {
        private const int WalletMarginCol = 4;
        private const int WalletFutureCol = 2;
        private const int WalletOptionCol = 3;

        private static object WalletMarginToArray(dynamic objectJson)
        {

            WalletMarginResult MarginData = (WalletMarginResult)objectJson;

            object[] array = new object[WalletMarginCol];

            array[0] = MarginData.MarginAccountWallet;
            array[1] = MarginData.DepositkeepRate;
            array[2] = MarginData.ConsignmentDepositRate;
            array[3] = MarginData.CashOfConsignmentDepositRate;

            return array;
        }

        private static object WalletFutureToArray(dynamic objectJson)
        {

            WalletFutureResult FutureData = (WalletFutureResult)objectJson;

            object[] array = new object[WalletFutureCol];

            array[0] = FutureData.FutureTradeLimit;
            array[1] = FutureData.MarginRequirement;

            return array;
        }

        private static object WalletOptionToArray(dynamic objectJson)
        {

            WalletOptionResult OptionData = (WalletOptionResult)objectJson;

            object[] array = new object[WalletOptionCol];

            array[0] = OptionData.OptionBuyTradeLimit;
            array[1] = OptionData.OptionSellTradeLimit;
            array[2] = OptionData.MarginRequirement;

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object WalletCheck(string value, string category)
        {
            var objectJson = DynamicJson.Parse(value);
            object ret = null;
            if (objectJson.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }

            switch (category)
            {
                case WALLET.MARGIN:
                    ret = WalletMarginToArray(objectJson);
                    break;

                case WALLET.FUTURE:
                    ret = WalletFutureToArray(objectJson);
                    break;

                case WALLET.OPTION:
                    ret = WalletOptionToArray(objectJson);
                    break;

            }
            
            return ret;
        }
    }

}
