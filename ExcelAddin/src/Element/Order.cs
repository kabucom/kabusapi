using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace KabuSuteAddin
{
    [DataContract]
    public class SendOrderParam
    {
        [DataMember(Name = "OrderPassword")]
        public string OrderPassword { get; set; }

        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "CashMargin")]
        public int CashMargin { get; set; }

        [DataMember(Name = "DelivType")]
        public int DelivType { get; set; }

        [DataMember(Name = "ExpireDay")]
        public int ExpireDay { get; set; }

        [DataMember(Name = "ExpireSession")]
        public int ExpireSession { get; set; }

        [DataMember(Name = "FundType")]
        public string FundType { get; set; }

        [DataMember(Name = "MarginTradeType")]
        public int MarginTradeType { get; set; }

        [DataMember(Name = "OrdType")]
        public int OrdType { get; set; }

        [DataMember(Name = "Price")]
        public decimal Price { get; set; }

        [DataMember(Name = "PriceType")]
        public int PriceType { get; set; }

        [DataMember(Name = "Qty")]
        public decimal Qty { get; set; }

        [DataMember(Name = "Side")]
        public string Side { get; set; }

        [DataMember(Name = "TimeInForce")]
        public int TimeInForce { get; set; }
    }

    [DataContract]
    public class CancelOrderParam
    {
        [DataMember(Name = "OrderId")]
        public string OrderId { get; set; }

        [DataMember(Name = "Password")]
        public string OrderPassword { get; set; }

    }

}
