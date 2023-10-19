using System.Runtime.InteropServices.JavaScript;
using System;
using Nethereum.Web3;
using System.Threading.Tasks;
using System.Text.Json;

public class ExampleInput
{
        public string[]? data { get; set; }
        public string? url { get; set; }
}

public partial class Plugin
{
    [JSExport]
    public static string TestSync(string jsonString)
    {
        ExampleInput? dto = JsonSerializer.Deserialize<ExampleInput>(jsonString);

        if (dto == null) {
            return "";
        }
        return JsonSerializer.Serialize<ExampleInput>(dto);
    }

    [JSExport]
    public static async Task<string> TestAsync(string jsonString)
    {
        ExampleInput? dto = JsonSerializer.Deserialize<ExampleInput>(jsonString);

        var web3 = new Web3(dto?.url);
        var balance = await web3.Eth.GetBalance.SendRequestAsync("0x961a14bEaBd590229B1c68A21d7068c8233C8542");
        var etherAmount = Web3.Convert.FromWei(balance.Value);
        return etherAmount.ToString();
    }
}

namespace PluginWasm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
        }
    }
}