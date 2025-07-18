namespace Server;

public class HardStopCommand : ICommand
{
    private readonly ServerThread serverThread;

    public HardStopCommand(ServerThread serverThread)
    {
        this.serverThread = serverThread;
    }

    public void Execute()
    {
        serverThread.RequestHardStop();
    }
}