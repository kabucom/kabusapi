using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CSharp_sample
{
    class Kabusapi_Unregisterall
    {
        static void Main(string[] args)
        {
            var url = "http://localhost:18080/kabusapi/unregister/all";
            string token = GenerateToken.GetToken();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, url);
                request.Headers.Add("ContentType", "application/json");
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
