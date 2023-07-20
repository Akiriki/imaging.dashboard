import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { JobReadModel } from 'src/app/core/NSwagDataClient';
import { OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-colleagues-tasks',
  templateUrl: './colleagues-tasks.component.html',
  styleUrls: ['./colleagues-tasks.component.scss']
})
export class ColleaguesTasksComponent extends DestroySubscriptionsComponent{
  colleaguesTasksList : JobReadModel[] = [];
  pageSettings: PageSettingsModel;
  editorUserName: string = '';


  constructor(public overviewService : OverviewService, private router : Router) {
    super();

    this.setNewSubscription = overviewService.colleaguesTasks.subscribe((colleaguesTasks) => {
      this.colleaguesTasksList = colleaguesTasks
    })

    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}

    // Beispiel: Setze den editorUserName, wenn das JSON-Objekt über die API empfangen wurde
    const firstTaskWithEditor = this.colleaguesTasksList.find((task) => !!task.editor);
    this.editorUserName = (firstTaskWithEditor?.editor?.userName || '') as string;
  }

  navigateToJobDetails(event: any) {
    const selectedJobNumber = parseInt(event.target.innerText, 10);
    console.log('Selected Job Number:', selectedJobNumber);

    const selectedJob = this.colleaguesTasksList.find(task => task.consecutiveNumber === selectedJobNumber);

    if (selectedJob) {
      console.log('Selected Job:', selectedJob);
      this.router.navigate(['/job-details', selectedJob.id]);
    } else {
      console.log('Selected Job not found');
    }
  }

  getStatusString(status: number): string {
    switch (status) {
      case 0:
        return 'TO-DO';
      case 1:
        return 'In Progress';
      case 2:
        return 'Finished';
      case 3:
        return 'TRANSFERRED2PARTNER';
      default:
        return 'Unbekannter Status';
    }
  }
}
