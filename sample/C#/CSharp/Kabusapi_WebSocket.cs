using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace CSharp_sample
{
    class Kabusapi_WebSocket
    {
        static void Main(string[] args)
        {

            var url = "ws://localhost:18080/kabusapi/websocket";
            var ws = new ClientWebSocket();

            var con = ws.ConnectAsync(new Uri(url), CancellationToken.None);
            con.Wait();
            if (con.Status == System.Threading.Tasks.TaskStatus.RanToCompletion)
            {
                var buffer = new byte[1024];
                var segment = new ArraySegment<byte>(buffer);
                while (true)
                {
                    var result = ws.ReceiveAsync(segment, CancellationToken.None);
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Result.Count);
                    Console.WriteLine("--- Receive Message");
                    Console.WriteLine(message);
                }
            }

        }
    }
}
