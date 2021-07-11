import { Modal } from 'bootstrap';

new Vue({
    el: "#app",
    data: function () {
        return {
            resetPasswordModal: null,

            request: {
                Email: "",
                Password: "",
                RememberMe: false,
            },
            resetRequest: {
                _isLoading: false,
            }
        }
    },
    methods: {
        login: function () {
            return this.$apiService.Post("account/login", this.request)
                .then(() => window.location.href = window.location.origin)
        },
        resetPassword: function () {
            if (this.resetPassword._isLoading) return;
            this.resetPassword._isLoading = true;

            return this.$apiService.Post("account/passwordForgot", { Email: this.resetRequest.Email })
                .then(() => this.resetPasswordModal.hide())
                .finally(() => this.resetPassword._isLoading = false);
        },

        showResetPasswordModal: function () {
            this.$set(this.resetRequest, "Email", this.request.Email);
            this.resetPasswordModal.show();
        }
    },
    mounted: function () {
        this.resetPasswordModal = new Modal(this.$refs.passwordResetModal);
    }
});
