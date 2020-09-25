import { ILogin } from '../Models/login';
import { IRegister } from '../Models/register';
import { baseApiUrl } from '../Common/Helper';

class Authenticate implements ILogin, IRegister {

    constructor() { }

    displayName: string;
    email: string;
    password: string;

    login(): void {

        if (!this.validateLogin()) return;

        const loginBody = { email: $('#email').val() as string, password: $('#password').val() as string };

        fetch(`${baseApiUrl}/Account/Login`,
            {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: JSON.stringify(loginBody)
            }
        )
            .then(
                (response) => {

                    response.json().then(function (data) {

                        if (data.token) {

                            toastr.success(data.message);
                            window.location.href = '/Home';

                        } else {
                            toastr.error(data.message);
                        }

                    });
                }
            )
            .catch((error) => {
                toastr.error(error);
                console.log('Fetch Error :-S', error);
            });
    }

    register(): void {

        if (!this.validateRegister()) return;

        const registerBody = {
            displayName: $('#displayName').val() as string,
            email: $('#email').val() as string,
            password: $('#password').val() as string
        };

        fetch(`${baseApiUrl}/Account/Register`,
            {
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                method: "POST",
                body: JSON.stringify(registerBody)
            }
        )
            .then(
                (response) => {

                    response.json().then(function (data) {

                        if (data.token) {

                            toastr.success(data.message);
                            window.location.href = '/Authenticate/Login';

                        } else {
                            toastr.error(data.message);
                        }

                    });
                }
            )
            .catch((error) => {
                toastr.error(error);
                console.log('Fetch Error :-S', error);
            });
    }

    validateLogin(): boolean {

        if (!$('#email').val()) {
            toastr.warning('Email field is required !');
            return false;
        }

        if (!$('#password').val()) {
            toastr.warning('Password field is required !');
            return false;
        }

        return true;
    }

    validateRegister(): boolean {

        if (!this.validateLogin()) return false;

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
    }
}

const authenticate = new Authenticate();

$('#btnLogin').on('click', () => {
    authenticate.login();
});

$('#btnRegister').on('click', () => {
    authenticate.register();
});