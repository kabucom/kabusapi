using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KabuSuteAddin.Elements
{

    [DataContract]
    public class KanougakuParam
    {

        [DataMember(Name = "SymbolCode")]
        public string SymbolCode { get; set; }

    }

    [DataContract]
    public class MarketParam
    {
        [DataMember(Name = "SymbolCode")]
        public string SymbolCode { get; set; }

        [DataMember(Name = "MarketCode")]
        public string MarketCode { get; set; }

    }


    [DataContract]
    public class SymbolList
    {
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "Exchange")]
        public int Exchange { get; set; }
    }

    [DataContract]
    public class SymbolParamList
    {
        [DataMember(Name = "Symbols")]
        public List<SymbolList> Symbols { get; set; }
    }


    [DataContract]
    public class SymbolParam
    {
        [DataMember(Name = "SymbolCode")]
        public string SymbolCode { get; set; }

        [DataMember(Name = "MarketCode")]
        public string MarketCode { get; set; }

    }

    [DataContract]
    public class OrdersParam
    {

        [DataMember(Name = "SecurityType")]
        public string SecurityType { get; set; }

    }

    [DataContract]
    public class PositionsParam
    {

        [DataMember(Name = "SecurityType")]
        public string SecurityType { get; set; }

    }

    [DataContract]
    public class SymbolModel
    {
        [DataMember(Name = "SymbolCode")]
        public string SymbolCode { get; set; }

        [DataMember(Name = "MarketCode")]
        public string MarketCode { get; set; }

    }

    [DataContract]
    public class WalletMarginResultModel
    {
        [DataMember(Name = "MarginAccountWallet", Order =0)]
        public double MarginAccountWallet { get; set; }

        [DataMember(Name = "DepositkeepRate", Order = 1)]
        public double DepositkeepRate { get; set; }

        [DataMember(Name = "ConsignmentDepositRate", Order = 2)]
        public double ConsignmentDepositRate { get; set; }

        [DataMember(Name = "CashOfConsignmentDepositRate", Order = 3)]
        public double CashOfConsignmentDepositRate { get; set; }
    }

}
