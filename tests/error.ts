import { assert, it } from './utils/utils';

/**
 * Test
 * @returns boolean success
 */
export const t = it("Error", async (exec) => {
    const dto = JSON.stringify({});
    const result = JSON.parse(JSON.parse(await exec(dto)).jsonResult);
    
    return assert(result == undefined);
});