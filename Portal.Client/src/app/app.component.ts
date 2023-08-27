import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { DepartmentService } from './services/department.service';
import { Department } from './models/Department';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  
  title = 'portalweb.client';
  public departments?: Department[];

  constructor(departmentServ : DepartmentService) {
    departmentServ.getAll().subscribe(result => {
      this.departments = result;
    }, error => console.error(error));
  }

}
