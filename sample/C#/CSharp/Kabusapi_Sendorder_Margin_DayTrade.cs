using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace CSharp_sample
{
    class Kabusapi_Sendorder_Margin_DayTrade
    {
        static void Main(string[] args)
        {
            var obj = new
            {
                Password = "111111",
                Symbol = "5104",
                Exchange = 1,
                SecurityType = 1,
                Side = "1",
                CashMargin = 2,
                MarginTradeType = 3,
                MarginPremiumUnit = 422,
                DelivType = 0,
                AccountType = 2,
                Qty = 100,
                FrontOrderType = 20,
                Price = 425,
                ExpireDay = 0
            };
            var url = "http://localhost:18080/kabusapi/sendorder";
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
