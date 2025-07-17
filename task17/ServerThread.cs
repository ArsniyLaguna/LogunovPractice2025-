using System;
using System.Collections.Concurrent;
using System.Threading;

namespace task17
{
    public class ServerThread
    {
        private BlockingCollection<ICommand> commands = new();
        private Thread? worker;
        private bool softStop = false;
        private bool hardStop = false;

        public void Start()
        {
            worker = new Thread(() =>
            {
                while (!hardStop && (!softStop || commands.Count > 0))
                {
                    try
                    {
                        if (commands.TryTake(out var cmd, 100))
                        {
                            cmd.Execute();
                        }
                        else
                        {
                            Thread.Sleep(10); // ❗ неэффективно
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка в команде: " + ex.Message);
                    }
                }
            });
            worker.Start();
        }

        public void AddCommand(ICommand cmd)
        {
            commands.Add(cmd);
        }

        public void HardStop()
        {
            hardStop = true;
        }

        public void SoftStop()
        {
            softStop = true;
        }

        public Thread? GetThread()
        {
            return worker;
        }
    }
}