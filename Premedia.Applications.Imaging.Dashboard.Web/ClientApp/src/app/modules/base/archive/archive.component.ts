import { Component } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { Archiv, ArchiveService } from 'src/app/services/archive.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  //template : '',
  selector: 'app-archive',
  templateUrl: './archive.component.html',
  styleUrls: ['./archive.component.scss']
})
export class ArchiveComponent extends DestroySubscriptionsComponent {
  archiveList : Archiv[] = []
  pageSettings: PageSettingsModel;

  constructor(public archiveService : ArchiveService) {
    super();
    archiveService.archiveContent.subscribe((archiveContent) => {
      this.archiveList = archiveContent
    })
    this.pageSettings = { pageSize : archiveService.pageSettings.pageSize}
    archiveService.loadArchive();
  }

}
