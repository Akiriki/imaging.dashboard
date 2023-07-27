import { Component } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';
import { JobReadModel } from 'src/app/core/NSwagDataClient';

@Component({
  selector: 'app-open-jobs',
  templateUrl: './open-jobs.component.html',
  styleUrls: ['./open-jobs.component.scss']
})
export class OpenJobsComponent extends DestroySubscriptionsComponent{

  openJobList : JobReadModel[] = [];
  pageSettings: PageSettingsModel;

  constructor(public overviewService : OverviewService) {
    super();
    this.setNewSubscription = overviewService.openJobs.subscribe((openJobs) => {
      this.openJobList = openJobs.slice();
      this.openJobList.sort((a, b) => {
        const titleA = a.title?.toUpperCase() || '';
        const titleB = b.title?.toUpperCase() || '';
        return titleA.localeCompare(titleB);
      });
    });

    this.pageSettings = {pageSize : overviewService.pageSettings.pageSize}
  }
}
