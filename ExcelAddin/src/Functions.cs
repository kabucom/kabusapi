using ExcelDna.Integration;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Net.WebSockets;
using System.Threading;

namespace KabuSuteAddin
{
    class Functions
    {
        private static WebAPIMiddleware middleware = new WebAPIMiddleware();


        [ExcelFunction(Name = "test_GetRTDPrice", Category = "", Description = "Get real-time price of the symbol", HelpTopic = "時価情報を取得します")]
        public static object test_GetRTDPrice(string symbol)
        {

            if (string.IsNullOrEmpty(symbol))
            {
                symbol = ("8411@1");
            }

            return XlCall.RTD(RTDWebApiRestExcelService.WebApiRequestServerProgId, null, symbol);

        }

        //-------------------------------------------------
        [ExcelFunction(Description = "Get Server Status")]
        public static string test_GetStatus()
        {
            var ret = middleware.GetStatus();
            return ret;
        }
        [ExcelFunction(Description = "Get MarketData", HelpTopic = "時価情報を取得します")]
        public static string test_GetMarketData([ExcelArgument(Description = "の時価情報を取得します", Name = "銘柄コード@市場コード")] string symbol)
        {
            string ret;
            if (string.IsNullOrEmpty(symbol))
            {
                ret = middleware.GetMarketData("5401@1");
            }
            else
            {
                ret = middleware.GetMarketData(symbol);
            }

            return ret;
        }
        [ExcelFunction(Description = "Put SendOrder")]
        public static string test_PutSendOrder()
        {
            var ret = middleware.SendOrder();
            return ret;
        }
        [ExcelFunction(Description = "PUSH配信する銘柄を登録する。")]
        public static string test_RegistMarketData([ExcelArgument(Description = "を登録します", Name = "銘柄コード@市場コード")]string symbol)
        {
            string ret;
            if (string.IsNullOrEmpty(symbol))
            {
                // ret = middleware.RegistMarketData("5401@1");
                ret = middleware.RegistMarketData("165060019@2");
            }
            else
            {
                ret = middleware.RegistMarketData(symbol);
            }

            return ret;
        }
#if false
                [ExcelFunction(Description = "Recv MarketData")]
                public static string test_RecvMarketData()
                {
                    var ret = middleware.RecvMarketData();

                    return ret;
                }
#endif
        [ExcelFunction(Description = "Start WebSocket")]
        public static void test_StartWebSocket()
        {
            middleware.StartWebSocket();
        }
        [ExcelFunction(Description = "Get WebSocketData")]
        public static string test_GetWebSocketData()
        {
            return middleware.GetWebSocketData();
        }
    }

    internal class WebAPIMiddleware
    {
        private static HttpClient client = new HttpClient();

        public WebAPIMiddleware()
        {
            // client.BaseAddress = new Uri("http://httpbin.org/post");
            // client.BaseAddress = new Uri("http://localhost:8080/httplistener");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal async Task<decimal> GetPriceMarket(string query)
        {
            HttpResponseMessage response = await client.GetAsync(query);
            var price = await response.Content.ReadAsAsync<decimal>();
            return price;
        }

        public async Task<decimal> GetPriceBySymbol(string symbol)
        {
            var price = await GetPriceMarket("api/market/?symbol=" + symbol); ;
            return price;
        }

        internal async Task<HttpResponseMessage> GetHttpbin(string query)
        {
            var parameters = new Dictionary<string, string>()
                    {
                        { "foo", "fuga1" },
                        { "bar", "fuga2" },
                    };
            //var body = string.Join(@"&", parameters.Select(pair => $"{pair.Key}={}"));
            //var body = "";
            //var content = new StringContent(body, Encoding.UTF8, @"application/x-www-form-urlencoded");
            var content = new FormUrlEncodedContent(parameters);

            HttpResponseMessage response = await client.PostAsync(@"http://httpbin.org/post", content);
            var price = await response.Content.ReadAsAsync<String>();
            Console.WriteLine(price);
            return response;

        }

        //----------------------------------
        // サーバーステータス取得
        internal string GetStatus()
        {
            HttpResponseMessage response = client.GetAsync("http://localhost:18080/kabusapi/state").Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        // 4本値など取得
        internal string GetMarketData(string symbol)
        {
            HttpResponseMessage response = client.GetAsync("http://localhost:18080/kabusapi/market/" + symbol).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        // 発注パラメータ
        [DataContract]
        public class SendOrderParam
        {
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
        // 発注
        internal string SendOrder()
        {
            // 発注パラメータ
            var param = new SendOrderParam
            {
                Symbol = "8001@1",
                CashMargin = 1,
                DelivType = 2,
                ExpireDay = 20200403,
                ExpireSession = 0,
                FundType = "AA",
                MarginTradeType = 1,
                OrdType = 1,
                Price = 0,
                PriceType = 1,
                Qty = 100,
                Side = "2",
                TimeInForce = 0,
            };

            var json = "";
            using (var stream = new MemoryStream())
            {
                var serializer = new DataContractJsonSerializer(typeof(SendOrderParam));
                serializer.WriteObject(stream, param);
                json = Encoding.UTF8.GetString(stream.ToArray());
            }

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync("http://localhost:18080/kabusapi/sendorder", content).Result;
            return response.Content.ReadAsStringAsync().Result;
        }
        internal string RegistMarketData(string symbol)
        {
            HttpResponseMessage response = client.GetAsync("http://localhost:18080/kabusapi/websocket/regist/" + symbol).Result;
            return response.Content.ReadAsStringAsync().Result;
        }

        // 4本値など受信（WebSocket）
        internal string RecvMarketData()
        {
            var ws = new ClientWebSocket();
            var con = ws.ConnectAsync(new Uri("ws://localhost:18080/kabusapi/websocket/start"), CancellationToken.None);
            // 接続完了待ち
            con.Wait();

            // 受信バッファ
            var buffer = new ArraySegment<byte>(new byte[500]);

            // WebSocketでサーバーからPushされた値を受信し続ける
            while (true)
            {
                var receiveTask = ws.ReceiveAsync(buffer, CancellationToken.None);
                var message = Encoding.UTF8.GetString(buffer.Array, 0, receiveTask.Result.Count);

                Console.WriteLine(message);
            }

            // ws.CloseAsync(WebSocketCloseStatus.Empty, string.Empty, CancellationToken.None).Wait();

            return "";
        }

        // WebSocket を開始し、受信スレッド起動
        internal void StartWebSocket()
        {
            var ws = new ClientWebSocket();
            var con = ws.ConnectAsync(new Uri("ws://localhost:18080/kabusapi/websocket/start"), CancellationToken.None);
            // 接続完了待ち
            con.Wait();

            // 受信タスク開始
            Task.Run(() => RecvWebScoketData(ws));
        }

        private string lastRecvMessage;
        private readonly object lockLastRecvMessage = new object();

        [ExcelFunction(IsThreadSafe = false, IsMacroType = true)]
        private void RecvWebScoketData(ClientWebSocket ws)
        {
            // 受信バッファ
            var buffer = new ArraySegment<byte>(new byte[500]);

            // WebSocketでサーバーからPushされた値を受信し続ける
            while (true)
            {
                var receiveTask = ws.ReceiveAsync(buffer, CancellationToken.None);
                var message = Encoding.UTF8.GetString(buffer.Array, 0, receiveTask.Result.Count);

                // 受信した最新MessageをlastRecvMessageへ
                lock (lockLastRecvMessage)
                {
                    lastRecvMessage = message;
                }

                // バックグラウンドのスレッドからは ExcdlReference 関連のメソッドをコールできない？（Exception発生）
                // https://stackoverflow.com/questions/15903055/xlcall-excelxlcall-xlccalculatenow-throws-a-xlcallexception-when-evented-from
                // You cannot call the Excel C API (XlCall.Excel or any of the ExcelReference methods) from a non-calculation thread.
                // var cell = new ExcelReference(1, 1);
                // cell.SetValue(lastRecvMessage);
            }
        }

        // WebSocketから受信した最新Messageを返す
        internal string GetWebSocketData()
        {
            string ret;
            lock (lockLastRecvMessage)
            {
                ret = lastRecvMessage;
            }
            return ret;
        }
    }
}
