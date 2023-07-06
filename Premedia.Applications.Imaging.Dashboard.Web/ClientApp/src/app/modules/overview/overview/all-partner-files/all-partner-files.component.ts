import { Component } from '@angular/core';
import { AllPartnerFiles, OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-all-partner-files',
  templateUrl: './all-partner-files.component.html',
  styleUrls: ['./all-partner-files.component.scss']
})
export class AllPartnerFilesComponent extends DestroySubscriptionsComponent{
  allPartnerFilesList : AllPartnerFiles[] = [];

  constructor(public overviewService : OverviewService) {
    super();
    overviewService.allPartnerFiles.subscribe((allPartnerFiles) => {
      this.allPartnerFilesList = allPartnerFiles
    })

    overviewService.loadAllPartnerFiles();
  }
}
