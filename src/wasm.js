// Set up the .NET WebAssembly runtime
import { dotnet } from './dotnet.js';

export const wasm = async () => {
    // Get exported methods from the .NET assembly
    const { getAssemblyExports, getConfig } = await dotnet
        .withDiagnosticTracing(false)
        .withApplicationArguments()
        .create();
    const config = getConfig();

    /// dotnet.moduleConfig.config.debugLevel = 0;

    return await getAssemblyExports(config.mainAssemblyName);
};