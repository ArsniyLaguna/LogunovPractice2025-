using System.Collections.Concurrent;

namespace task18;

public class RoundRobinScheduler : IScheduler
{
    private readonly Queue<ICommand> _commands = new();

    public void Add(ICommand cmd)
    {
        _commands.Enqueue(cmd);
    }

    public bool HasCommand()
    {
        return _commands.Count > 0;
    }

    public ICommand Select()
    {
        var cmd = _commands.Dequeue();
        _commands.Enqueue(cmd);
        return cmd;
    }
}