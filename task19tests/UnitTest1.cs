using Xunit;
using Server;
using System.Threading;

namespace task19tests;

public class ServerThreadTests
{
    [Fact]
    public void Test_LongRunningCommands_ExecuteMultipleTimes_ThenStop()
    {
        var scheduler = new RoundRobinScheduler();
        var server = new ServerThread(scheduler);

        var commands = new TestCommand[5];
        for (int i = 0; i < 5; i++)
        {
            commands[i] = new TestCommand(i + 1);
            server.AddCommand(commands[i]);
        }
        var maxWaitTime = 2000;
        var sw = System.Diagnostics.Stopwatch.StartNew();
        while (commands.Any(c => c.Executions < 3) && sw.ElapsedMilliseconds < maxWaitTime)
        {
            Thread.Sleep(20);
        }

        server.AddCommand(new HardStopCommand(server));
        server.Join();

        Assert.All(commands, c => Assert.True(c.Executions >= 3));
    }
}