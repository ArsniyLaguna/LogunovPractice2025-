using Xunit;
using FileSystemCommands;

public class FileSystemCommandsTests
{
    [Fact]
    public void DirectorySizeCommand_ShouldCalculateSize()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDirSize");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "123");
        File.WriteAllText(Path.Combine(testDir, "file2.txt"), "45678");

        var command = new DirectorySizeCommand(testDir);
        command.Execute(); // Проверка на исключения

        Directory.Delete(testDir, true);
    }

    [Fact]
    public void FindFilesCommand_ShouldFindMatchingFiles()
    {
        var testDir = Path.Combine(Path.GetTempPath(), "TestDirFind");
        Directory.CreateDirectory(testDir);
        File.WriteAllText(Path.Combine(testDir, "file1.txt"), "123");
        File.WriteAllText(Path.Combine(testDir, "file2.log"), "log");

        var command = new FindFilesCommand(testDir, "*.txt");
        command.Execute(); // Проверка на исключения

        Directory.Delete(testDir, true);
    }
}