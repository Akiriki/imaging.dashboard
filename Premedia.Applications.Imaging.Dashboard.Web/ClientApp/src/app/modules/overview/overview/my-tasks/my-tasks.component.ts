import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';
import { JobReadModel } from 'src/app/core/NSwagDataClient';
import { StatusService } from 'src/app/services/status.service';

@Component({
  selector: 'app-my-tasks',
  templateUrl: './my-tasks.component.html',
  styleUrls: ['./my-tasks.component.scss']
})
export class MyTasksComponent extends DestroySubscriptionsComponent{

  myTasksList : JobReadModel[] = [];
  pageSettings: PageSettingsModel;

  constructor(public overviewService : OverviewService, private router : Router, public statusService : StatusService) {
    super();

    this.setNewSubscription = overviewService.myTasks.subscribe((myTasks) => {
      this.myTasksList = myTasks.slice();
      this.myTasksList.sort((a, b) => {
        const titleA = a.title?.toUpperCase() || '';
        const titleB = b.title?.toUpperCase() || '';
        return titleA.localeCompare(titleB);
      });
    })

    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}
  }

  navigateToJobDetails(event: any) {
    const selectedJobNumber = parseInt(event.target.innerText, 10);
    console.log('Selected Job Number:', selectedJobNumber);

    const selectedJob = this.myTasksList.find(task => task.consecutiveNumber === selectedJobNumber);

    if (selectedJob) {
      console.log('Selected Job:', selectedJob);
      this.router.navigate(['/job-details'], {queryParams : {id : selectedJob.id}});
    } else {
      console.log('Selected Job not found');
    }
  }
}
