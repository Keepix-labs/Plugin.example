import { wasm } from '../bin/Debug/net7.0/browser-wasm/AppBundle/wasm';

/**
 * Test
 * @returns boolean success
 */
export const plugin = async () => {
    try {
        const exports = await wasm();

        console.log('Sync  Result:', exports.Plugin.TestSync(JSON.stringify({
            data: [
                "string1",
                "string2"
            ]
        })));
        console.log('Async Result:', await exports.Plugin.TestAsync(JSON.stringify({
            url: "https://bsc-dataseed1.ninicoin.io"
        })));
        return true;
    } catch (error) {
        console.error('Erreur :', error);
    }
    return false;
};