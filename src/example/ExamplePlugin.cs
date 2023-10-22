using Nethereum.Web3;
using Keepix.PluginSystem;

public static class ExamplePlugin {

    public static string jsonDataPath = "./db.json";

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
    public static async Task<bool> OnPreInstallFunc() {
        return true;
    }

    [KeepixPluginFn("install")]
    public static async Task<bool> OnInstallFunc(InstallInput input) {
        await File.WriteAllTextAsync(jsonDataPath, input.walletAddress);
        return true;
    }

    [KeepixPluginFn("uninstall")]
    public static async Task<bool> OnUninstallFunc() {
        File.Delete(jsonDataPath);
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

        if (File.Exists(jsonDataPath)) {
            return new KeepixPluginStatus {
                status = KeepixPluginStatusEnum.Stopped,
                description = "Ready and Stopped"
            };
        }
        return new KeepixPluginStatus {
            status = KeepixPluginStatusEnum.None,
            description = "Not Installed"
        };
    }

    [KeepixPluginFn("plugin-information")]
    public static async Task<KeepixPluginInformation> OnPluginInformationFunc() {
        string dataText = File.ReadAllText(jsonDataPath);

        var web3 = new Web3("http://51.255.75.224:8545");
        var balance = await web3.Eth.GetBalance.SendRequestAsync(dataText);
        var etherAmount = Web3.Convert.FromWei(balance.Value);

        return new KeepixPluginInformation {
            EthBalance = etherAmount.ToString(),
            pluginStatus = await OnStatusFunc()
        };
    }

}