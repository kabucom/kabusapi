using ExcelDna.Integration;
using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using KabuSuteAddin.Utils;
using KabuSuteAddin.Elements;
using Codeplex.Data;

namespace KabuSuteAddin
{
    public static class ExcelFunctionController
    {

        private static ExcelFunctionMiddleware middleware = new ExcelFunctionMiddleware();
        public static bool _websocketStream = false;
        public static string _websocketData;

        /// <summary>
        /// カブステからAPIトークンを取得する
        /// </summary>
        [ExcelFunction(Name = "KABUSUTE_API_TOKEN", IsHidden = true)]
        public static string KABUSUTE_API_TOKEN(
            [ExcelArgument(Description = "", Name = "APIパスワード")] string ApiPassword)
        {

            try
            {
                var ResultMessage = Validate.ValidateToken(ApiPassword);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                return middleware.GetToken(ApiPassword);
            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 注文取消し
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _cancelOrderCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "CANCELORDER", Category = "kabuSTATIONアドイン", Description = "注文を取消する.", IsHidden = false)]
        public static object CANCELORDER(
            [ExcelArgument(Description = "の注文を取消する", Name = "受付注文番号")] string orderId,
            [ExcelArgument(Description = "", Name = "注文パスワード")] string orderPassword)
        {
            string ret = null;
            try
            {

                string ResultMessage = Validate.ValidateOrderCancel(orderId, orderPassword);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = orderId + "-" + orderPassword;
                if (_cancelOrderCache.TryGetValue(tplKey, out tpl))
                {
                    ret = tpl.Item2;
                }
                else
                {
                    ret = middleware.PutCancelOrder(orderId, orderPassword);

                    var objectJson = DynamicJson.Parse(ret);
                    if (!objectJson.IsDefined("Code"))
                    {
                        _cancelOrderCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                    }
                }

                var arr = Util.SingleDimToArray(ret);

                return XlCall.Excel(XlCall.xlUDF, "Resize", arr);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 取引余力（現物）取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _walletCash = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "WALLET.CASH", Category = "kabuSTATIONアドイン", Description = "取引余力（現物）を取得する.", IsHidden = false)]
        public static object WALLET_CASH(
            [ExcelArgument(Description = "の取引余力（現物）を取得する", Name = "銘柄コード")] string Symbol,
            [ExcelArgument(Description = "の取引余力（現物）を取得する", Name = "市場コード")] string Exchange)
        {
            string ret = null;
            try
            {

                string ResultMessage = Validate.ValidateRequired2(Symbol, Exchange);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Symbol + "-" + Exchange;
                if (_walletCash.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetWalletCash(Symbol, Exchange);
                    _walletCash[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                var arr = Util.SingleDimToArray(ret);
                return XlCall.Excel(XlCall.xlUDF, "Resize", arr);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 取引余力（信用）取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _walletMarginCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "WALLET.MARGIN", Category = "kabuSTATIONアドイン", Description = "取引余力（信用）を取得する.", IsHidden = false)]
        public static object WALLET_MARGIN(
            [ExcelArgument(Description = "の取引余力（信用）を取得する", Name = "銘柄コード")] string Symbol,
            [ExcelArgument(Description = "の取引余力（信用）を取得する", Name = "市場コード")] string Exchange)
        {
            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateRequired2(Symbol, Exchange);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Symbol + "-" + Exchange;
                if (_walletMarginCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetWalletMargin(Symbol, Exchange);
                    _walletMarginCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = WalletResult.WalletCheck(ret, WALLET.MARGIN);

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 取引余力（先物）取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _walletFutureCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "WALLET.FUTURE", Category = "kabuSTATIONアドイン", Description = "取引余力（先物）を取得する.", IsHidden = false)]
        public static object WALLET_FUTURE(
            [ExcelArgument(Description = "の取引余力（先物）を取得する", Name = "銘柄コード")] string Symbol,
            [ExcelArgument(Description = "の取引余力（先物）を取得する", Name = "市場コード")] string Exchange)
        {
            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateRequired2(Symbol, Exchange);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Symbol + "-" + Exchange;
                if (_walletFutureCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetWalletFuture(Symbol, Exchange);
                    _walletFutureCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = WalletResult.WalletCheck(ret, WALLET.FUTURE);

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }
        }

        /// <summary>
        /// 取引余力（オプション）取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _walletOptionCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "WALLET.OPTION", Category = "kabuSTATIONアドイン", Description = "取引余力（オプション）を取得する.", IsHidden = false)]
        public static object WALLET_OPTION(
            [ExcelArgument(Description = "の取引余力（オプション）を取得する", Name = "銘柄コード")] string Symbol,
            [ExcelArgument(Description = "の取引余力（オプション）を取得する", Name = "市場コード")] string Exchange)
        {
            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateRequired2(Symbol, Exchange);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Symbol + "-" + Exchange;
                if (_walletOptionCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetWalletOption(Symbol, Exchange);
                    _walletOptionCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = WalletResult.WalletCheck(ret, WALLET.OPTION);

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 時価・板情報の取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _boardCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "BOARD", Category = "kabuSTATIONアドイン", Description = "指定した銘柄の時価情報・板情報を取得する.", IsHidden = false)]
        public static object BOARD(
            [ExcelArgument(Description = "の時価情報を取得する", Name = "銘柄コード")] string Symbol,
            [ExcelArgument(Description = "の時価情報を取得する", Name = "市場コード")] string Exchange)
        {
            string ret = null;
            try
            {

                string ResultMessage = Validate.ValidateRequired(Symbol, Exchange);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Symbol + "-" + Exchange;
                if (_boardCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;

                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetBoard(Symbol, Exchange);
                    _boardCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = BoardResult.BoadCheck(ret);

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 銘柄情報の取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _symbolCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "SYMBOL", Category = "kabuSTATIONアドイン", Description = "指定した銘柄情報を取得する.", IsHidden = false)]
        public static object SYMBOL(
            [ExcelArgument(Description = "の銘柄情報を取得する", Name = "銘柄コード")] string Symbol,
            [ExcelArgument(Description = "の銘柄情報を取得する", Name = "市場コード")] string Exchange)
        {
            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateRequired(Symbol, Exchange);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Symbol + "-" + Exchange;
                if (_symbolCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetSymbol(Symbol, Exchange);
                    _symbolCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = SymbolResult.SymbolCheck(ret);

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 注文一覧の取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _ordersCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "ORDERS", Category = "kabuSTATIONアドイン", Description = "注文一覧を取得する.", IsHidden = false)]
        public static object ORDERS(
            [ExcelArgument(Description = "の注文情報を取得する", Name = "商品種別")] string SecurityType)
        {

            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateSingle(SecurityType);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = SecurityType;
                if (_ordersCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetOrders(SecurityType);
                    _ordersCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = Orders.OrdersResultCheck(ret);
                if (array == null)
                    // 検証用でAPI実行結果がエラーではない場合
                    return 0;

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 残高照会の取得
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _positionsCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "POSITIONS", Category = "kabuSTATIONアドイン", Description = "残高一覧を取得する.", IsHidden = false)]
        public static object POSITIONS(
            [ExcelArgument(Description = "の注文情報を取得する", Name = "商品種別")] string SecurityType)
        {

            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateSingle(SecurityType);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = SecurityType;
                if (_positionsCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.GetPositions(SecurityType);
                    _positionsCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = PositionsResult.PositionCheck(ret);
                if (array == null)
                    // 検証用でAPI実行結果がエラーではない場合
                    return 0;

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 銘柄登録
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _registerCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "REGISTERSYMBOL", Description = "PUSH配信する銘柄を登録する.", Category = "kabuSTATIONアドイン", IsHidden = false)]
        public static object REGISTERS(
            [ExcelArgument(Description = "銘柄コード、市場コードのセル範囲を指定する", Name = "銘柄情報")] object[,] symboldata)
        {

            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateRegister(symboldata);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Util.ArrayToText(symboldata);
                if (_registerCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.StockRegistration(symboldata);
                    _registerCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = RegisterResult.RegisterCheck(ret);

                if (array == null)
                    // 検証用でAPI実行結果がエラーではない場合
                    return 0;

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);


            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 銘柄登録解除
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _unRegisterCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "UNREGISTERSYMBOL", Description = "PUSH配信の登録銘柄を解除する.", Category = "kabuSTATIONアドイン", IsHidden = false)]
        public static object UNREGISTERSYMBOL(
            [ExcelArgument(Description = "銘柄コード、市場コードのセル範囲を指定する", Name = "銘柄情報")] object[,] symboldata)
        {

            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateRegister(symboldata);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = Util.ArrayToText(symboldata);
                if (_unRegisterCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.UnRegistSymbol(symboldata);
                    _unRegisterCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = RegisterResult.RegisterCheck(ret);
                if (array == null)
                    // 検証用でAPI実行結果がエラーではない場合
                    return 0;

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }

        }

        /// <summary>
        /// 全登録銘柄の解除
        /// </summary>
        private static Dictionary<string, Tuple<DateTime, string>> _unregisterAllCache = new Dictionary<string, Tuple<DateTime, string>>();
        [ExcelFunction(Name = "UNREGISTER_ALL", Category = "kabuSTATIONアドイン", Description = "PUSH配信している銘柄をすべて解除する", IsHidden = false)]
        public static object UNREGISTER_ALL()
        {
            string ret = null;
            try
            {
                string ResultMessage = Validate.ValidateCommon();
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = "UNREGISTER_ALL";
                if (_unregisterAllCache.TryGetValue(tplKey, out tpl))
                {
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                        ret = tpl.Item2;
                }
                if (String.IsNullOrEmpty(ret))
                {
                    ret = middleware.UnregisterAll();
                    _unregisterAllCache[tplKey] = Tuple.Create(DateTime.Now, ret);
                }

                object array;
                array = RegisterResult.RegisterCheck(ret);
                if (!CustomRibbon._env)
                    return 0;

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);
            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }
            
        }

        [ExcelFunction(IsHidden = true)]           
        public static string ReturnWebSocketData()
        {
            string ret;
            ret = middleware.GetWebSocketData();
            return ret;
        }

        /// <summary>
        /// PUSH配信
        /// </summary>
        private static readonly object lockWebsocketData = new object();
        public static Dictionary<string, Tuple<DateTime, BoardElement>> _websocketCache = new Dictionary<string, Tuple<DateTime, BoardElement>>();
        [ExcelFunction(Description = "指定した銘柄のPUSH配信を開始する.", Name = "WEBSOCKET", Category = "kabuSTATIONアドイン")]
        public static object WEBSOCKET(
            [ExcelArgument(Description = "", Name = "銘柄コード")] string symbol,
            [ExcelArgument(Description = "", Name = "市場コード")] string exchange,
            [ExcelArgument(Description = "", Name = "項目名")] string itemName)
        {
            try
            {

                string ResultMessage = Validate.ValidateRtdBoard(_websocketStream, symbol, exchange, itemName);
                if (!string.IsNullOrEmpty(ResultMessage))
                    return ResultMessage;

                if (!_websocketStream  && CustomRibbon._updatePressed)
                    middleware.StartWebSocket();

                object ret = null;
                if (CustomRibbon._updatePressed)
                    ret = XlCall.RTD(RtdBoard.WebApiRequestServerProgId, null, "WEBSOCKET");

                if (!CustomRibbon._env)
                    return 0;

                Dictionary<string, Tuple<DateTime, BoardElement>> _Cache = _websocketCache;
                object returnData = "";

                if (_Cache.Count > 0)
                {
                    var tplKey = symbol + "-" + exchange;
                    Tuple<DateTime, BoardElement> tpl;
                    if (_Cache.TryGetValue(tplKey, out tpl))
                    {
                        returnData = BoardResult.GetBoardItem(tpl.Item2, symbol, int.Parse(exchange), itemName, false);
                    }

                    // 銘柄コード、市場コードのキーでキャッシュに該当データが無い場合、指数としてキャッシュをチェック
                    if (string.IsNullOrEmpty(returnData.ToString()))
                    {
                        // Nullの場合、キャッシュには"0"で登録されるため、市場コ－ド"0"でキャッシュをチェック
                        tplKey = symbol + "-" + "0";
                        if (_Cache.TryGetValue(tplKey, out tpl))
                        {
                            returnData = BoardResult.GetBoardItem(tpl.Item2, symbol, int.Parse(exchange), itemName, false);
                        }
                    }

                }

                return returnData;

            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                    return exception.Message;
                else
                    return exception.InnerException.Message;
            }
        }

        // key : 先物コード-限月、value : Tuple<Tupleを作成した日時, APIからの戻り値>
        private static Dictionary<string, Tuple<DateTime, string>> _symbolNameFutureCache = new Dictionary<string, Tuple<DateTime, string>>();
        /// <summary>
        /// 先物銘柄コード取得
        /// </summary>
        [ExcelFunction(Name = "SYMBOLNAME.FUTURE", Category = "kabuSTATIONアドイン", Description = "先物銘柄コードを取得する.（先物コードは\"で囲んで文字列としてください）", IsHidden = false)]
        public static object SYMBOLNAME_FUTURE(
            [ExcelArgument(Description = "に対応する先物銘柄コードを取得する", Name = "先物コード")] string FutureCode,
            [ExcelArgument(Description = "に対応する先物銘柄コードを取得する", Name = "限月")] string DerivMonth)
        {
            string json = null;
            try
            {
                string ResultMessage = Validate.ValidateRequired(FutureCode, DerivMonth);
                if (!string.IsNullOrEmpty(ResultMessage)) return ResultMessage;
                
                Tuple<DateTime, string> tpl;
                var tplKey = FutureCode + "-" + DerivMonth;
                if (_symbolNameFutureCache.TryGetValue(tplKey, out tpl))
                {
                    // ArrayResizerで3回元の関数が呼び出されるので、キャッシュでAPIの呼び出し回数を抑える
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                    {
                        json = tpl.Item2;
                    }
                }

                if (string.IsNullOrEmpty(json))
                {
                    json = middleware.GetSymbolNameFuture(FutureCode, DerivMonth);
                    _symbolNameFutureCache[tplKey] = Tuple.Create(DateTime.Now, json);
                }

                object[] array = SymbolName.SymbolNameCheck(json);

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);
            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                {
                    return exception.Message;
                }
                else
                {
                    return exception.InnerException.Message;
                }
            }
        }

        // key : 限月-プット／コール区分-権利行使価格、value : Tuple<Tupleを作成した日時, APIからの戻り値>
        private static Dictionary<string, Tuple<DateTime, string>> _symbolNameOptionCache = new Dictionary<string, Tuple<DateTime, string>>();
        /// <summary>
        /// オプション銘柄コード取得
        /// </summary>
        [ExcelFunction(Name = "SYMBOLNAME.OPTION", Category = "kabuSTATIONアドイン", Description = "オプション銘柄コードを取得する.（プット／コール区分は\"で囲んで文字列としてください）", IsHidden = false)]
        public static object SYMBOLNAME_OPTION(
            [ExcelArgument(Description = "に対応するオプション銘柄コードを取得する", Name = "限月")] string DerivMonth,
            [ExcelArgument(Description = "に対応するオプション銘柄コードを取得する", Name = "プット／コール区分")] string PutOrCall,
            [ExcelArgument(Description = "に対応するオプション銘柄コードを取得する", Name = "権利行使価格")] string StrikePrice)
        {
            string json = null;
            try
            {
                string ResultMessage = Validate.ValidateRequiredAll(DerivMonth, PutOrCall, StrikePrice);
                if (!string.IsNullOrEmpty(ResultMessage)) return ResultMessage;

                Tuple<DateTime, string> tpl;
                var tplKey = string.Format("{0}-{1}-{2}", DerivMonth, PutOrCall, StrikePrice);
                if (_symbolNameOptionCache.TryGetValue(tplKey, out tpl))
                {
                    // ArrayResizerで3回元の関数が呼び出されるので、キャッシュでAPIの呼び出し回数を抑える
                    if ((DateTime.Now - tpl.Item1).TotalSeconds < 1)
                    {
                        json = tpl.Item2;
                    }
                }

                if (string.IsNullOrEmpty(json))
                {
                    json = middleware.GetSymbolNameOption(DerivMonth, PutOrCall, StrikePrice);
                    _symbolNameOptionCache[tplKey] = Tuple.Create(DateTime.Now, json);
                }

                object[] array = SymbolName.SymbolNameCheck(json);

                return XlCall.Excel(XlCall.xlUDF, "Resize", array);
            }
            catch (Exception exception)
            {
                if (exception.InnerException == null)
                {
                    return exception.Message;
                }
                else
                {
                    return exception.InnerException.Message;
                }
            }
        }
    }


    internal class ExcelFunctionMiddleware
    {
        private static HttpClient client = new HttpClient();
        private const string domain = @"http://localhost:";
        private const string wsDomain = @"ws://localhost:";

        public ExcelFunctionMiddleware()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        //----------------------------------
        // トークン取得
        internal string GetToken(string ApiPassword)
        {

            var param = new TokenParam
            {
                APIPassword = ApiPassword
            };

            var json = "";
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(TokenParam));
                serializer.WriteObject(stream, param);
                json = Encoding.UTF8.GetString(stream.ToArray());
            }

            var url = domain + CustomRibbon._port + "/kabusapi/token";
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = new StringContent(json);
            request.Content.Headers.ContentType.MediaType = @"application/json";
            request.Content.Headers.ContentType.CharSet = null;


            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;

        }

        //----------------------------------
        // 注文取消
        internal string PutCancelOrder(string orderId, string orderPassword)
        {

            var param = new CancelOrderParam
            {
                OrderId = orderId,
                OrderPassword = orderPassword,
            };

            var json = "";
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(CancelOrderParam));
                serializer.WriteObject(stream, param);
                json = Encoding.UTF8.GetString(stream.ToArray());
            }

            var url = domain + CustomRibbon._port + "/kabusapi/cancelorder";
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // 時価情報取得
        internal string GetBoard(string Symbol, string Exchange)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/board/" + Symbol + "@" + Exchange);
            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // 取引余力（現物）
        internal string GetWalletCash(string Symbol, string Exchange)
        {

            var requestString = "";

            if (!string.IsNullOrEmpty(Symbol) || !string.IsNullOrEmpty(Exchange))
            {
                requestString = "/" + Symbol + "@" + Exchange;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/wallet/cash" + requestString);
            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // 取引余力（信用）
        internal string GetWalletMargin(string Symbol, string Exchange)
        {

            var requestString = "";

            if (!string.IsNullOrEmpty(Symbol) || !string.IsNullOrEmpty(Exchange))
            {
                requestString = "/" + Symbol + "@" + Exchange;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/wallet/margin" + requestString);
            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // 取引余力（先物）
        internal string GetWalletFuture(string Symbol, string Exchange)
        {

            var requestString = "";

            if (!string.IsNullOrEmpty(Symbol) || !string.IsNullOrEmpty(Exchange))
            {
                requestString = "/" + Symbol + "@" + Exchange;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/wallet/future" + requestString);
            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // 取引余力（OP）
        internal string GetWalletOption(string Symbol, string Exchange)
        {

            var requestString = "";

            if (!string.IsNullOrEmpty(Symbol) || !string.IsNullOrEmpty(Exchange))
            {
                requestString = "/" + Symbol + "@" + Exchange;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/wallet/option" + requestString);
            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;

            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // 銘柄情報取得x
        internal string GetSymbol(string Symbol, string Exchange)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/symbol/" + Symbol + "@" + Exchange);

            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }


        //----------------------------------
        // 注文約定照会取得
        internal string GetOrders(string Product)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/orders?product=" + Product);

            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;

        }


        //----------------------------------
        // 注文約定照会取得
        internal string GetPositions(string Product)
        {

            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/positions?product=" + Product);

            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;

        }

        //----------------------------------
        // 銘柄登録
        internal string StockRegistration(object[,] symbolData)
        {

            var json = Util.SymbolArrayToString(symbolData);

            var url = domain + CustomRibbon._port + "/kabusapi/register";
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;

        }

        //----------------------------------
        // 銘柄登録解除
        internal string UnRegistSymbol(object[,] symbolData)
        {
            var json = Util.SymbolArrayToString(symbolData);

            var url = domain + CustomRibbon._port + "/kabusapi/unregister";
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // 銘柄登録全解除
        internal string UnregisterAll()
        {
            var url = domain + CustomRibbon._port + "/kabusapi/unregister/all";
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);

            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }


        //----------------------------------
        // PUSH配信
        // WebSocket を開始し、受信スレッド起動
        internal void StartWebSocket()
        {
            var uri = wsDomain + CustomRibbon._port + "/kabusapi/websocket";
            var ws = new ClientWebSocket();
            var con = ws.ConnectAsync(new Uri(uri), CancellationToken.None);
            // 接続完了待ち
            con.Wait();

            if (con.Status == TaskStatus.RanToCompletion)
            {
                ExcelFunctionController._websocketStream = true;
            }


            // 受信タスク開始
            Task.Run(() => RecvWebScoketData(ws));
        }

        private string lastRecvMessage;
        private readonly object lockLastRecvMessage = new object();

        [ExcelFunction(IsThreadSafe = false, IsMacroType = true)]
        private void RecvWebScoketData(ClientWebSocket ws)
        {
            // 受信バッファ
            // 1回のメッセージを受信できるのに十分な大きさ
            var buffer = new byte[4096];

            // websocket情報格納用の配列
            var segment = new ArraySegment<byte>(buffer);

            // WebSocketでサーバーからPushされた値を受信し続ける
            while (true)
            {
                // 更新を無効にした場合、Websocketを停止
                if (!CustomRibbon._updatePressed)
                {
                    ws.CloseAsync(WebSocketCloseStatus.NormalClosure, "ユーザーによる更新停止", CancellationToken.None);
                    ExcelFunctionController._websocketStream = false;
                }
                else
                {
                    var resultTask = ws.ReceiveAsync(segment, CancellationToken.None);
                    var message = Encoding.UTF8.GetString(buffer, 0, resultTask.Result.Count);

                    try
                    {
                        // 受信したメッセージをキャッシュへ格納
                        lock (lockLastRecvMessage)
                        {
                            lastRecvMessage = message;
                            if (resultTask.Result.EndOfMessage)
                            { 
                                if (lastRecvMessage != null && lastRecvMessage != "0" && lastRecvMessage != "ExcelErrorNA")
                                {
                                    var objectJson = DynamicJson.Parse(lastRecvMessage);
                                    BoardElement boardData = (BoardElement)objectJson;
                                    var tplKey = boardData.Symbol + "-" + boardData.Exchange;
                                    ExcelFunctionController._websocketCache[tplKey] = Tuple.Create(DateTime.Now, boardData);

                                }
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        // キャッシュに登録できない場合、何もしない（JSON変換できない場合など）
                        System.Diagnostics.Trace.WriteLine(exception.Message);
                    }

                }

            }
        }

        // WebSocketから受信した最新Messageを返す
        internal string GetWebSocketData()
        {
            string ret;
            lock (lockLastRecvMessage)
            {
                ret = lastRecvMessage;
                ExcelFunctionController._websocketData = lastRecvMessage;
            }
            return ret;
        }

        //----------------------------------
        // 先物銘柄コード取得
        internal string GetSymbolNameFuture(string FutureCode, string DerivMonth)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/symbolname/future?FutureCode=" + FutureCode + "&DerivMonth=" + DerivMonth);
            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);
            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        //----------------------------------
        // オプション銘柄コード取得
        internal string GetSymbolNameOption(string DerivMonth, string PutOrCall, string StrikePrice)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, domain + CustomRibbon._port + "/kabusapi/symbolname/option?DerivMonth=" + DerivMonth + "&PutOrCall=" + PutOrCall + "&StrikePrice=" + StrikePrice);
            request.Headers.Add(@"X-API-KEY", CustomRibbon._token);
            HttpResponseMessage response = client.SendAsync(request).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
