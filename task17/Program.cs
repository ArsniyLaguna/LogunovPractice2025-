using System;

namespace task17
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new ServerThread();
            server.Start();

            server.AddCommand(new SoftStopCommand(server));
            Console.WriteLine("Команда SoftStop отправлена");

            System.Threading.Thread.Sleep(1000);
        }
    }
}