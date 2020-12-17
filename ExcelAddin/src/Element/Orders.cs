using Codeplex.Data;
using ExcelDna.Integration;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace KabuSuteAddin.Elements
{
    [DataContract]
    public class OrdersResultModel
    {
        [DataMember(Name = "ID")]
        public string ID { get; set; }

        [DataMember(Name = "State")]
        public double State { get; set; }

        [DataMember(Name = "OrderState")]
        public double OrderState { get; set; }

        [DataMember(Name = "OrdType")]
        public double OrdType { get; set; }

        [DataMember(Name = "RecvTime")]
        public string RecvTime { get; set; }

        [DataMember(Name = "Symbol")]
        public string Symbol { get; set; }

        [DataMember(Name = "SymbolName")]
        public string SymbolName { get; set; }

        [DataMember(Name = "Exchange")]
        public double Exchange { get; set; }

        [DataMember(Name = "ExchangeName")]
        public string ExchangeName { get; set; }

        [DataMember(Name = "TimeInForce")]
        public double TimeInForce { get; set; }

        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "OrderQty")]
        public double OrderQty { get; set; }

        [DataMember(Name = "CumQty")]
        public double CumQty { get; set; }

        [DataMember(Name = "Side")]
        public string Side { get; set; }

        [DataMember(Name = "CashMargin")]
        public double CashMargin { get; set; }

        [DataMember(Name = "AccountType")]
        public double AccountType { get; set; }

        [DataMember(Name = "DelivType")]
        public double DelivType { get; set; }

        [DataMember(Name = "ExpireDay")]
        public double ExpireDay { get; set; }

        [DataMember(Name = "MarginTradeType")]
        public double MarginTradeType { get; set; }


        [DataMember(Name = "Details")]
        public List<OrderDetails> Details { get; set; }
    }

    [DataContract]
    public class OrderDetails
    {
        [DataMember(Name = "SeqNum")]
        public double SeqNum { get; set; }

        [DataMember(Name = "ID")]
        public string ID { get; set; }

        [DataMember(Name = "RecType")]
        public double RecType { get; set; }

        [DataMember(Name = "ExchangeID")]
        public string ExchangeID { get; set; }

        [DataMember(Name = "State")]
        public double State { get; set; }

        [DataMember(Name = "TransactTime")]
        public string TransactTime { get; set; }

        [DataMember(Name = "OrdType")]
        public double OrdType { get; set; }

        [DataMember(Name = "Price")]
        public double Price { get; set; }

        [DataMember(Name = "Qty")]
        public double Qty { get; set; }

        [DataMember(Name = "ExecutionID")]
        public string ExecutionID { get; set; }

        [DataMember(Name = "ExecutionDay")]
        public string ExecutionDay { get; set; }

        [DataMember(Name = "DelivDay")]
        public double DelivDay { get; set; }

        [DataMember(Name = "Commission")]
        public double Commission { get; set; }

        [DataMember(Name = "CommissionTax")]
        public double CommissionTax { get; set; }
    }


    public class Orders
    {
        private const int OrdersColDetails = 33;
        private const int OrdersColNoDetails = 19;

        [ExcelFunction(IsHidden = true)]
        public static object OrdersDataToArray(dynamic objectJson)
        {
            List<OrdersResultModel> OrdersArray = (List<OrdersResultModel>)objectJson;
            
            if (OrdersArray.Count == 0)
                return null;
            
            int DetailRows = 0;

            for (int i = 0; i < OrdersArray.Count; i++)
            {
                DetailRows += OrdersArray[i].Details.Count;
            }

            object[,] array = DetailRows == 0 ? new object[OrdersArray.Count, OrdersColNoDetails] : new object[DetailRows, OrdersColDetails];
            
            int row = 0;

            for (int i = 0; i < OrdersArray.Count; i++)
            {
                array[row, 0] = OrdersArray[i].ID ?? "";
                array[row, 1] = OrdersArray[i].State;
                array[row, 2] = OrdersArray[i].OrderState;
                array[row, 3] = OrdersArray[i].OrdType;
                array[row, 4] = OrdersArray[i].RecvTime ?? "";
                array[row, 5] = OrdersArray[i].Symbol ?? "";
                array[row, 6] = OrdersArray[i].SymbolName ?? "";
                array[row, 7] = OrdersArray[i].Exchange;
                array[row, 8] = OrdersArray[i].ExchangeName ?? "";
                array[row, 9] = OrdersArray[i].TimeInForce;
                array[row, 10] = OrdersArray[i].Price;
                array[row, 11] = OrdersArray[i].OrderQty;
                array[row, 12] = OrdersArray[i].CumQty;
                array[row, 13] = OrdersArray[i].Side ?? "";
                array[row, 14] = OrdersArray[i].CashMargin;
                array[row, 15] = OrdersArray[i].AccountType;
                array[row, 16] = OrdersArray[i].DelivType;
                array[row, 17] = OrdersArray[i].ExpireDay;
                array[row, 18] = OrdersArray[i].MarginTradeType;

                if (DetailRows != 0)
                {
                    
                    for (int j = 0; j < OrdersArray[i].Details.Count; j++)
                    {
                        if (j > 0)
                        {
                            // 2列目以降の前半は空データを表示
                            // 配列数式の変換処理を行うとnullの場合エクセルに0が表示されるため
                            for (int col = 0; col < 19; col++)
                            {
                                array[row, col] = "";
                            }
                        }
                        array[row, 19] = OrdersArray[i].Details[j].SeqNum;
                        array[row, 20] = OrdersArray[i].Details[j].ID ?? "";
                        array[row, 21] = OrdersArray[i].Details[j].RecType;
                        array[row, 22] = OrdersArray[i].Details[j].ExchangeID ?? "";
                        array[row, 23] = OrdersArray[i].Details[j].State;
                        array[row, 24] = OrdersArray[i].Details[j].TransactTime ?? "";
                        array[row, 25] = OrdersArray[i].Details[j].OrdType;
                        array[row, 26] = OrdersArray[i].Details[j].Price;
                        array[row, 27] = OrdersArray[i].Details[j].Qty;
                        array[row, 28] = OrdersArray[i].Details[j].ExecutionID ?? "";
                        array[row, 29] = OrdersArray[i].Details[j].ExecutionDay ?? "";
                        array[row, 30] = OrdersArray[i].Details[j].DelivDay;
                        array[row, 31] = OrdersArray[i].Details[j].Commission;
                        array[row, 32] = OrdersArray[i].Details[j].CommissionTax;
                        row++;
                    }
                }
                else
                {
                    row++;
                }


            }
            
            

            return array;
        }

        [ExcelFunction(IsHidden = true)]
        public static object OrdersResultCheck(string value)
        {
            var objectJson = DynamicJson.Parse(value);
            object ret;
            if (objectJson.IsDefined("Code"))
            {
                // API Error
                ret = Utils.Util.SingleDimToArray(value);
                return ret;
            }
            else if (!CustomRibbon._env)
            {
                return 0;
            }

            ret = OrdersDataToArray(objectJson);

            return ret;
        }
    }
}
