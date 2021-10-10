import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Employee } from "../models/Employee";

@Injectable({
  providedIn: "root"
})
export class EmployeeService {
  constructor(private httpClient: HttpClient) { }

  add(employee): Observable<any> {
    return this.httpClient.post("Api/Employees/", employee);
  }

  getAll(): Observable<any> {
    return this.httpClient.get("Api/Employees");
  }

  get(id: number): Observable<any> {
    return this.httpClient.get("Api/Employees/" + id);
  }

  update(employee: Employee): Observable<any> {
    return this.httpClient.put("Api/Areas", employee);
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete("Api/Employees/" + id);
  }
}
