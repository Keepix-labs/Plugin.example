using System.Runtime.InteropServices.JavaScript;
using Keepix.PluginSystem;
using System.Reflection;
public partial class Plugin {
    
    [JSExport]
    public static async Task<string> Run(string jsonString) {
        try {
            return await KeepixPlugin.Run(jsonString, Assembly.GetExecutingAssembly().GetTypes());
        } catch(Exception e) {
            Console.WriteLine(e.Message);
            return "null"; // return undefined object
        }
    }
}