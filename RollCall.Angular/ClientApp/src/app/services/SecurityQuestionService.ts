import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { SecurityQuestion } from "../models/SecurtyQuestion";

@Injectable({
  providedIn: "root"
}) export class SecurityQuestionService {
  constructor(private httpClient: HttpClient) { }

  add(item): Observable<any> {
    return this.httpClient.post("Api/SecurityQuestions", item);
  }

  getAll(employeeId: number): Observable<any> {
    return this.httpClient.get("Api/SecurityQuestions/Employee/" + employeeId);
  }

  get(securityQuestionId: number) {
    return this.httpClient.get("Api/SecurityQuestions/" + securityQuestionId)
  }

  update(item: SecurityQuestion): Observable<any> {
    return this.httpClient.put("Api/SecurityQuestions", item);
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete("Api/SecurityQuestions/" + id);
  }
}
