import * as tests from './tests/index';

(async () => {

    console.log(`Starting Tests - CurrentPlatform (${process.platform.replace("darwin", "osx")}-${process.arch})`);

    let i = 1;
    for (let key of Object.keys(tests)) {
        const test = tests[key];
        console.log(`\n(${test.name}) ->`);
        const testResult = await test.test();

        if (testResult.result) {
            console.log(`(${test.name}) Test Success.`);
        } else {
            console.log(`(${test.name}) Test Failed. ${testResult.message}`);
        }
        i++;
    }
})();