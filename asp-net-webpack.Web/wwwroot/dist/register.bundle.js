/******/ (() => { // webpackBootstrap
var __webpack_exports__ = {};
/*!********************************************!*\
  !*** ./Pages/Account/Register/register.js ***!
  \********************************************/
new Vue({
    el: "#app",
    data: function () {
        return {
            Email: "",
            PhoneNumber: "",
            FirstName: "",
            LastName: "",
            Password: "",
            Password2: "",
        }
    },
    methods: {
        register: function () {
            return this.$apiService.Post("account/register", this.$data)
                .then(() => window.location.href = window.location.origin)
        }
    },
    computed: {


    },
    mounted: function () {

    },
});


/******/ })()
;
//# sourceMappingURL=register.bundle.js.map