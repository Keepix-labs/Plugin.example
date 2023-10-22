import { assert, it } from './utils/utils';

/**
 * Test
 * @returns boolean success
 */
export const plugin = it('Plugin Test', async (exec) => {
    const resultPlugin = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "plugin"
    }))).jsonResult);

    console.log('plugin', resultPlugin);

    const resultPreInstall = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "pre-install",
        walletSecretKey: "abcd",
        walletAddress: "0x961a14bEaBd590229B1c68A21d7068c8233C8542"
    }))).jsonResult);

    console.log('pre-install', resultPreInstall);

    const resultInstall = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "install",
        walletSecretKey: "abcd",
        walletAddress: "0x961a14bEaBd590229B1c68A21d7068c8233C8542"
    }))).jsonResult);

    console.log('install', resultInstall);

    const resultStart = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "start"
    }))).jsonResult);

    console.log('start', resultStart);

    const resultStop = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "stop"
    }))).jsonResult);

    console.log('stop', resultStop);

    const resultStatus = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "status"
    }))).jsonResult);

    console.log('status', resultStatus);

    const resultPluginInformation = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "plugin-information"
    }))).jsonResult);

    console.log('plugin-information', resultPluginInformation);


    const resultUninstall = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "uninstall"
    }))).jsonResult);

    console.log('uninstall', resultUninstall);
    
    return assert(true);
});