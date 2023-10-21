import { assert, it } from './utils/utils';

/**
 * Test
 * @returns boolean success
 */
export const exportedFunctions = it('Exported Functions', async (exec) => {
    const resultPlugin = JSON.parse(JSON.parse(await exec(JSON.stringify({
        key: "exposed-functions"
    }))).jsonResult);

    console.log('exposed-functions', resultPlugin);
    
    return assert(true);
});