import { Component, HostListener, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GridComponent, PageSettingsModel, DetailDataBoundEventArgs, Grid } from '@syncfusion/ej2-angular-grids';
import { HistoryReadModel, JobFileReadModel } from 'src/app/core/NSwagDataClient';
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

  constructor(private route: ActivatedRoute, overviewService: OverviewService) {
    super();

    this.setNewSubscription = overviewService.jobdetailsFiles.subscribe((jobdetailsFiles) => {
      this.jobdetailsFilesList = jobdetailsFiles;
    });

    this.setNewSubscription = overviewService.jobdetailsHistory.subscribe((jobdetailsHistory) => {
      this.jobdetailsHistoryList = jobdetailsHistory;
    });

    this.pageSettings = { pageSize: overviewService.pageSettings.pageSize };
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.jobID = params['id'];
      console.log('Job ID:', this.jobID);
    });
  }
}
