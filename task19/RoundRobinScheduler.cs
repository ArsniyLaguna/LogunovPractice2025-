using System.Collections.Generic;

namespace Server;

public class RoundRobinScheduler : IScheduler
{
    private readonly Queue<ICommand> commands = new();

    public void Add(ICommand cmd)
    {
        commands.Enqueue(cmd);
    }

    public bool HasCommand()
    {
        return commands.Count > 0;
    }

    public ICommand Select()
    {
        if (commands.Count == 0)
            return null!;

        ICommand cmd = commands.Dequeue();
        commands.Enqueue(cmd); 
        return cmd;
    }
}