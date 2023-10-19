import { wasm } from '../bin/Debug/net7.0/browser-wasm/AppBundle/wasm';

/**
 * Test
 * @returns boolean success
 */
export const plugin = async () => {
    try {
        const exports = await wasm();

        // console.log('Sync  Result:', exports.Plugin.TestSync(JSON.stringify({
        //     data: [
        //         "string1",
        //         "string2"
        //     ]
        // })));
        // console.log('Test Result:', await exports.Plugin.Run(JSON.stringify({
        //     key: "example",
        //     url: "http://51.255.75.224:8545"
        // })));

        console.log('Test Async:', await exports.Plugin.TestAsync(JSON.stringify({
            url: "http://51.255.75.224:8545"
        })));
        return true;
    } catch (error) {
        console.error('Erreur :', error);
    }
    return false;
};