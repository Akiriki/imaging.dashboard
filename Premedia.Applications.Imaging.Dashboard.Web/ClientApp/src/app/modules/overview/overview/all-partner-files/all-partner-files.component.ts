import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { JobFileReadModel } from 'src/app/core/NSwagDataClient';
import { OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-all-partner-files',
  templateUrl: './all-partner-files.component.html',
  styleUrls: ['./all-partner-files.component.scss']
})
export class AllPartnerFilesComponent extends DestroySubscriptionsComponent{
  partnerFilesList : JobFileReadModel[] = [];
  pageSettings: PageSettingsModel;

  constructor(public overviewService : OverviewService, private router : Router) {
    super();
    this.setNewSubscription = overviewService.partnerFiles.subscribe((partnerFiles) => {
      this.partnerFilesList = partnerFiles.slice();
      this.partnerFilesList.sort((a, b) => {
        const titleA = a.job?.title?.toUpperCase() || '';
        const titleB = b.job?.title?.toUpperCase() || '';
        return titleA.localeCompare(titleB);
      });
    })
    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}
  }

  navigateToJobDetails(event: any) {
    const selectedJobNumber = parseInt(event.target.innerText, 10);
    console.log('Selected Job Number:', selectedJobNumber);

    const selectedJob = this.partnerFilesList.find(task => task.job?.consecutiveNumber === selectedJobNumber);

    if (selectedJob) {
      console.log('Selected Job:', selectedJob);
      this.router.navigate(['/job-details'], {queryParams : {id : selectedJob.id}});
    } else {
      console.log('Selected Job not found');
    }
  }
}
