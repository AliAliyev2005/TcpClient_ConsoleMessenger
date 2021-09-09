using Newtonsoft.Json;
using Shared;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 9999);

            TcpListener server = new TcpListener(endPoint);
            server.Start();
            Console.WriteLine("Server is running...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Client is connected...");

                Task.Run(() =>
                {
                    using var stream = client.GetStream();
                    using var reader = new StreamReader(stream);
                    while (true)
                    {
                        Protocol protocol = JsonConvert.DeserializeObject<Protocol>(reader.ReadLine());

                        if (protocol.Type == (int)Shared.Type.ProtocolTypes.MyMessage)
                        {
                            MyMessage data = JsonConvert.DeserializeObject<MyMessage>(protocol.Data.ToString());
                            Console.WriteLine(data);
                        }

                        else if (protocol.Type == (int)Shared.Type.ProtocolTypes.MyLogin)
                        {
                            MyLogin data = JsonConvert.DeserializeObject<MyLogin>(protocol.Data.ToString());
                            Console.WriteLine(data);
                        }
                    }
                });
            }
        }
    }
}
