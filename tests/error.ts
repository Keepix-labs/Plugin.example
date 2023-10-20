import { wasm } from '../dist/wasm';
import { assert, it } from './utils/utils';

/**
 * Test
 * @returns boolean success
 */
export const t = it("Error", async () => {
    const exports = await wasm();
    const dto = JSON.stringify({});
    const result = await exports.Plugin.Run(dto);
    
    return assert(result == undefined);
});