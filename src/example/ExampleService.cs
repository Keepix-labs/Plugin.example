using Nethereum.Web3;

public class ExampleService {

    [PluginFn("example", InputType = typeof(ExampleInput))]
    public static async Task<ExampleOutput> ExampleFunc(ExampleInput input) {

        var web3 = new Web3(input.url);
        Console.WriteLine("MSMSMSMS");
        Task.Delay(5000).Wait();

        var balance = await web3.Eth.GetBalance.SendRequestAsync("0x961a14bEaBd590229B1c68A21d7068c8233C8542");
        var etherAmount = Web3.Convert.FromWei(balance.Value);
        // return etherAmount.ToString();
        return new ExampleOutput { result = etherAmount.ToString() };
    }

}