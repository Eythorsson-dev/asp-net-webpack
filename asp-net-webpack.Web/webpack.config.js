const path = require('path');

var environment = process.env.NODE_ENV || 'development';
module.exports = {
    mode: environment,
    watch: environment !== 'production',
    devtool: 'source-map',
    resolve: {
        alias: {
            vue: 'vue/dist/vue.js',
            components: path.resolve(__dirname, "wwwroot/js/components/"),
            directives: path.resolve(__dirname, "wwwroot/js/directives/"),
            handlers: path.resolve(__dirname, "wwwroot/js/handlers/"),
            services: path.resolve(__dirname, "wwwroot/js/services/"),
        },
    },
    entry: {
        site: './wwwroot/js/site.js',
        master: './wwwroot/js/master.js',

        login: './Pages/Account/Login/login.js',
        register: './Pages/Account/Register/register.js',
        passwordReset: './Pages/Account/PasswordReset/passwordReset.js',
        accountVerify: './Pages/Account/AccountVerify/accountVerify.js',

        dashboard: './Pages/Dashboard/dashboard.js',
        order: './Pages/Order/order.js',
    },
    output: {
        filename: '[name].bundle.js',
        path: path.resolve(__dirname, 'wwwroot/dist'),
    },
};