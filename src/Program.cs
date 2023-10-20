
namespace PluginProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Keepix Plugin");
            var task = Plugin.Run("{ \"key\": \"HelloWorld\" }");
            task.Wait();
            Console.WriteLine(task.Result);
        }
    }
}