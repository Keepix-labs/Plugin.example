export const assert = (value, message = "") => {
    return { result: value, message: message };
};

export const it = (name, cb) => {
    return {
        name: name,
        test: async () => {
            try {
                return await cb();
            } catch (error) {
                return { result: false, message: error.message }
            }
        }
    };
};