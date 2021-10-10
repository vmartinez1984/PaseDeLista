import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { Schedule } from "../models/Schedule";

@Injectable({
  providedIn: "root"
})
export class ScheduleService {
  constructor(private httpClient: HttpClient) { }

  add(schedule): Observable<any> {
    return this.httpClient.post("Api/Schedules/", schedule);
  }

  getAll(): Observable<any> {
    return this.httpClient.get("Api/Schedules");
  }

  get(id: number): Observable<any> {
    return this.httpClient.get("Api/Schedules/" + id);
  }

  update(schedule: Schedule): Observable<any> {
    return this.httpClient.put("Api/Schedules", schedule);
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete("Api/Schedules/" + id);
  }
}
