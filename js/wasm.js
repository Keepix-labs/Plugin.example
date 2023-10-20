// Set up the .NET WebAssembly runtime
import { dotnet } from './dotnet.js';

export const wasm = async (run = false) => {
    // Get exported methods from the .NET assembly
    const { runMain, getAssemblyExports, getConfig } = await dotnet
        .withDiagnosticTracing(false)
        .withApplicationArguments()
        .create();
    const config = getConfig();

    if (run) {
        return await runMain(config.mainAssemblyName, []);
    }
    /// dotnet.moduleConfig.config.debugLevel = 0;
    return await getAssemblyExports(config.mainAssemblyName);
};