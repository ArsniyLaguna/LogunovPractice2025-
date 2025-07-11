using CommandLib;

namespace FileSystemCommands;

public class DirectorySizeCommand : ICommand
{
    private readonly string _path;

    public DirectorySizeCommand(string path)
    {
        _path = path;
    }

    public void Execute()
    {
        if (!Directory.Exists(_path))
        {
            Console.WriteLine($"Directory not found: {_path}");
            return;
        }

        long totalSize = Directory.GetFiles(_path, "*", SearchOption.AllDirectories)
                                  .Sum(file => new FileInfo(file).Length);

        Console.WriteLine($"Directory size of {_path}: {totalSize} bytes");
    }
}
