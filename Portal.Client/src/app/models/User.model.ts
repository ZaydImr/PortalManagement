import { Role } from "./Role.enum.model";

export class User {
    public id: string;
    public userName: string;
    public email: string;
    public name: string;
    public phoneNumber: string;
    public roles: Role[];

    constructor(
        id: string, userName: string, email: string, 
        name: string, phoneNumber: string, roles: Role[]) {
        this.id = id;
        this.userName = userName;
        this.email = email;
        this.name = name;
        this.phoneNumber = phoneNumber;
        this.roles = roles;
    }
}