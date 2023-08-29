import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { DepartmentService } from './services/department.service';
import { Department } from './models/Department.model';
import { AuthService } from './services/auth.service';
import { LoginRequest } from './models/LoginRequest.model';
import { TokenService } from './services/token.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  
  title = 'portalweb.client';

  constructor(authServcie : AuthService, tokenService: TokenService) {
    authServcie.login(new LoginRequest('string', 'String@123')).subscribe(result => {
      tokenService.saveUser(result);
      
    }, error => console.error(error));
  }

}
