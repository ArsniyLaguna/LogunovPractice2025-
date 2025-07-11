using System.Reflection;
using CommandLib;

string pluginPath = Path.Combine(Directory.GetCurrentDirectory(), "FileSystemCommands.dll");

if (!File.Exists(pluginPath))
{
    Console.WriteLine("DLL not found.");
    return;
}

Assembly pluginAssembly = Assembly.LoadFrom(pluginPath);

foreach (Type type in pluginAssembly.GetTypes())
{
    if (typeof(ICommand).IsAssignableFrom(type) && !type.IsInterface)
    {
        var constructor = type.GetConstructors().FirstOrDefault();

        object? instance = null;

        if (type.Name == "DirectorySizeCommand")
        {
            instance = constructor?.Invoke(new object[] { "." });
        }
        else if (type.Name == "FindFilesCommand")
        {
            instance = constructor?.Invoke(new object[] { ".", "*.cs" });
        }

        if (instance is ICommand command)
        {
            Console.WriteLine($"Executing {type.Name}:");
            command.Execute();
            Console.WriteLine();
        }
    }
}
