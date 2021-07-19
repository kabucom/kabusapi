using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web;

namespace CSharp_sample
{
    class Kabusapi_Symbolname_Future
    {
        static void Main(string[] args)
        {
            string FutureCode = "NK225";
            int DerivMonth = 202109;

            var builder = new UriBuilder("http://localhost:18080/kabusapi/symbolname/future");
            var param = HttpUtility.ParseQueryString(builder.Query);
            string token = GenerateToken.GetToken();

            if (!string.IsNullOrEmpty(FutureCode))
            {
                param["FutureCode"] = FutureCode;
            }
            param["DerivMonth"] = DerivMonth.ToString();

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
