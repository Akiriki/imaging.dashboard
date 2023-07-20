import { Component } from '@angular/core';
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

  constructor(public overviewService : OverviewService) {
    super();
    this.setNewSubscription = overviewService.partnerFiles.subscribe((partnerFiles) => {
      this.partnerFilesList = partnerFiles
    })
    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}
  }
}
