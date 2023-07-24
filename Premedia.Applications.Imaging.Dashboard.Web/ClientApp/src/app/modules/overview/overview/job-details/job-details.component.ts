import { Component, HostListener } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageSettingsModel, DetailDataBoundEventArgs, Grid } from '@syncfusion/ej2-angular-grids';
import { HistoryReadModel, JobFileReadModel, JobReadModel } from 'src/app/core/NSwagDataClient';
import { OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrls: ['./job-details.component.scss']
})
export class JobDetailsComponent extends DestroySubscriptionsComponent {
  // Objekte
  jobdetailsFilesList: JobFileReadModel[] = [];
  jobdetailsHistoryList: HistoryReadModel[] = [];
  jobInfosList : JobReadModel[] = [];
  pageSettings: PageSettingsModel;

  // Variablen die man braucht
  jobID: string | undefined;
  editingMode: boolean = false;
  unsavedChanges: boolean = false;

  detailDataBound(e: DetailDataBoundEventArgs | any) {
    let detail = new Grid({
        dataSource: this.jobdetailsHistoryList.filter((item: Object) => (item as any)['id'] === e.data['id']),
        columns: [
            { field: 'id', headerText: 'Test' },
            { field: 'id', headerText: 'Test' },
            { field: 'id', headerText: 'Test' }
        ]
    });
    detail.appendTo(e.detailElement.querySelector('.custom-grid'));
}

  //#region Button toggle
  toggleEditingMode(value: boolean) {
    this.editingMode = value;
    if (value) {
      this.unsavedChanges = true;
    }
  }

  saveChanges() {
    // Code für speichern in DB über API (Befehle)

    // Optional: Änderungen speichern =>
    // Daten in this.jobDetails aktualisieren oder eine separate Variable verwenden,
    // um die bearbeiteten Daten zu speichern.

    this.toggleEditingMode(false);
    this.unsavedChanges = false;
  }

  @HostListener('window:beforeunload', ['$event'])
  unloadNotification($event: any) {
    if (this.editingMode && this.unsavedChanges) {
      $event.returnValue = 'Sie haben ungesicherte Änderungen... Sind Sie sich sicher, dass Sie die Seite wirklich verlassen wollen?';
    }
  }

  onInput(event: Event) {
    this.unsavedChanges = true;
  }
  //#endregion

  constructor(private route: ActivatedRoute, private overviewService: OverviewService) {
    super();

    this.setNewSubscription = overviewService.jobdetailsFiles.subscribe((jobdetailsFiles) => {
      this.jobdetailsFilesList = jobdetailsFiles;
    });

    this.setNewSubscription = overviewService.jobdetailsHistory.subscribe((jobdetailsHistory) => {
      this.jobdetailsHistoryList = jobdetailsHistory;
    });

    this.setNewSubscription = overviewService.jobInfos.subscribe((jobInfos) => {
      this.jobInfosList = jobInfos;
    })

    this.pageSettings = { pageSize: overviewService.pageSettings.pageSize };

    // Detailseite
    this.route.queryParams.subscribe((params) => {
      this.overviewService.loadJobInfos(params.id);
      this.overviewService.loadJobFileDetails(params.id);
      this.overviewService.loadHistoryFileDetails(params.id);
    })
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
