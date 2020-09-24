"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Authenticate = /** @class */ (function () {
    function Authenticate() {
        console.log('Authenticate triggered');
        this.email = $('#email').val();
        this.password = $('#password').val();
    }
    Authenticate.prototype.login = function () {
        var loginBody = { email: this.email, password: this.password };
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
                toastr.success(data.message);
            });
        })
            .catch(function (error) {
            toastr.error(error);
            console.log('Fetch Error :-S', error);
        });
    };
    return Authenticate;
}());
var authenticate = new Authenticate();
$('#btnLogin').on('click', function () {
    authenticate.login();
});
//# sourceMappingURL=authenticate.js.map