import { Component } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { AllPartnerFiles, OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-all-partner-files',
  templateUrl: './all-partner-files.component.html',
  styleUrls: ['./all-partner-files.component.scss']
})
export class AllPartnerFilesComponent extends DestroySubscriptionsComponent{
  allPartnerFilesList : AllPartnerFiles[] = [];
  pageSettings: PageSettingsModel;

  constructor(public overviewService : OverviewService) {
    super();
    overviewService.allPartnerFiles.subscribe((allPartnerFiles) => {
      this.allPartnerFilesList = allPartnerFiles
    })
    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}
    overviewService.loadAllPartnerFiles();
  }
}
