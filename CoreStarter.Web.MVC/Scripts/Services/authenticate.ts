import { ILogin } from '../Models/login';

class Authenticate implements ILogin {

    email: string;
    password: string;

    constructor() {
        console.log('Authenticate triggered');

        this.email = $('#email').val() as string;
        this.password = $('#password').val() as string;
    }

    login(): void {

        const loginBody = { email: this.email, password: this.password };

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
                        toastr.success(data.message);
                    });
                }
            )
            .catch((error) => {
                toastr.error(error);
                console.log('Fetch Error :-S', error);
            });
    }
}

const authenticate = new Authenticate();

$('#btnLogin').on('click', () => {
    authenticate.login();
});