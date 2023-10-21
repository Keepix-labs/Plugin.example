using Nethereum.Web3;
using Keepix.PluginSystem;

public class ExamplePlugin {

    public static string jsonDataPath = Path.Combine(Environment.GetEnvironmentVariable("PWD"), "./data.json");

    [KeepixPluginFn("plugin")]
    public static async Task<PluginBaseInformation> OnPluginFunc() {
        return new PluginBaseInformation {
            id = "example",
            name = "Example Plugin",
            description = "Test description",
            version = "v0.0.3"
         };
    }

    [KeepixPluginFn("pre-install")]
    public static async Task<bool> OnPreInstallFunc(InstallInput input) {
        await File.WriteAllTextAsync("./data.json", input.walletAddress);
        return true;
    }

    [KeepixPluginFn("install")]
    public static async Task<bool> OnInstallFunc() {
        Console.WriteLine(Directory.GetCurrentDirectory());
        Console.WriteLine(Thread.GetDomain().BaseDirectory);

        Console.WriteLine(Environment.GetEnvironmentVariable("PWD"));
        return true;
    }

    [KeepixPluginFn("uninstall")]
    public static async Task<bool> OnUninstallFunc() {
        return true;
    }

    [KeepixPluginFn("start")]
    public static async Task<bool> OnStartFunc() {
        return true;
    }

    [KeepixPluginFn("stop")]
    public static async Task<bool> OnStopFunc() {
        return true;
    }

    [KeepixPluginFn("status")]
    public static async Task<KeepixPluginStatus> OnStatusFunc() {
        return new KeepixPluginStatus {
            status = KeepixPluginStatusEnum.None,
            description = "Not Installed"
        };
    }

    [KeepixPluginFn("plugin-information")]
    public static async Task<KeepixPluginInformation> OnPluginInformationFunc() {
        string dataText = File.ReadAllText("./data.json");

        var web3 = new Web3("http://51.255.75.224:8545");
        var balance = await web3.Eth.GetBalance.SendRequestAsync(dataText);
        var etherAmount = Web3.Convert.FromWei(balance.Value);

        return new KeepixPluginInformation {
            EthBalance = etherAmount.ToString(),
            pluginStatus = await OnStatusFunc()
        };
    }

}