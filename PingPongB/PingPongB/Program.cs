using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace PingPongB
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip = Dns.GetHostEntry("localhost").AddressList[0]; //create socket listener
            TcpListener server = new TcpListener(ip, 11000);
            TcpClient client = default(TcpClient);

            try
            {
                server.Start();
                Console.WriteLine("server started..");
                Console.Read();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Read();

            }
            while(true)
            {
                client = server.AcceptTcpClient();

                byte[] receivedbuffer = new byte[100];
                NetworkStream stream = client.GetStream();

                stream.Read(receivedbuffer, 0, receivedbuffer.Length);

                string msg = Encoding.ASCII.GetString(receivedbuffer, 0, receivedbuffer.Length);

                Console.WriteLine( msg); 
                Console.Read();


            }


        }
    }
}
