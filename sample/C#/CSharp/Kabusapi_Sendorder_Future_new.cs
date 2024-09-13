using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace CSharp_sample
{
    class Kabusapi_Sendorder_Future_new
    {
        static void Main(string[] args)
        {
            var obj = new
            {
                Symbol = "166090018",
                Exchange = 24,
                TradeType = 1,
                TimeInForce = 2,
                Side = "1",
                Qty = 3,
                FrontOrderType = 30,
                Price = 29000,
                ExpireDay = 0,
                ReverseLimitOrder = new
                {
                    TriggerPrice = 29001,
                    UnderOver = 2,
                    AfterHitOrderType = 1,
                    AfterHitPrice = 0
                }
                
            };
            var url = "http://localhost:18080/kabusapi/sendorder/future";
            string token = GenerateToken.GetToken();

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Headers.Add("ContentType", "application/json");
                request.Headers.Add("X-API-KEY", token);
                request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.SendAsync(request).Result;
                Console.WriteLine("{0} \n {1}", JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result), response.Headers);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("{0} {1}", e, e.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} {1}", ex, ex.Message);
                Console.ReadKey();
            }

            Console.ReadKey();
        }
    }
}
