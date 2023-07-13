import { Component } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { Activities, AdministrationService } from 'src/app/services/administration.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.scss']
})
export class ActivitiesComponent extends DestroySubscriptionsComponent{
  activitiesList : Activities[] = [];
  pageSettings: PageSettingsModel;

  constructor(public administrationService : AdministrationService) {
    super();
    this.setNewSubscription = administrationService.activitiesContent.subscribe((activitiesContent) => {
      this.activitiesList = activitiesContent
    })
    this.pageSettings = {pageSize : administrationService.pageSettings.pageSize}
    administrationService.loadActivities();
  }
}
