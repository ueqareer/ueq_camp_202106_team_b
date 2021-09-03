const path = require("path");

const vueSrc = "./src";

module.exports = {
    runtimeCompiler: true,
    configureWebpack: {
        resolve: {
            alias: {
                "@": path.join(__dirname, vueSrc)
            }
        }
    }
}