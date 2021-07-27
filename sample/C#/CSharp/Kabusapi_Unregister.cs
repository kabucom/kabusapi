using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CSharp_sample
{
    class Kabusapi_Unregister
    {
        static void Main(string[] args)
        {
            var obj = new
            {
                Symbols = new[]
                {
                    new { Symbol = "8001", Exchange = 1},
                    new { Symbol = "101" , Exchange = 1 }
                }
            };
            var url = "http://localhost:18080/kabusapi/unregister";
            string token = GenerateToken.GetToken();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, url);
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
