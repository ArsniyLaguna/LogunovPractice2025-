using System.Collections.Concurrent;
using System.Threading;

namespace Server;

public class ServerThread
{
    private readonly BlockingCollection<ICommand> inputQueue = new();
    private readonly IScheduler scheduler;
    private readonly Thread workerThread;
    private volatile bool running = true;

    public ServerThread(IScheduler scheduler)
    {
        this.scheduler = scheduler;
        workerThread = new Thread(Loop);
        workerThread.Start();
    }

    public void AddCommand(ICommand cmd)
    {
        inputQueue.Add(cmd);
    }

    public void RequestHardStop()
    {
        running = false;
    }

    private void Loop()
    {
        while (running)
        {
            while (inputQueue.TryTake(out var cmd))
                scheduler.Add(cmd);

            if (scheduler.HasCommand())
            {
                var current = scheduler.Select();
                current.Execute();
                Thread.Sleep(10); 
            }
            else
            {
                Thread.Sleep(5); 
            }
        }
    }

    public void Join()
    {
        workerThread.Join();
    }
}