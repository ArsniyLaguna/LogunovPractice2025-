using System.Collections.Concurrent;
using System.Threading;

namespace task18;

public class ServerThread
{
    private readonly Thread _thread;
    private readonly BlockingCollection<ICommand> _queue = new();
    private readonly IScheduler _scheduler;
    private bool _running = true;

    public ServerThread(IScheduler scheduler)
    {
        _scheduler = scheduler;
        _thread = new Thread(Run);
        _thread.Start();
    }

    public void EnqueueCommand(ICommand cmd)
    {
        _queue.Add(cmd);
    }

    private void Run()
    {
        while (_running)
        {
            ICommand? cmd = null;

            if (_scheduler.HasCommand())
            {
                cmd = _scheduler.Select();
            }
            else if (_queue.TryTake(out var newCmd, TimeSpan.FromMilliseconds(100)))
            {
                cmd = newCmd;
            }

            if (cmd != null)
            {
                try
                {
                    cmd.Execute();

                    if (!cmd.IsCompleted)
                        _scheduler.Add(cmd);
                }
                catch (Exception)
                {
                }
            }
        }
    }

    public void Stop()
    {
        _running = false;
        _thread.Join();
    }
}