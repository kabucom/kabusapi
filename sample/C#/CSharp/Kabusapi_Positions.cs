using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace CSharp_sample
{
    class Kabusapi_Positions
    {
        static void Main(string[] args)
        {
            string product = "4";
            string symbol = "";

            string token = GenerateToken.GetToken();

            var builder = new UriBuilder("http://localhost:18080/kabusapi/positions");
            var param = System.Web.HttpUtility.ParseQueryString(builder.Query);
            if (!string.IsNullOrEmpty(product))
            {
                param["Product"] = product;
            }
            if (!string.IsNullOrEmpty(symbol))
            {
                param["symbol"] = symbol;
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
