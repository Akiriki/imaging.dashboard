import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {FetchDataService} from '../../../services/fetch-data.service';
import {DestroySubscriptionsComponent} from '../../../shared/destroy-subscriptions/destroy-subscriptions.component';
import {WeatherForecast} from '../../../core/NSwagDataClient';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent extends DestroySubscriptionsComponent {
  public forecasts: WeatherForecast[] = [];

  constructor(private fetachDataService: FetchDataService) {
    super();
    // Mit der Subscription wird sichergestellt, dass die Daten für die View immer aktualisiert werden, wenn sie aus dem Backend geladen werden.
    this.setNewSubscription = this.fetachDataService.weatherForecasts.subscribe(result => {
      this.forecasts = result;
    });
    // Das Initiale Laden der Daten wird hier über den Service angestoßen.
    this.fetachDataService.loadWeatherForecasts();
  }
}
