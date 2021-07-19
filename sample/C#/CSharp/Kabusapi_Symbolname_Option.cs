using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web;

namespace CSharp_sample
{
    class Kabusapi_Symbolname_Option
    {
        static void Main(string[] args)
        {
            string PutOrCall = "C";
            int DerivMonth = 0;
            int StrikePrice = 24000;

            string token = GenerateToken.GetToken();

            var builder = new UriBuilder("http://localhost:18080/kabusapi/symbolname/option");
            var param = HttpUtility.ParseQueryString(builder.Query);
            param["DerivMonth"] = DerivMonth.ToString();
            param["PutOrCall"] = PutOrCall;
            param["StrikePrice"] = StrikePrice.ToString();

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
