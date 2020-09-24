import { ILogin } from '../Models/login';

class Authenticate implements ILogin {

    email: string;
    password: string;

    constructor() { }

    login(): void {

        if (!this.validateLogin()) return;

        const loginBody = { email: $('#email').val() as string, password: $('#password').val() as string };

        fetch('http://localhost:54608/api/Account/login',
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
}

const authenticate = new Authenticate();

$('#btnLogin').on('click', () => {
    authenticate.login();
});