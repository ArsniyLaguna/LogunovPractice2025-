using System;
using System.Threading;

namespace task17
{
    public class SoftStopCommand : ICommand
    {
        private ServerThread server;

        public SoftStopCommand(ServerThread srv)
        {
            server = srv;
        }

        public void Execute()
        {
            if (Thread.CurrentThread != server.GetThread())
            {
                throw new InvalidOperationException("SoftStop можно вызывать только в своём потоке");
            }
            server.SoftStop();
        }
    }
}