import * as tests from './tests/index';

(async () => {

    let i = 1;
    for (let key of Object.keys(tests)) {
        const testResult = await tests[key]();

        if (testResult) {
            console.log(`(${i}:${key}) Test Success.`);
        } else {
            console.log(`(${i}:${key}) Test Failed.`);
        }
        i++;
    }
})();