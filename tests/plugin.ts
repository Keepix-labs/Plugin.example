import { wasm } from '../dist/wasm';
import { assert, it } from './utils/utils';

/**
 * Test
 * @returns boolean success
 */
export const plugin = it('Plugin Test', async () => {
    const exports = await wasm();

    console.log('Test Result:', await exports.Plugin.Run(JSON.stringify({
        key: "example",
        url: "http://51.255.75.224:8545"
    })));

    console.log('Test Result:', await exports.Plugin.Run(JSON.stringify({
        key: "example2"
    })));

    console.log('Test Result:', await exports.Plugin.Run(JSON.stringify({
        
    })));
    
    return assert(true);
});