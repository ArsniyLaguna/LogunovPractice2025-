using System;
using System.Threading;
namespace Server;

public class TestCommand : ICommand
{
    private readonly int id;
    private int counter = 0;

    public int Executions => counter;

    public TestCommand(int id)
    {
        this.id = id;
    }

    public void Execute()
    {
        Console.WriteLine($"Поток {id} вызов {++counter}");
    }
}