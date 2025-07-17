using System;
using System.Threading;

namespace task17
{
    public class HardStopCommand : ICommand
    {
        private ServerThread server;

        public HardStopCommand(ServerThread srv)
        {
            server = srv;
        }

        public void Execute()
        {
            if (Thread.CurrentThread != server.GetThread())
            {
                throw new InvalidOperationException("HardStop можно вызывать только в своём потоке");
            }
            server.HardStop();
        }
    }
}