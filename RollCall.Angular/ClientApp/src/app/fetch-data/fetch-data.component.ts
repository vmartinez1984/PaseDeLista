import { Component, Inject } from '@angular/core';
import { WeatherForecast } from '../models/WeatherForecast';
import { fetchDataService } from '../services/fetchDataService';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[];

  constructor(service: fetchDataService) {
    service.getAll().subscribe(data => {
      this.forecasts = data;
    }, error => {
      console.error(error)
    });
  }
}
