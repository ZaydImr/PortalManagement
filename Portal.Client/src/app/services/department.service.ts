import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Department } from '../models/Department.model';

@Injectable({
  providedIn: 'root'
})
export class DepartmentService {

  private prefix = '/api/Department';

  constructor(private http: HttpClient) { }

  public getAll() : Observable<Department[]>{
    return this.http.get<Department[]>(this.prefix);
  }

  public getById(id: number) : Observable<Department>{
    return this.http.get<Department>(`${this.prefix}/${id}`);
  }

  public add(department: Department) : Observable<Department>{
    return this.http.post<Department>(this.prefix, department);
  }

  public update(department: Department) : Observable<Department>{
    return this.http.put<Department>(this.prefix, department);
  }

  public delete(id: number) : Observable<string>{
    return this.http.delete<string>(`${this.prefix}/${id}`);
  }

}
