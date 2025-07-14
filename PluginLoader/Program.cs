using PluginContracts;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

string pluginPath = args.Length > 0 ? args[0] : "./plugins";

if (!Directory.Exists(pluginPath))
{
    Console.WriteLine($"Папка с плагинами не найдена: {pluginPath}");
    return;
}

var dlls = Directory.GetFiles(pluginPath, "*.dll");
var pluginTypes = new Dictionary<string, (Type type, PluginLoadAttribute attr)>();

foreach (var dll in dlls)
{
    var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(Path.GetFullPath(dll));

    foreach (var type in assembly.GetTypes())
    {
        if (typeof(IPlugin).IsAssignableFrom(type) && type.GetCustomAttribute<PluginLoadAttribute>() is { } attr)
        {
            pluginTypes[type.FullName!] = (type, attr);
        }
    }
}

foreach (var (type, _) in pluginTypes.Values)
{
    if (Activator.CreateInstance(type) is IPlugin plugin)
    {
        plugin.Execute();
    }
}