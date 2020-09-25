export interface IRegister {

    displayName: string;
    email: string;
    password: string;

    register(): void;
}