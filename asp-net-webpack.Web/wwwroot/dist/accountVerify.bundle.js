/******/ (() => { // webpackBootstrap
var __webpack_exports__ = {};
/*!******************************************************!*\
  !*** ./Pages/Account/AccountVerify/accountVerify.js ***!
  \******************************************************/
new Vue({
    el: "#app",
    data: function () {
        return {
            Code: "",
        }
    },
    methods: {
        resendVerifyEmail: function (email) {
            return this.$apiService.Post("account/resendAccountVerify", { Email: email })
        },
        verifyEmail: function () {
            return this.$apiService.Post("account/accountVerify", { Email: this.Email, Code: this.Code })
                .then(() => window.location.href = window.location.origin);
        },
        logout: function () {
            return this.$apiService.Post("account/logout")
                .then(() => window.location.href = window.location.origin);
        }
    },
    mounted: function () {
        const urlParams = new URLSearchParams(window.location.search);
        this.Code = urlParams.get('code');
        this.Email = urlParams.get('email');

        if (this.Code) {
            this.verifyEmail();
        }
    }
});


/******/ })()
;
//# sourceMappingURL=accountVerify.bundle.js.map