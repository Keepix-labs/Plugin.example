
namespace PluginProgram
{
    public class Program
    {
        private class OutPutData {
            public string? jsonResult { get; set; }
            public string? stdOut { get; set; }
        }
        public static void Main(string[] args)
        {
            StringWriter wr = new StringWriter();
            TextWriter consoleOut = Console.Out;
            TextWriter consoleError = Console.Error;
            Console.SetOut(wr);
            Console.SetError(wr);
            Task<string> task = Plugin.Run(args.Count() > 0 ? args[0] : "");
            Console.SetOut(consoleOut);
            Console.SetError(consoleError);
            OutPutData result = new OutPutData { jsonResult = task.Result, stdOut = wr.ToString() };
            string resultString = System.Text.Json.JsonSerializer.Serialize(result);
            Console.WriteLine(resultString);
        }
    }
}