"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Authenticate = /** @class */ (function () {
    function Authenticate() {
    }
    Authenticate.prototype.login = function () {
        if (!this.validateLogin())
            return;
        var loginBody = { email: $('#email').val(), password: $('#password').val() };
        fetch('http://localhost:54608/api/Account/login', {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify(loginBody)
        })
            .then(function (response) {
            response.json().then(function (data) {
                if (data.token) {
                    toastr.success(data.message);
                    window.location.href = '/Home';
                }
                else {
                    toastr.error(data.message);
                }
            });
        })
            .catch(function (error) {
            toastr.error(error);
            console.log('Fetch Error :-S', error);
        });
    };
    Authenticate.prototype.validateLogin = function () {
        if (!$('#email').val()) {
            toastr.warning('Email field is required !');
            return false;
        }
        if (!$('#password').val()) {
            toastr.warning('Password field is required !');
            return false;
        }
        return true;
    };
    return Authenticate;
}());
var authenticate = new Authenticate();
$('#btnLogin').on('click', function () {
    authenticate.login();
});
//# sourceMappingURL=authenticate.js.map