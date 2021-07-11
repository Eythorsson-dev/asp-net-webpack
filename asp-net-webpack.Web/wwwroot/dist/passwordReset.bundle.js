/******/ (() => { // webpackBootstrap
var __webpack_exports__ = {};
/*!******************************************************!*\
  !*** ./Pages/Account/PasswordReset/passwordReset.js ***!
  \******************************************************/
new Vue({
    el: "#app",
    data: function () {
        return {
            Code: "",
            Email: "",
            Password: "",
            Password2: "",
        }
    },
    methods: {
        resetPassword: function () {
            return this.$apiService.Post("account/passwordReset", this.$data)
                .then(() => window.location.href = window.location.origin)
        }
    },
    mounted: function () {
        const urlParams = new URLSearchParams(window.location.search);
        this.Code = urlParams.get('code');
        this.Email = urlParams.get('email');
    },
});



/******/ })()
;
//# sourceMappingURL=passwordReset.bundle.js.map