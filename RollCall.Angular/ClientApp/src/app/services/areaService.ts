import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Area } from '../models/Area';

@Injectable({
  providedIn: 'root'
})
export class AreaService {

  constructor(private httpClient: HttpClient) {

  }

  add(area): Observable<any> {
    return this.httpClient.post("Api/Areas/", area);
  }

  getAll(): Observable<any> {
    return this.httpClient.get("Api/areas");
  }

  get(id: number): Observable<any> {
    return this.httpClient.get("Api/Areas/" + id);
  }

  update(area: Area): Observable<any> {
    return this.httpClient.put("Api/Areas", area);
  }

  delete(id: number): Observable<any> {
    return this.httpClient.delete("Api/Areas/" + id);
  }
}
