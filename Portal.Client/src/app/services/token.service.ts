import { Injectable } from '@angular/core';
import { JwtResponse } from '../models/JwtResponse.model';
import { LoginResponse } from '../models/LoginResponse.model';

const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenService {

  constructor() { }

  public getUser(): LoginResponse | null {
    let user = localStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }
    return null;
  }

  public saveUser(user: LoginResponse): void {
    localStorage.removeItem(USER_KEY);
    localStorage.setItem(USER_KEY, JSON.stringify(user));
  }

}
