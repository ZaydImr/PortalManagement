import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { LoginRequest } from '../models/LoginRequest.model';
import { LoginResponse } from '../models/LoginResponse.model';
import { Registration } from '../models/Registration.model';
import { User } from '../models/User.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private prefix = '/api/Auth/';

  constructor(private http: HttpClient) { }

  public login(user : LoginRequest) : Observable<LoginResponse> {
    return this.http.post<LoginResponse>(`${this.prefix}login`, user);
  } 

  public register(user : Registration) : Observable<User> {
    return this.http.post<User>(`${this.prefix}register`, user);
  }

}
