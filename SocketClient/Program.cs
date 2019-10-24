using System;
using System.IO;
using System.Net.Sockets;

namespace SocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient clientSocket = new TcpClient("127.0.0.1", 6789);
            Console.WriteLine("Klar");
            Console.WriteLine();
            Console.WriteLine("Afgiftberegning - udregn bilafgift");
            Console.WriteLine("---------------");
            Console.WriteLine("Hvad er prisen?");
            //Console.WriteLine("Send Normal eller El");

            // Provide a stream
            Stream ns = clientSocket.GetStream();

            StreamReader streamReader = new StreamReader(ns);
            StreamWriter streamWriter = new StreamWriter(ns) {AutoFlush = true};

            while (true)
            {
                string message = Console.ReadLine();
                if (message == "exit") break;
                streamWriter.WriteLine(message);
                string serverAnswer = streamReader.ReadLine();

                Console.WriteLine($"Server: {serverAnswer}");

            }

            Console.WriteLine("Stopper...");
            Console.ReadLine();

            ns.Close();
            clientSocket.Close();
        }
    }
}
