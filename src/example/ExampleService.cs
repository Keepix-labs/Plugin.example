using Nethereum.Web3;
using Keepix.PluginSystem;

public class ExampleService {

    [KeepixPluginFn("example")]
    public static async Task<ExampleOutput> ExampleFunc(ExampleInput input) {

        var web3 = new Web3(input.url);
        Console.WriteLine("MSMSMSMS");
        var balance = await web3.Eth.GetBalance.SendRequestAsync("0x961a14bEaBd590229B1c68A21d7068c8233C8542");
        var etherAmount = Web3.Convert.FromWei(balance.Value);
        // return etherAmount.ToString();
        return new ExampleOutput { result = etherAmount.ToString() };
    }

    [KeepixPluginFn("example2")]
    public static async Task<string> ExampleFunc2() {

        var web3 = new Web3("http://51.255.75.224:8545");
        Console.WriteLine("MSMSMSMS2");
        var balance = await web3.Eth.GetBalance.SendRequestAsync("0x961a14bEaBd590229B1c68A21d7068c8233C8542");
        var etherAmount = Web3.Convert.FromWei(balance.Value);
        // return etherAmount.ToString();
        return etherAmount.ToString();
    }

}