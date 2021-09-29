import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WeatherForecast } from '../models/WeatherForecast';

@Injectable({
  providedIn: 'root'
})
export class fetchDataService {

  constructor(private clienteHttp: HttpClient) { }

  getAll(): Observable<any> {
    return this.clienteHttp.get('weatherforecast');
  }
}
