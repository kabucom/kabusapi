
using System.Collections.Generic;
using System.Runtime.Serialization;
using Codeplex.Data;
using ExcelDna.Integration;

namespace KabuSuteAddin.Elements
{

    public class RankingDefaultResult
    {
        [DataMember(Name ="Type")]
        public string Type { get; set; }
        [DataMember(Name = "ExchangeDivision")]
        public string ExchangeDivision { get; set; }
        [DataMember(Name = "Ranking")]
        public List<RankingDefault> Ranking { get; set; }

    }

    [DataContract]
    public class RankingDefault
    {
        [DataMember(Name ="No")]
        public int No { get; set; }
        [DataMember(Name = "Trend")]
        public string Trend { get; set; }
        [DataMember(Name = "AverageRanking")]
        public int AverageRanking { get; set; }
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }
        [DataMember(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }
        [DataMember(Name = "ChangeRatio")]
        public double ChangeRatio { get; set; }
        [DataMember(Name = "ChangePercentage")]
        public double ChangePercentage { get; set; }
        [DataMember(Name = "CurrentPriceTime")]
        public string CurrentPriceTime { get; set; }
        [DataMember(Name = "TradingVolume")]
        public double TradingVolume { get; set; }
        [DataMember(Name = "Turnover")]
        public double Turnover { get; set; }
        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }
        [DataMember(Name = "CategoryName")]
        public string CategoryName { get; set; }
    }

    public class RankingByTickCountResult
    {
        [DataMember(Name = "Type")]
        public string Type { get; set; }
        [DataMember(Name = "ExchangeDivision")]
        public string ExchangeDivision { get; set; }
        [DataMember(Name = "Ranking")]
        public List<RankingByTickCount> Ranking { get; set; }
    }

    [DataContract]
    public class RankingByTickCount
    {
        [DataMember(Name = "No")]
        public int No { get; set; }
        [DataMember(Name = "Trend")]
        public string Trend { get; set; }
        [DataMember(Name = "AverageRanking")]
        public double AverageRanking { get; set; }
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }
        [DataMember(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }
        [DataMember(Name = "ChangeRatio")]
        public double ChangeRatio { get; set; }
        [DataMember(Name = "TickCount")]
        public int TickCount { get; set; }
        [DataMember(Name = "UpCount")]
        public int UpCount { get; set; }
        [DataMember(Name = "DownCount")]
        public int DownCount { get; set; }
        [DataMember(Name = "ChangePercentage")]
        public double ChangePercentage { get; set; }
        [DataMember(Name = "TradingVolume")]
        public double TradingVolume { get; set; }
        [DataMember(Name = "Turnover")]
        public double Turnover { get; set; }
        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }
        [DataMember(Name = "CategoryName")]
        public string CategoryName { get; set; }

    }

    public class RankingByTradeVolumnResult
    {
        [DataMember(Name = "Type")]
        public string Type { get; set; }
        [DataMember(Name = "ExchangeDivision")]
        public string ExchangeDivision { get; set; }
        [DataMember(Name = "Ranking")]
        public List<RankingByTradeVolumn> Ranking { get; set; }
    }

    [DataContract]
    public class RankingByTradeVolumn
    {
        [DataMember(Name = "No")]
        public int No { get; set; }
        [DataMember(Name = "Trend")]
        public string Trend { get; set; }
        [DataMember(Name = "AverageRanking")]
        public int AverageRanking { get; set; }
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }
        [DataMember(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }
        [DataMember(Name = "ChangeRatio")]
        public double ChangeRatio { get; set; }
        [DataMember(Name = "RapidTradePercentage")]
        public double RapidTradePercentage { get; set; }
        [DataMember(Name = "TradingVolume")]
        public double TradingVolume { get; set; }
        [DataMember(Name = "CurrentPriceTime")]
        public string CurrentPriceTime { get; set; }
        [DataMember(Name = "ChangePercentage")]
        public double ChangePercentage { get; set; }
        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }
        [DataMember(Name = "CategoryName")]
        public string CategoryName { get; set; }

    }

    public class RankingByTradeValueResult
    {
        [DataMember(Name = "Type")]
        public string Type { get; set; }
        [DataMember(Name = "ExchangeDivision")]
        public string ExchangeDivision { get; set; }
        [DataMember(Name = "Ranking")]
        public List<RankingByTradeValue> Ranking { get; set; }
    }

    [DataContract]
    public class RankingByTradeValue
    {
        [DataMember(Name = "No")]
        public int No { get; set; }
        [DataMember(Name = "Trend")]
        public string Trend { get; set; }
        [DataMember(Name = "AverageRanking")]
        public int AverageRanking { get; set; }
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }
        [DataMember(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }
        [DataMember(Name = "ChangeRatio")]
        public double ChangeRatio { get; set; }
        [DataMember(Name = "RapidTradePercentage")]
        public double RapidPaymentPercentage { get; set; }
        [DataMember(Name = "Turnover")]
        public double Turnover { get; set; }
        [DataMember(Name = "CurrentPriceTime")]
        public string CurrentPriceTime { get; set; }
        [DataMember(Name = "ChangePercentage")]
        public double ChangePercentage { get; set; }
        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }
        [DataMember(Name = "CategoryName")]
        public string CategoryName { get; set; }
    }

    public class RankingByMarginResult
    {
        [DataMember(Name = "Type")]
        public string Type { get; set; }
        [DataMember(Name = "ExchangeDivision")]
        public string ExchangeDivision { get; set; }
        [DataMember(Name = "Ranking")]
        public List<RankingByMargin> Ranking { get; set; }
    }

    [DataContract]
    public class RankingByMargin
    {
        [DataMember(Name = "No")]
        public int No { get; set; }
        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }
        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }
        [DataMember(Name = "SellRapidPaymentPercentage")]
        public double SellRapidPaymentPercentage { get; set; }
        [DataMember(Name = "SellLastWeekRatio")]
        public double SellLastWeekRatio { get; set; }
        [DataMember(Name = "BuyRapidPaymentPercentage")]
        public double BuyRapidPaymentPercentage { get; set; }
        [DataMember(Name = "BuyLastWeekRatio")]
        public double BuyLastWeekRatio { get; set; }
        [DataMember(Name = "Ratio")]
        public double Ratio { get; set; }
        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }
        [DataMember(Name = "CategoryName")]
        public string CategoryName { get; set; }

    }

    public class RankingByIndustryResult
    {
        [DataMember(Name = "Type")]
        public string Type { get; set; }
        [DataMember(Name = "ExchangeDivision")]
        public string ExchangeDivision { get; set; }
        [DataMember(Name = "Ranking")]
        public List<RankingByIndustry> Ranking { get; set; }
    }

    [DataContract]
    public class RankingByIndustry
    {
        [DataMember(Name = "No")]
        public int No { get; set; }
        [DataMember(Name = "Trend")]
        public string Trend { get; set; }
        [DataMember(Name = "AverageRanking")]
        public double AverageRanking { get; set; }
        [DataMember(Name = "Category")]
        public string Category { get; set; }
        [DataMember(Name = "CategoryName")]
        public string CategoryName { get; set; }
        [DataMember(Name = "CurrentPrice")]
        public double CurrentPrice { get; set; }
        [DataMember(Name = "ChangeRatio")]
        public double ChangeRatio { get; set; }
        [DataMember(Name = "CurrentPriceTime")]
        public string CurrentPriceTime { get; set; }
        [DataMember(Name = "ChangePercentage")]
        public double ChangePercentage { get; set; }
    }

    public class RankingResult
    {
        private const int RankingDefualtCol = 15;
        private const int RankingTickCountCol = 17;
        private const int RankingTradeCol = 15;
        private const int RankingMarginCol = 12;
        private const int RankingIndustryCol = 11;

        [ExcelFunction(IsHidden = true)]
        public static object RankingDefaultToArray(dynamic objectJson)
        {
            RankingDefaultResult RankingData = (RankingDefaultResult)objectJson;

            //object[,] Array = RankingData.Ranking.Count == 0 ? new object[0, 1] : new object[RankingData.Ranking.Count, RankingDefualtCol];
            if(RankingData.Ranking.Count == 0)
            {
                object[] array = new object[2];
                array[0] = RankingData.Type;
                array[1] = RankingData.ExchangeDivision;
                return array;
            }
            else
            {
                object[,] array = new object[RankingData.Ranking.Count, RankingDefualtCol];

                int row = 0;

                array[row, 0] = RankingData.Type;
                array[row, 1] = RankingData.ExchangeDivision;
                for(int i=0; i< RankingData.Ranking.Count; i++)
                {
                    if (i > 0)
                    {
                        for(int col = 0; col < 2;col++) {
                            array[row, col] = "";
                        }
                    }
                    array[row, 2] = RankingData.Ranking[i].No;
                    array[row, 3] = RankingData.Ranking[i].Trend;
                    array[row, 4] = RankingData.Ranking[i].AverageRanking;
                    array[row, 5] = RankingData.Ranking[i].Symbol;
                    array[row, 6] = RankingData.Ranking[i].SymbolName;
                    array[row, 7] = RankingData.Ranking[i].CurrentPrice;
                    array[row, 8] = RankingData.Ranking[i].ChangeRatio;
                    array[row, 9] = RankingData.Ranking[i].ChangePercentage;
                    array[row, 10] = RankingData.Ranking[i].CurrentPriceTime;
                    array[row, 11] = RankingData.Ranking[i].TradingVolume;
                    array[row, 12] = RankingData.Ranking[i].Turnover;
                    array[row, 13] = RankingData.Ranking[i].ExchangeName;
                    array[row, 14] = RankingData.Ranking[i].CategoryName;
                    row++;
                }
                return array;
            }
        }

        [ExcelFunction(IsHidden = true)]
        public static object RankingBytickCountToArray(dynamic objectJson)
        {
            RankingByTickCountResult RankingData = (RankingByTickCountResult)objectJson;

            if (RankingData.Ranking.Count == 0)
            {
                object[] array = new object[2];
                array[0] = RankingData.Type;
                array[1] = RankingData.ExchangeDivision;
                return array;
            }
            else
            {
                object[,] array = new object[RankingData.Ranking.Count, RankingTickCountCol];

                int row = 0;

                array[row, 0] = RankingData.Type;
                array[row, 1] = RankingData.ExchangeDivision;
                for (int i = 0; i < RankingData.Ranking.Count; i++)
                {
                    if (i > 0)
                    {
                        for (int col = 0; col < 2; col++)
                        {
                            array[row, col] = "";
                        }
                    }
                    array[row, 2] = RankingData.Ranking[i].No;
                    array[row, 3] = RankingData.Ranking[i].Trend;
                    array[row, 4] = RankingData.Ranking[i].AverageRanking;
                    array[row, 5] = RankingData.Ranking[i].Symbol;
                    array[row, 6] = RankingData.Ranking[i].SymbolName;
                    array[row, 7] = RankingData.Ranking[i].CurrentPrice;
                    array[row, 8] = RankingData.Ranking[i].ChangeRatio;
                    array[row, 9] = RankingData.Ranking[i].TickCount;
                    array[row, 10] = RankingData.Ranking[i].UpCount;
                    array[row, 11] = RankingData.Ranking[i].DownCount;
                    array[row, 12] = RankingData.Ranking[i].ChangePercentage;
                    array[row, 13] = RankingData.Ranking[i].TradingVolume;
                    array[row, 14] = RankingData.Ranking[i].Turnover;
                    array[row, 15] = RankingData.Ranking[i].ExchangeName;
                    array[row, 16] = RankingData.Ranking[i].CategoryName;
                    row++;
                }
                return array;
            }
            
        }

        [ExcelFunction(IsHidden = true)]
        public static object RankingByTradeVolumnToArray(dynamic objectJson)
        {
            RankingByTradeVolumnResult RankingData = (RankingByTradeVolumnResult)objectJson;
            if (RankingData.Ranking.Count == 0)
            {
                object[] array = new object[2];
                array[0] = RankingData.Type;
                array[1] = RankingData.ExchangeDivision;
                return array;
            }
            else
            {
                object[,] array = new object[RankingData.Ranking.Count, RankingTradeCol];

                int row = 0;

                array[row, 0] = RankingData.Type;
                array[row, 1] = RankingData.ExchangeDivision;
                for (int i = 0; i < RankingData.Ranking.Count; i++)
                {
                    if (i > 0)
                    {
                        for (int col = 0; col < 2; col++)
                        {
                            array[row, col] = "";
                        }
                    }
                    array[row, 2] = RankingData.Ranking[i].No;
                    array[row, 3] = RankingData.Ranking[i].Trend;
                    array[row, 4] = RankingData.Ranking[i].AverageRanking;
                    array[row, 5] = RankingData.Ranking[i].Symbol;
                    array[row, 6] = RankingData.Ranking[i].SymbolName;
                    array[row, 7] = RankingData.Ranking[i].CurrentPrice;
                    array[row, 8] = RankingData.Ranking[i].ChangeRatio;
                    array[row, 9] = RankingData.Ranking[i].RapidTradePercentage;
                    array[row, 10] = RankingData.Ranking[i].TradingVolume;
                    array[row, 11] = RankingData.Ranking[i].CurrentPriceTime;
                    array[row, 12] = RankingData.Ranking[i].ChangePercentage;
                    array[row, 13] = RankingData.Ranking[i].ExchangeName;
                    array[row, 14] = RankingData.Ranking[i].CategoryName;
                    row++;
                }
                return array;
            }
            
        }

        [ExcelFunction(IsHidden = true)]
        public static object RankingByTradeValueToArray(dynamic objectJson)
        {
            RankingByTradeValueResult RankingData = (RankingByTradeValueResult)objectJson;
            if (RankingData.Ranking.Count == 0)
            {
                object[] array = new object[2];
                array[0] = RankingData.Type;
                array[1] = RankingData.ExchangeDivision;
                return array;
            }
            else
            {
                object[,] array = new object[RankingData.Ranking.Count, RankingTradeCol];

                int row = 0;

                array[row, 0] = RankingData.Type;
                array[row, 1] = RankingData.ExchangeDivision;
                for (int i = 0; i < RankingData.Ranking.Count; i++)
                {
                    if (i > 0)
                    {
                        for (int col = 0; col < 2; col++)
                        {
                            array[row, col] = "";
                        }
                    }
                    array[row, 2] = RankingData.Ranking[i].No;
                    array[row, 3] = RankingData.Ranking[i].Trend;
                    array[row, 4] = RankingData.Ranking[i].AverageRanking;
                    array[row, 5] = RankingData.Ranking[i].Symbol;
                    array[row, 6] = RankingData.Ranking[i].SymbolName;
                    array[row, 7] = RankingData.Ranking[i].CurrentPrice;
                    array[row, 8] = RankingData.Ranking[i].ChangeRatio;
                    array[row, 9] = RankingData.Ranking[i].RapidPaymentPercentage;
                    array[row, 10] = RankingData.Ranking[i].Turnover;
                    array[row, 11] = RankingData.Ranking[i].CurrentPriceTime;
                    array[row, 12] = RankingData.Ranking[i].ChangePercentage;
                    array[row, 13] = RankingData.Ranking[i].ExchangeName;
                    array[row, 14] = RankingData.Ranking[i].CategoryName;
                    row++;
                }
                return array;
            }
        }

        [ExcelFunction(IsHidden = true)]
        public static object RankingByMarginToArray(dynamic objectJson)
        {
            RankingByMarginResult RankingData = (RankingByMarginResult)objectJson;
            if (RankingData.Ranking.Count == 0)
            {
                object[] array = new object[2];
                array[0] = RankingData.Type;
                array[1] = RankingData.ExchangeDivision;
                return array;
            }
            else
            {
                object[,] array = new object[RankingData.Ranking.Count, RankingMarginCol];

                int row = 0;

                array[row, 0] = RankingData.Type;
                array[row, 1] = RankingData.ExchangeDivision;
                for (int i = 0; i < RankingData.Ranking.Count; i++)
                {
                    if (i > 0)
                    {
                        for (int col = 0; col < 2; col++)
                        {
                            array[row, col] = "";
                        }
                    }
                    array[row, 2] = RankingData.Ranking[i].No;
                    array[row, 3] = RankingData.Ranking[i].Symbol;
                    array[row, 4] = RankingData.Ranking[i].SymbolName;
                    array[row, 5] = RankingData.Ranking[i].SellRapidPaymentPercentage;
                    array[row, 6] = RankingData.Ranking[i].SellLastWeekRatio;
                    array[row, 7] = RankingData.Ranking[i].BuyRapidPaymentPercentage;
                    array[row, 8] = RankingData.Ranking[i].BuyLastWeekRatio;
                    array[row, 9] = RankingData.Ranking[i].Ratio;
                    array[row, 10] = RankingData.Ranking[i].ExchangeName;
                    array[row, 11] = RankingData.Ranking[i].CategoryName;
                    row++;
                }
                return array;
            }
        }

        [ExcelFunction(IsHidden = true)]
        public static object RankingByCategoryToArray(dynamic objectJson)
        {
            RankingByIndustryResult RankingData = (RankingByIndustryResult)objectJson;

            if (RankingData.Ranking.Count == 0)
            {
                object[] array = new object[2];
                array[0] = RankingData.Type;
                array[1] = RankingData.ExchangeDivision;
                return array;
            }
            else
            {
                object[,] array = new object[RankingData.Ranking.Count, RankingIndustryCol];

                int row = 0;

                array[row, 0] = RankingData.Type;
                array[row, 1] = RankingData.ExchangeDivision;
                for (int i = 0; i < RankingData.Ranking.Count; i++)
                {
                    if (i > 0)
                    {
                        for (int col = 0; col < 2; col++)
                        {
                            array[row, col] = "";
                        }
                    }
                    array[row, 2] = RankingData.Ranking[i].No;
                    array[row, 3] = RankingData.Ranking[i].Trend;
                    array[row, 4] = RankingData.Ranking[i].AverageRanking;
                    array[row, 5] = RankingData.Ranking[i].Category;
                    array[row, 6] = RankingData.Ranking[i].CategoryName;
                    array[row, 7] = RankingData.Ranking[i].CurrentPrice;
                    array[row, 8] = RankingData.Ranking[i].ChangeRatio;
                    array[row, 9] = RankingData.Ranking[i].CurrentPriceTime;
                    array[row, 10] = RankingData.Ranking[i].ChangePercentage;
                    row++;
                }
                return array;
            }
        }

        [ExcelFunction(IsHidden = true)]
        public static object RankingCheck(string value, string type)
        {
            var objectJson = DynamicJson.Parse(value);
            object ret = null;
            if (objectJson.IsDefined("Code") || !CustomRibbon._env)
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            switch (type)
            {
                case TYPE.PriceIncreaseRate:
                case TYPE.PriceDropRate:
                case TYPE.TopTradingVolume:
                case TYPE.TradingPrice:
                    ret = RankingDefaultToArray(objectJson);
                    break;
                case TYPE.TickCount:
                    ret = RankingBytickCountToArray(objectJson);
                    break;
                case TYPE.RapidIncreaseInTradingVolume:
                    ret = RankingByTradeVolumnToArray(objectJson);
                    break;
                case TYPE.RapidIncreaseInTradingValue:
                    ret = RankingByTradeValueToArray(objectJson);
                    break;
                case TYPE.IncreasedCreditSales:
                case TYPE.CreditSalesLoss:
                case TYPE.IncreasedCreditPurchase:
                case TYPE.CreditPurchaseBalanceReduction:
                case TYPE.CreditHighMagnification:
                case TYPE.CreditLowMagnification:
                    ret = RankingByMarginToArray(objectJson);
                    break;
                case TYPE.PriceIncreaseRateByCategory:
                case TYPE.PriceReductionRateByCategory:
                    ret = RankingByCategoryToArray(objectJson);
                    break;
                default:
                    ret = RankingDefaultToArray(objectJson);
                    break;
            }

            return ret;
        }
    }
    
}
