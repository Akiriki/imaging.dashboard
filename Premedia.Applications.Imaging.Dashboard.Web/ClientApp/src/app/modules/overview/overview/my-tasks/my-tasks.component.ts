import { Component } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { MyTasks, OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-my-tasks',
  templateUrl: './my-tasks.component.html',
  styleUrls: ['./my-tasks.component.scss']
})
export class MyTasksComponent extends DestroySubscriptionsComponent{

  myTasksList : MyTasks[] = [];
  pageSettings: PageSettingsModel;

  constructor(public overviewService : OverviewService) {
    super();
    overviewService.myTasks.subscribe((myTasks) => {
      this.myTasksList = myTasks
    })
    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}
    overviewService.loadMyTasks();
  }
}
