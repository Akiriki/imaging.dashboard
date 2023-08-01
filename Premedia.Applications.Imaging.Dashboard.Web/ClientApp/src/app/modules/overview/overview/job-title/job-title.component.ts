import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { JobFileReadModel, JobReadModel } from 'src/app/core/NSwagDataClient';
import { OverviewService } from 'src/app/services/overview.service';
import { StatusService } from 'src/app/services/status.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-job-title',
  templateUrl: './job-title.component.html',
  styleUrls: ['./job-title.component.scss']
})
export class JobTitleComponent extends DestroySubscriptionsComponent{

  // Listen für die Daten aus der DB
  selectedJobInfos : JobReadModel | undefined;
  jobFilesList : JobFileReadModel[] = []
  pageSettings : PageSettingsModel

  // Für Nr. Spalte
  rowNumber : number = 1

  constructor(private route: ActivatedRoute, private overviewService: OverviewService, public statusService : StatusService) {
    super();

    this.setNewSubscription = overviewService.jobdetailsFiles.subscribe((jobdetailsFiles) => {
      this.jobFilesList = jobdetailsFiles;
    });

    this.setNewSubscription = overviewService.selectedJob.subscribe((jobInfos) => {
      this.selectedJobInfos = jobInfos;
    })

    this.pageSettings = { pageSize: overviewService.pageSettings.pageSize };

    // Detailseite
    this.route.queryParams.subscribe((params) => {
      this.overviewService.loadJobInfos(params.id);
      this.overviewService.loadJobFileDetails(params.id);
    })
  }

  public rowNumberTemplate: any = {
    template: '<div>{{index + 1}}</div>'
  };

  getOrderType(status: number): string {
    switch (status) {
      case 0:
        return 'Nicht Wichtig';
      case 1:
        return 'Wichtig';
      default:
        return 'Unbekannt';
    }
  }
}
