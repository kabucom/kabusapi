using Codeplex.Data;
using ExcelDna.Integration;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class BoardResult
    {

        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }

        [DataMember(Name = "Exchange")]
        public double Exchange { get; set; }

        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }

        [DataMember(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }

        [DataMember(Name = "CurrentPriceTime")]
        public string CurrentPriceTime { get; set; }

        [DataMember(Name = "CurrentPriceChangeStatus")]
        public string CurrentPriceChangeStatus { get; set; }

        [DataMember(Name = "CurrentPriceStatus")]
        public double CurrentPriceStatus { get; set; }

        [DataMember(Name = "CalcPrice")]
        public double CalcPrice { get; set; }

        [DataMember(Name = "PreviousClose")]
        public double PreviousClose { get; set; }

        [DataMember(Name = "PreviousCloseTime")]
        public string PreviousCloseTime { get; set; }

        [DataMember(Name = "ChangePreviousClose")]
        public double ChangePreviousClose { get; set; }

        [DataMember(Name = "ChangePreviousClosePer")]
        public double ChangePreviousClosePer { get; set; }

        [DataMember(Name = "OpeningPrice")]
        public double OpeningPrice { get; set; }

        [DataMember(Name = "OpeningPriceTime")]
        public string OpeningPriceTime { get; set; }

        [DataMember(Name = "HighPrice")]
        public double HighPrice { get; set; }

        [DataMember(Name = "HighPriceTime")]
        public string HighPriceTime { get; set; }

        [DataMember(Name = "LowPrice")]
        public double LowPrice { get; set; }

        [DataMember(Name = "LowPriceTime")]
        public string LowPriceTime { get; set; }

        [DataMember(Name = "TradingVolume")]
        public double TradingVolume { get; set; }

        [DataMember(Name = "TradingVolumeTime")]
        public string TradingVolumeTime { get; set; }

        [DataMember(Name = "VWAP")]
        public double VWAP { get; set; }

        [DataMember(Name = "TradingValue")]
        public double TradingValue { get; set; }

        [DataMember(Name = "BidQty")]
        public double BidQty { get; set; }

        [DataMember(Name = "BidPrice")]
        public double BidPrice { get; set; }

        [DataMember(Name = "BidTime")]
        public string BidTime { get; set; }

        [DataMember(Name = "BidSign")]
        public string BidSign { get; set; }

        [DataMember(Name = "MarketOrderSellQty")]
        public double MarketOrderSellQty { get; set; }

        [DataMember(Name = "Sell1")]
        public SellFarst Sell1{ get; set; }


        [DataMember(Name = "Sell2")]
        public Sell Sell2{ get; set; }


        [DataMember(Name = "Sell3")]
        public Sell Sell3{ get; set; }

        [DataMember(Name = "Sell4")]
        public Sell Sell4{ get; set; }


        [DataMember(Name = "Sell5")]
        public Sell Sell5{ get; set; }

        [DataMember(Name = "Sell6")]
        public Sell Sell6{ get; set; }


        [DataMember(Name = "Sell7")]
        public Sell Sell7{ get; set; }


        [DataMember(Name = "Sell8")]
        public Sell Sell8{ get; set; }


        [DataMember(Name = "Sell9")]
        public Sell Sell9{ get; set; }

        [DataMember(Name = "Sell10")]
        public Sell Sell10 { get; set; }


        [DataMember(Name = "AskQty")]
        public double AskQty { get; set; }

        [DataMember(Name = "AskPrice")]
        public double AskPrice { get; set; }

        [DataMember(Name = "AskTime")]
        public string AskTime { get; set; }

        [DataMember(Name = "AskSign")]
        public string AskSign { get; set; }

        [DataMember(Name = "MarketOrderBuyQty")]
        public double MarketOrderBuyQty { get; set; }

        [DataMember(Name = "Buy1")]
        public BuyFarst Buy1{ get; set; }


        [DataMember(Name = "Buy2")]
        public Buy Buy2{ get; set; }


        [DataMember(Name = "Buy3")]
        public Buy Buy3{ get; set; }


        [DataMember(Name = "Buy4")]
        public Buy Buy4{ get; set; }


        [DataMember(Name = "Buy5")]
        public Buy Buy5{ get; set; }

        [DataMember(Name = "Buy6")]
        public Buy Buy6{ get; set; }

        [DataMember(Name = "Buy7")]
        public Buy Buy7{ get; set; }

        [DataMember(Name = "Buy8")]
        public Buy Buy8{ get; set; }

        [DataMember(Name = "Buy9")]
        public Buy Buy9{ get; set; }

        [DataMember(Name = "Buy10")]
        public Buy Buy10{ get; set; }

        [DataMember(Name = "OverSellQty")]
        public double OverSellQty { get; set; }

        [DataMember(Name = "UnderBuyQty")]
        public double UnderBuyQty { get; set; }

        [DataMember(Name = "TotalMarketValue")]
        public double TotalMarketValue { get; set; }

        [DataMember(Name = "SettlementPrice")]
        public double SettlementPrice { get; set; }

        [DataMember(Name = "IV")]
        public double IV { get; set; }

        [DataMember(Name = "Gamma")]
        public double Gamma { get; set; }

        [DataMember(Name = "Theta")]
        public double Theta { get; set; }

        [DataMember(Name = "Vega")]
        public double Vega { get; set; }

        [DataMember(Name = "Delta")]
        public double Delta { get; set; }
    }

    [DataContract]
    public class SellFarst
    {
        [DataMember(Name = "Time")]
        public string Time { get; set; }

        [DataMember(Name = "Sign")]
        public string Sign { get; set; }

        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "Qty")]
        public double Qty { get; set; }
    }

    [DataContract]
    public class Sell
    {
        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "Qty")]
        public double Qty { get; set; }
    }

    [DataContract]
    public class BuyFarst
    {
        [DataMember(Name = "Time")]
        public string Time { get; set; }

        [DataMember(Name = "Sign")]
        public string Sign { get; set; }

        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "Qty")]
        public double Qty { get; set; }
    }

    [DataContract]
    public class Buy
    {

        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "Qty")]
        public double Qty { get; set; }
    }


public class Board
    {
        private const int BoardCol = 86;

        private static object BoardToArray(string str)
        {
            var objectJson = DynamicJson.Parse(str);

            BoardResult BoardData = (BoardResult)objectJson;

            object[] array = new object[BoardCol];
            array[0] = BoardData.Symbol;
            array[1] = BoardData.SymbolName;
            array[2] = BoardData.Exchange;
            array[3] = BoardData.ExchangeName;
            array[4] = BoardData.CurrentPrice;
            array[5] = BoardData.CurrentPriceTime;
            array[6] = BoardData.CurrentPriceChangeStatus;
            array[7] = BoardData.CurrentPriceStatus;
            array[8] = BoardData.CalcPrice;
            array[9] = BoardData.PreviousClose;
            array[10] = BoardData.PreviousCloseTime;
            array[11] = BoardData.ChangePreviousClose;
            array[12] = BoardData.ChangePreviousClosePer;
            array[13] = BoardData.OpeningPrice;
            array[14] = BoardData.OpeningPriceTime;
            array[15] = BoardData.HighPrice;
            array[16] = BoardData.HighPriceTime;
            array[17] = BoardData.LowPrice;
            array[18] = BoardData.LowPriceTime;
            array[19] = BoardData.TradingVolume;
            array[20] = BoardData.TradingVolumeTime;
            array[21] = BoardData.VWAP;
            array[22] = BoardData.TradingValue;
            array[23] = BoardData.BidQty;
            array[24] = BoardData.BidPrice;
            array[25] = BoardData.BidTime;
            array[26] = BoardData.BidSign;
            array[27] = BoardData.MarketOrderSellQty;
            if (!(BoardData.Sell1 == null))
            {
                array[28] = BoardData.Sell1.Time;
                array[29] = BoardData.Sell1.Sign;
                array[30] = BoardData.Sell1.Price;
                array[31] = BoardData.Sell1.Qty;
                array[32] = BoardData.Sell2.Price;
                array[33] = BoardData.Sell2.Qty;
                array[34] = BoardData.Sell3.Price;
                array[35] = BoardData.Sell3.Qty;
                array[36] = BoardData.Sell4.Price;
                array[37] = BoardData.Sell4.Qty;
                array[38] = BoardData.Sell5.Price;
                array[39] = BoardData.Sell5.Qty;
                array[40] = BoardData.Sell6.Price;
                array[41] = BoardData.Sell6.Qty;
                array[42] = BoardData.Sell7.Price;
                array[43] = BoardData.Sell7.Qty;
                array[44] = BoardData.Sell8.Price;
                array[45] = BoardData.Sell8.Qty;
                array[46] = BoardData.Sell9.Price;
                array[47] = BoardData.Sell9.Qty;
                array[48] = BoardData.Sell10.Price;
                array[49] = BoardData.Sell10.Qty;
                array[50] = BoardData.AskQty;
                array[51] = BoardData.AskPrice;
                array[52] = BoardData.AskTime;
                array[53] = BoardData.AskSign;
                array[54] = BoardData.MarketOrderBuyQty;
                array[55] = BoardData.Buy1.Time;
                array[56] = BoardData.Buy1.Sign;
                array[57] = BoardData.Buy1.Price;
                array[58] = BoardData.Buy1.Qty;
                array[59] = BoardData.Buy2.Price;
                array[60] = BoardData.Buy2.Qty;
                array[61] = BoardData.Buy3.Price;
                array[62] = BoardData.Buy3.Qty;
                array[63] = BoardData.Buy4.Price;
                array[64] = BoardData.Buy4.Qty;
                array[65] = BoardData.Buy5.Price;
                array[66] = BoardData.Buy5.Qty;
                array[67] = BoardData.Buy6.Price;
                array[68] = BoardData.Buy6.Qty;
                array[69] = BoardData.Buy7.Price;
                array[70] = BoardData.Buy7.Qty;
                array[71] = BoardData.Buy8.Price;
                array[72] = BoardData.Buy8.Qty;
                array[73] = BoardData.Buy9.Price;
                array[74] = BoardData.Buy9.Qty;
                array[75] = BoardData.Buy10.Price;
                array[76] = BoardData.Buy10.Qty;
                array[77] = BoardData.OverSellQty;
                array[78] = BoardData.UnderBuyQty;
                array[79] = BoardData.TotalMarketValue;
                array[80] = BoardData.SettlementPrice;
                array[81] = BoardData.IV;
                array[82] = BoardData.Gamma;
                array[83] = BoardData.Theta;
                array[84] = BoardData.Vega;
                array[85] = BoardData.Delta;
            }

            return array;
        }

        private static object[] BoardToArray2(string str)
        {
            var objectJson = DynamicJson.Parse(str);

            BoardResult BoardData = (BoardResult)objectJson;

            object[] array = new object[BoardCol];
            array[0] = BoardData.Symbol;
            array[1] = BoardData.SymbolName;
            array[2] = BoardData.Exchange;
            array[3] = BoardData.ExchangeName;
            array[4] = BoardData.CurrentPrice;
            array[5] = BoardData.CurrentPriceTime;
            array[6] = BoardData.CurrentPriceChangeStatus;
            array[7] = BoardData.CurrentPriceStatus;
            array[8] = BoardData.CalcPrice;
            array[9] = BoardData.PreviousClose;
            array[10] = BoardData.PreviousCloseTime;
            array[11] = BoardData.ChangePreviousClose;
            array[12] = BoardData.ChangePreviousClosePer;
            array[13] = BoardData.OpeningPrice;
            array[14] = BoardData.OpeningPriceTime;
            array[15] = BoardData.HighPrice;
            array[16] = BoardData.HighPriceTime;
            array[17] = BoardData.LowPrice;
            array[18] = BoardData.LowPriceTime;
            array[19] = BoardData.TradingVolume;
            array[20] = BoardData.TradingVolumeTime;
            array[21] = BoardData.VWAP;
            array[22] = BoardData.TradingValue;
            array[23] = BoardData.BidQty;
            array[24] = BoardData.BidPrice;
            array[25] = BoardData.BidTime;
            array[26] = BoardData.BidSign;
            array[27] = BoardData.MarketOrderSellQty;
            if (!(BoardData.Sell1 == null))
            {
                array[28] = BoardData.Sell1.Time;
                array[29] = BoardData.Sell1.Sign;
                array[30] = BoardData.Sell1.Price;
                array[31] = BoardData.Sell1.Qty;
            }
            if (!(BoardData.Sell2 == null))
            {
                array[32] = BoardData.Sell2.Price;
                array[33] = BoardData.Sell2.Qty;
            }
            if (!(BoardData.Sell3 == null))
            {

                array[34] = BoardData.Sell3.Price;
                array[35] = BoardData.Sell3.Qty;
            }
            if (!(BoardData.Sell4 == null))
            {
                array[36] = BoardData.Sell4.Price;
                array[37] = BoardData.Sell4.Qty;
            }
            if (!(BoardData.Sell5 == null))
            {
                array[38] = BoardData.Sell5.Price;
                array[39] = BoardData.Sell5.Qty;
            }
            if (!(BoardData.Sell6 == null))
            {
                array[40] = BoardData.Sell6.Price;
                array[41] = BoardData.Sell6.Qty;
            }
            if (!(BoardData.Sell7 == null))
            {
                array[42] = BoardData.Sell7.Price;
                array[43] = BoardData.Sell7.Qty;
            }
            if (!(BoardData.Sell8 == null))
            {
                array[44] = BoardData.Sell8.Price;
                array[45] = BoardData.Sell8.Qty;
            }
            if (!(BoardData.Sell9 == null))
            {
                array[46] = BoardData.Sell9.Price;
                array[47] = BoardData.Sell9.Qty;
            }
            if (!(BoardData.Sell10 == null))
            {
                array[48] = BoardData.Sell10.Price;
                array[49] = BoardData.Sell10.Qty;
            }
            array[50] = BoardData.AskQty;
            array[51] = BoardData.AskPrice;
            array[52] = BoardData.AskTime;
            array[53] = BoardData.AskSign;
            array[54] = BoardData.MarketOrderBuyQty;
            if (!(BoardData.Buy1 == null))
            {
                array[55] = BoardData.Buy1.Time;
                array[56] = BoardData.Buy1.Sign;
                array[57] = BoardData.Buy1.Price;
                array[58] = BoardData.Buy1.Qty;
            }
            if (!(BoardData.Buy2 == null))
            {
                array[59] = BoardData.Buy2.Price;
                array[60] = BoardData.Buy2.Qty;
            }
            if (!(BoardData.Buy3 == null))
            {
                array[61] = BoardData.Buy3.Price;
                array[62] = BoardData.Buy3.Qty;
            }
            if (!(BoardData.Buy4 == null))
            {
                array[63] = BoardData.Buy4.Price;
                array[64] = BoardData.Buy4.Qty;
            }
            if (!(BoardData.Buy5 == null))
            {
                array[65] = BoardData.Buy5.Price;
                array[66] = BoardData.Buy5.Qty;
            }
            if (!(BoardData.Buy6 == null))
            {
                array[67] = BoardData.Buy6.Price;
                array[68] = BoardData.Buy6.Qty;
            }
            if (!(BoardData.Buy7 == null))
            {
                array[69] = BoardData.Buy7.Price;
                array[70] = BoardData.Buy7.Qty;
            }
            if (!(BoardData.Buy8 == null))
            {
                array[71] = BoardData.Buy8.Price;
                array[72] = BoardData.Buy8.Qty;
            }
            if (!(BoardData.Buy9 == null))
            {
                array[73] = BoardData.Buy9.Price;
                array[74] = BoardData.Buy9.Qty;
            }
            if (!(BoardData.Buy10 == null))
            {
                array[75] = BoardData.Buy10.Price;
                array[76] = BoardData.Buy10.Qty;
            }
            array[77] = BoardData.OverSellQty;
            array[78] = BoardData.UnderBuyQty;
            array[79] = BoardData.TotalMarketValue;
            array[80] = BoardData.SettlementPrice;
            array[81] = BoardData.IV;
            array[82] = BoardData.Gamma;
            array[83] = BoardData.Theta;
            array[84] = BoardData.Vega;
            array[85] = BoardData.Delta;
            

            return array;
        }

        private static object RtdBoardData(string json, string symbol, int exchange, string item ,bool symbolCheck)
        {
            var objectJson = DynamicJson.Parse(json);

            BoardResult BoardData = (BoardResult)objectJson;

            if (symbolCheck)
            {
                if (!(symbol == BoardData.Symbol))
                    return "";
             
                if (!(exchange == BoardData.Exchange))
                    return "";
            }

            switch (item)
            {
                case "銘柄コード": 
                    return BoardData.Symbol;

                case "銘柄名": 
                    return BoardData.SymbolName;

                case "市場コード": 
                    return BoardData.Exchange;

                case "市場名称": 
                    return BoardData.ExchangeName;

                case "現値": 
                    return BoardData.CurrentPrice;

                case "現値時刻": 
                    return BoardData.CurrentPriceTime ?? "0";

                case "現値前値比較": 
                    return BoardData.CurrentPriceChangeStatus ?? "0";

                case "現値ステータス": 
                    return BoardData.CurrentPriceStatus;

                case "計算用現値": 
                    return BoardData.CalcPrice;

                case "前日終値": 
                    return BoardData.PreviousClose;

                case "前日終値日付": 
                    return BoardData.PreviousCloseTime ?? "0";

                case "前日比": 
                    return BoardData.ChangePreviousClose;

                case "騰落率": 
                    return BoardData.ChangePreviousClosePer;

                case "始値": 
                    return BoardData.OpeningPrice;

                case "始値時刻": 
                    return BoardData.OpeningPriceTime ?? "0";

                case "高値": 
                    return BoardData.HighPrice;

                case "高値時刻": 
                    return BoardData.HighPriceTime ?? "0";

                case "安値": 
                    return BoardData.LowPrice;

                case "安値時刻": 
                    return BoardData.LowPriceTime ?? "0";

                case "売買高": 
                    return BoardData.TradingVolume;

                case "売買高時刻": 
                    return BoardData.TradingVolumeTime ?? "0";

                case "売買高加重平均価格(VWAP)": 
                    return BoardData.VWAP;

                case "売買代金": 
                    return BoardData.TradingValue;

                case "最良売気配数量": 
                    return BoardData.BidQty;

                case "最良売気配値段": 
                    return BoardData.BidPrice;

                case "最良売気配時刻": 
                    return BoardData.BidTime;

                case "最良売気配フラグ": 
                    return BoardData.BidSign;

                case "売成行数量": 
                    return BoardData.MarketOrderSellQty;

                case "売気配(1)値段":
                    if (!(BoardData.Sell1 == null))
                        return BoardData.Sell1.Price;
                    break;

                case "売気配(1)数量":
                    if (!(BoardData.Sell1 == null))
                        return BoardData.Sell1.Qty;
                    break;

                case "売気配(1)時刻":
                    if (!(BoardData.Sell1 == null))
                        return BoardData.Sell1.Time;
                    break;

                case "売気配(1)気配フラグ":
                    if (!(BoardData.Sell1 == null))
                        return BoardData.Sell1.Sign;
                    break;

                case "売気配(2)値段":
                    if (!(BoardData.Sell2 == null))
                        return BoardData.Sell2.Price;
                    break;

                case "売気配(2)数量":
                    if (!(BoardData.Sell2 == null))
                        return BoardData.Sell2.Qty;
                    break;

                case "売気配(3)値段":
                    if (!(BoardData.Sell3 == null))
                        return BoardData.Sell3.Price;
                    break;

                case "売気配(3)数量":
                    if (!(BoardData.Sell3 == null))
                        return BoardData.Sell3.Qty;
                    break;

                case "売気配(4)値段":
                    if (!(BoardData.Sell4 == null))
                        return BoardData.Sell4.Price;
                    break;

                case "売気配(4)数量":
                    if (!(BoardData.Sell4 == null))
                        return BoardData.Sell4.Qty;
                    break;

                case "売気配(5)値段":
                    if (!(BoardData.Sell5 == null))
                        return BoardData.Sell5.Price;
                    break;

                case "売気配(5)数量":
                    if (!(BoardData.Sell5 == null))
                        return BoardData.Sell5.Qty;
                    break;

                case "売気配(6)値段":
                    if (!(BoardData.Sell6 == null))
                        return BoardData.Sell6.Price;
                    break;

                case "売気配(6)数量":
                    if (!(BoardData.Sell6 == null))
                        return BoardData.Sell6.Qty;
                    break;

                case "売気配(7)値段":
                    if (!(BoardData.Sell7 == null))
                        return BoardData.Sell7.Price;
                    break;

                case "売気配(7)数量":
                    if (!(BoardData.Sell7 == null))
                        return BoardData.Sell7.Qty;
                    break;

                case "売気配(8)値段":
                    if (!(BoardData.Sell8 == null))
                        return BoardData.Sell8.Price;
                    break;

                case "売気配(8)数量":
                    if (!(BoardData.Sell8 == null))
                        return BoardData.Sell8.Qty;
                    break;

                case "売気配(9)値段":
                    if (!(BoardData.Sell9 == null))
                        return BoardData.Sell9.Price;
                    break;

                case "売気配(9)数量":
                    if (!(BoardData.Sell9 == null))
                        return BoardData.Sell9.Qty;
                    break;

                case "売気配(10)値段":
                    if (!(BoardData.Sell10 == null))
                        return BoardData.Sell10.Price;
                    break;

                case "売気配(10)数量":
                    if (!(BoardData.Sell10 == null))
                        return BoardData.Sell10.Qty;
                    break;

                case "最良買気配数量":
                    return BoardData.AskQty;

                case "最良買気配値段":
                    return BoardData.AskPrice;

                case "最良買気配時刻":
                    return BoardData.AskTime;

                case "最良買気配フラグ":
                    return BoardData.AskSign;

                case "買成行数量":
                    return BoardData.MarketOrderBuyQty;

                case "買気配(1)値段":
                    if (!(BoardData.Buy1 == null))
                        return BoardData.Buy1.Price;
                    break;

                case "買気配(1)数量":
                    if (!(BoardData.Buy1 == null))
                        return BoardData.Buy1.Qty;
                    break;

                case "買気配(1)時刻":
                    if (!(BoardData.Buy1 == null))
                        return BoardData.Buy1.Time;
                    break;

                case "買気配(1)気配フラグ":
                    if (!(BoardData.Buy1 == null))
                        return BoardData.Buy1.Sign;
                    break;

                case "買気配(2)値段":
                    if (!(BoardData.Buy2 == null))
                        return BoardData.Buy2.Price;
                    break;

                case "買気配(2)数量":
                    if (!(BoardData.Buy2 == null))
                        return BoardData.Buy2.Qty;
                    break;

                case "買気配(3)値段":
                    if (!(BoardData.Buy3 == null))
                        return BoardData.Buy3.Price;
                    break;

                case "買気配(3)数量":
                    if (!(BoardData.Buy3 == null))
                        return BoardData.Buy3.Qty;
                    break;

                case "買気配(4)値段":
                    if (!(BoardData.Buy4 == null))
                        return BoardData.Buy4.Price;
                    break;

                case "買気配(4)数量":
                    if (!(BoardData.Buy4 == null))
                        return BoardData.Buy4.Qty;
                    break;

                case "買気配(5)値段":
                    if (!(BoardData.Buy5 == null))
                        return BoardData.Buy5.Price;
                    break;

                case "買気配(5)数量":
                    if (!(BoardData.Buy5 == null))
                        return BoardData.Buy5.Qty;
                    break;

                case "買気配(6)値段":
                    if (!(BoardData.Buy6 == null))
                        return BoardData.Buy6.Price;
                    break;

                case "買気配(6)数量":
                    if (!(BoardData.Buy6 == null))
                        return BoardData.Buy6.Qty;
                    break;

                case "買気配(7)値段":
                    if (!(BoardData.Buy7 == null))
                        return BoardData.Buy7.Price;
                    break;

                case "買気配(7)数量":
                    if (!(BoardData.Buy7 == null))
                        return BoardData.Buy7.Qty;
                    break;

                case "買気配(8)値段":
                    if (!(BoardData.Buy8 == null))
                        return BoardData.Buy8.Price;
                    break;

                case "買気配(8)数量":
                    if (!(BoardData.Buy8 == null))
                        return BoardData.Buy8.Qty;
                    break;

                case "買気配(9)値段":
                    if (!(BoardData.Buy9 == null))
                        return BoardData.Buy9.Price;
                    break;

                case "買気配(9)数量":
                    if (!(BoardData.Buy9 == null))
                        return BoardData.Buy9.Qty;
                    break;

                case "買気配(10)値段":
                    if (!(BoardData.Buy10 == null))
                        return BoardData.Buy10.Price;
                    break;

                case "買気配(10)数量":
                    if (!(BoardData.Buy10 == null))
                        return BoardData.Buy10.Qty;
                    break;

                case "OVER気配数量":
                    return BoardData.OverSellQty;

                case "UNDER気配数量":
                    return BoardData.UnderBuyQty;

                case "時価総額":
                    return BoardData.TotalMarketValue;

                case "清算値":
                    return BoardData.SettlementPrice;

                case "インプライド・ボラティリティ(IV)":
                    return BoardData.IV;

                case "ガンマ":
                    return BoardData.Gamma;

                case "セータ":
                    return BoardData.Theta;

                case "ベガ":
                    return BoardData.Vega;

                case "デルタ":
                    return BoardData.Delta;

                default:
                    return "";
            }

            return "";
        }

        [ExcelFunction(IsHidden = true)]
        public static object BoardResultCheck(string value)
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
            ret = BoardToArray(value);
            return ret;
        }

        [ExcelFunction(IsHidden = true)]
        public static object[] BoardResultArray(string value)
        {
            var objectJson = DynamicJson.Parse(value);
            object[] ret;
            if (objectJson.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray2(value);
                return ret;
            }

            // multidimensional arrays
            ret = BoardToArray2(value);
            return ret;
        }

        /// <summary>
        /// boardDataの銘柄、市場コードが引数のsymbol、exchangeと一致したら場合、itemの値を返す
        /// </summary>
        [ExcelFunction(IsHidden = true)]
        public static object RtdBoardResultCheck(string boardData, string symbol, int exchange, string item, bool symbolCheck)
        {
            var objectJson = DynamicJson.Parse(boardData);
            object ret;
            if (objectJson.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(boardData);
                return ret;
            }

            ret = RtdBoardData(boardData, symbol, exchange, item, symbolCheck);
            return ret;
        }

    }
}
