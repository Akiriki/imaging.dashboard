import { Component } from '@angular/core';
import { Router } from '@angular/router';
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

  constructor(public overviewService : OverviewService, private router : Router) {
    super();
    overviewService.myTasks.subscribe((myTasks) => {
      this.myTasksList = myTasks
    })
    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}
    overviewService.loadMyTasks();
  }

  navigateToJobDetails(event: any) {
    const selectedJobNumber = event.target.innerText;
    const selectedJob = this.myTasksList.find(task => task.jobNumber === selectedJobNumber);

    if (selectedJob) {
      console.log('Selected Job:', selectedJob); // Logge das ausgewählte Job-Objekt
      this.router.navigate(['/job-details', selectedJob.id]);
    } else {
      console.log('Selected Job not found'); // Logge eine Meldung, wenn der Job nicht gefunden wurde
    }
  }
}
