import { Component } from '@angular/core';
import { OpenJobs, OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-open-jobs',
  templateUrl: './open-jobs.component.html',
  styleUrls: ['./open-jobs.component.scss']
})
export class OpenJobsComponent extends DestroySubscriptionsComponent{

  openJobList : OpenJobs[] = [];

  constructor(public overviewService : OverviewService) {
    super();
    this.setNewSubscription = overviewService.openJobs.subscribe((openJobs) => {
      this.openJobList = openJobs
    })
    overviewService.loadOpenJobs()
  }
}
