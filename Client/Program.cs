using Newtonsoft.Json;
using Shared;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 9999);
            TcpClient client = new TcpClient();
            client.Connect(endPoint);

            using var writer = new StreamWriter(client.GetStream());
            while (true)
            {
                Console.WriteLine("Press enter to send message...");
                Console.ReadKey(true);

                MyMessage message = new MyMessage()
                {
                    IntProperty = 200,
                    StringProperty = "Response Status : OK"
                };

                MyLogin login = new MyLogin()
                {
                    Username = "admin",
                    Password = "1234"
                };

                Protocol protocol = new Protocol(message, (int)Shared.Type.ProtocolTypes.MyLogin);

                writer.WriteLine(JsonConvert.SerializeObject(protocol));
                writer.Flush();
            }
        }
    }
}
