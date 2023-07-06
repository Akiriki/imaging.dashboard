import { Component } from '@angular/core';
import { AllCorruptedFiles, OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-all-corrupted-files',
  templateUrl: './all-corrupted-files.component.html',
  styleUrls: ['./all-corrupted-files.component.scss']
})
export class AllCorruptedFilesComponent extends DestroySubscriptionsComponent{
  allCorruptedFilesList : AllCorruptedFiles[] = [];

  constructor(public overviewService : OverviewService) {
    super();
    overviewService.allCorruptedFiles.subscribe((allCorruptedFiles) => {
      this.allCorruptedFilesList = allCorruptedFiles;
    })

    overviewService.loadAllCorruptedFiles();
  }
}
