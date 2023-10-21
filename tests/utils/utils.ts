import { exec } from 'child_process';
import * as fs from 'fs';

export const assert = (value, message = "") => {
    return { result: value, message: message };
};

export const it = (name, cb) => {

    const os = process.platform.replace("darwin", "osx");
    const arch = process.arch;

    return {
        name: name,
        test: async () => {
            return await cb(async (arg) => {
                return await new Promise((resolve, reject) => {
                    if (!fs.existsSync(`./dist/${os}-${arch}`)) {
                        throw new Error(`./dist/${os}-${arch} not found.`);
                    }
                    const proj = fs.readdirSync("./").find(x => x.endsWith(".csproj"));

                    if (proj == undefined) {
                        throw new Error(`csproj not found.`);
                    }
                    exec(`./dist/${os}-${arch}/${proj.replace(".csproj", "")} '${arg}'`, (error, stdout, stderr) => {
                        resolve(stdout? stdout : stderr);
                    });
                });
            });
        }
    };
};