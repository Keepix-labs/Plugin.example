using System.Runtime.InteropServices.JavaScript;
using Keepix.PluginSystem;
using System.Reflection;
public partial class Plugin {
    
    [JSExport]
    public static async Task<string> Run(string jsonString) {
        return await KeepixPlugin.Run(jsonString, Assembly.GetExecutingAssembly().GetTypes());
    }
}