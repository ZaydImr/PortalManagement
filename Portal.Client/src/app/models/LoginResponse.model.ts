import { User } from "./User.model";

export class LoginResponse {
    public user: User;
    public token: string;

    constructor(user: User, token: string) {
        this.user = user;
        this.token = token;
    }
}