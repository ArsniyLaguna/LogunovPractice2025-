using System.Threading;
using Xunit;

namespace task18tests;

using task18;

public class DummyLongCommand : ICommand
{
    private int _runs = 0;
    public bool IsCompleted => _runs >= 3;

    public void Execute()
    {
        _runs++;
    }
}

public class ServerThreadTests
{
    [Fact]
    public void LongCommand_ShouldExecuteMultipleTimes()
    {
        var scheduler = new RoundRobinScheduler();
        var server = new ServerThread(scheduler);

        var cmd = new DummyLongCommand();
        server.EnqueueCommand(cmd);

        Thread.Sleep(1000);
        server.Stop();

        Assert.True(cmd.IsCompleted);
    }
}