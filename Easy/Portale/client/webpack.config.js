const path = require('path');
const TerserPlugin = require("terser-webpack-plugin");

getVer = function() {
    var d= new Date();
	var month = String(d.getMonth() + 1);
	var day = String(d.getDate());
	var year = String(d.getFullYear());
	return year + '_' + month + '_' + day;
};

module.exports = (env) => {
    console.log(env.appName);

    return {
        entry: './webpack/index' + env.appName + '.js',
        output: {
            path: path.resolve(__dirname, 'dist'),
            filename: 'mdlw_bundle_' + env.appName + '_' +  getVer() + '.js'
        },
        resolve: {
            modules: ['bower_components', 'node_modules'],
            descriptionFiles: ['bower.json', 'package.json'],
            extensions: ['.js', '.json', '.html']
        },
        //mode: 'development',
        //plugins: [
        //    new UglifyJSPlugin({sourceMap: true})
        //]
        optimization: {
            flagIncludedChunks: false,
            removeEmptyChunks: false,
            mergeDuplicateChunks: false,
            usedExports: false,
            innerGraph: false,
            minimize: false,
            sideEffects: false,
            minimizer: [
                new TerserPlugin({
                    minify: TerserPlugin.uglifyJsMinify,
                    // `terserOptions` options will be passed to `uglify-js`
                    // Link to options - https://github.com/mishoo/UglifyJS#minify-options
                    terserOptions: {
                        sourceMap: true,
                        dead_code: false
                    },
                }),
            ],
        }
    }
};