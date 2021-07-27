using System;
using Newtonsoft.Json;
using System.Net.Http;

namespace CSharp_sample
{
    class Kabusapi_Orders
    {
        static void Main(string[] args)
        {
            string product = "4";
            string id = "";
            string updTime = "";
            string details = "";
            string symbol = "";
            string state = "";
            string side = "";
            string cashMargin = "";

            var token = GenerateToken.GetToken();

            var builder = new UriBuilder("http://localhost:18080/kabusapi/orders");
            var param = System.Web.HttpUtility.ParseQueryString(builder.Query);
            if (!string.IsNullOrEmpty(product))
            {
                param["product"] = product;
            }
            if (!string.IsNullOrEmpty(id))
            {
                param["id"] = id;
            }
            if (!string.IsNullOrEmpty(updTime))
            {
                param["updtime"] = updTime;
            }
            if (!string.IsNullOrEmpty(details))
            {
                param["details"] = details;
            }
            if (!string.IsNullOrEmpty(symbol))
            {
                param["symbol"] = symbol;
            }
            if (!string.IsNullOrEmpty(state))
            {
                param["state"] = state;
            }
            if (!string.IsNullOrEmpty(side))
            {
                param["side"] = side;
            }
            if (!string.IsNullOrEmpty(cashMargin))
            {
                param["cashmargin"] = cashMargin;
            }
            builder.Query = param.ToString();

            string url = builder.ToString();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("X-API-KEY", token);
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
