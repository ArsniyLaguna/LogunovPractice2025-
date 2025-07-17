using Xunit;
using task17;
using System.Threading;
using System;

namespace task17tests
{
    public class ServerThreadTests
    {
        [Fact]
        public void TestSoftStop()
        {
            var server = new ServerThread();
            server.Start();
            server.AddCommand(new SoftStopCommand(server));

            Thread.Sleep(1000);

            var thread = server.GetThread();
            Assert.True(thread == null || !thread.IsAlive);
        }

        [Fact]
        public void TestHardStop()
        {
            var server = new ServerThread();
            server.Start();
            server.AddCommand(new HardStopCommand(server));

            Thread.Sleep(1000);

            var thread = server.GetThread();
            Assert.True(thread == null || !thread.IsAlive);
        }

        [Fact]
        public void TestWrongThreadHardStop()
        {
            var server = new ServerThread();

            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                new HardStopCommand(server).Execute();
            });

            Assert.Equal("HardStop можно вызывать только в своём потоке", ex.Message);
        }
    }
}