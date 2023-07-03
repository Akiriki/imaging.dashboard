import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import {BehaviorSubject} from 'rxjs';

// Die Services kapseln die Kommunikation mit dem Backend, nur von hier aus wird der DataClient (NSwag) aufgerufen!
@Injectable()
export class FetchDataService {
  weatherForecasts = new BehaviorSubject<DataClient.WeatherForecast[]>([]);

  constructor(private dataClient: DataClient.WeatherForecastClient) {
  }

  //Hier werden die Daten aus dem Backend geladen
  loadWeatherForecasts() {
    this.dataClient.get().subscribe(result => {
      this.weatherForecasts.next(result);
    }, error => console.error(error));
  }
}
