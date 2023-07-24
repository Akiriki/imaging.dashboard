import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { JobReadModel } from 'src/app/core/NSwagDataClient';
import { ArchiveService } from 'src/app/services/archive.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  //template : '',
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.scss']
})
export class ArchiveComponent extends DestroySubscriptionsComponent {
  archiveList : JobReadModel[] = []
  pageSettings: PageSettingsModel;

  constructor(public archiveService : ArchiveService, private router : Router) {
    super();
    this.setNewSubscription = archiveService.archiveContent.subscribe((archiveContent) => {
      this.archiveList = archiveContent
    })
    this.pageSettings = { pageSize : archiveService.pageSettings.pageSize}
    archiveService.loadArchive();
  }

  navigateToJobDetails(event: any) {
    const selectedJobNumber = parseInt(event.target.innerText, 10);
    console.log('Selected Job Number:', selectedJobNumber);

    const selectedJob = this.archiveList.find(task => task.consecutiveNumber === selectedJobNumber);

    if (selectedJob) {
      console.log('Selected Job:', selectedJob);
      this.router.navigate(['/job-details'], {queryParams : {id : selectedJob.id}});
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
        return 'Done';
      case 3:
        return 'TRANSFERRED2PARTNER';
      default:
        return 'Unbekannter Status';
    }
  }
}
