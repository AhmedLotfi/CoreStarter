"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Helper_1 = require("../Common/Helper");
var Authenticate = /** @class */ (function () {
    function Authenticate() {
    }
    Authenticate.prototype.login = function () {
        if (!this.validateLogin())
            return;
        var loginBody = { email: $('#email').val(), password: $('#password').val() };
        fetch(Helper_1.baseApiUrl + "/Account/Login", {
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
    Authenticate.prototype.register = function () {
        if (!this.validateRegister())
            return;
        var registerBody = {
            displayName: $('#displayName').val(),
            email: $('#email').val(),
            password: $('#password').val()
        };
        fetch(Helper_1.baseApiUrl + "/Account/Register", {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "POST",
            body: JSON.stringify(registerBody)
        })
            .then(function (response) {
            response.json().then(function (data) {
                if (data.token) {
                    toastr.success(data.message);
                    window.location.href = '/Authenticate/Login';
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
    Authenticate.prototype.validateRegister = function () {
        if (!this.validateLogin())
            return false;
        if (!$('#displayName').val()) {
            toastr.warning('Display Name field is required !');
            return false;
        }
        if (!$('#confirmPassword').val()) {
            toastr.warning('ConfirmPassword field is required !');
            return false;
        }
        if ($('#password').val() !== $('#confirmPassword').val()) {
            toastr.warning('Password not matched !');
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
$('#btnRegister').on('click', function () {
    authenticate.register();
});
//# sourceMappingURL=authenticate.js.map