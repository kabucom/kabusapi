using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace CSharp_sample
{
    class Kabusapi_Board
    {
        static void Main(string[] args)
        {
            string Symbol = "8306";
            string Exchange = "1";
            var url = "http://localhost:18080/kabusapi/board" + "/" + Symbol + "@" + Exchange;
            string token = GenerateToken.GetToken();
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("X-API-KEY", token);
                HttpResponseMessage response = client.SendAsync(request).Result;
                Console.WriteLine("{0} \n {1}", JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result), response.Headers);
                Console.ReadKey();
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
