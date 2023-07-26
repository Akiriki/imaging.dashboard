import { HttpClient } from '@angular/common/http';
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
  selectedJobInfos : JobReadModel | undefined;
  pageSettings: PageSettingsModel;

  // Variablen die man braucht
  jobID: string | undefined;
  editingMode: boolean = false;
  unsavedChanges: boolean = false;

  //#region additional Row Table
  detailHistoryDataBound(e: DetailDataBoundEventArgs | any) {
    console.log(this.jobdetailsHistoryList)
    const data = this.jobdetailsHistoryList.filter((item: HistoryReadModel) => item.id === e.data.id);

    const transformedData = data.map(item => ({
      field: item.field || 'N/A',
      oldValue: item.oldValue || '-',
      newValue: item.newValue || '-',
    }));

    let detail = new Grid({
        dataSource: transformedData,
        columns: [
            { field: 'field', headerText: 'Feld' },
            { field: 'oldValue', headerText: 'alter Wert' },
            { field: 'newValue', headerText: 'neuer Wert'}
        ]
    });
    detail.appendTo(e.detailElement.querySelector('.additionalRowForHistory-grid'));
  }

  detailFileDataBound(e : DetailDataBoundEventArgs | any){
    console.log(this.jobdetailsFilesList)
    const data = this.jobdetailsFilesList.filter((item: JobFileReadModel) => item.id === e.data.id);

    const transformedData = data.map(item => ({
      fileProperties: item.fileProperties || 'N/A',
      errorCode: item.errorCode || '-',
      errorMessage: item.errorMessage || '-',
    }));

    let detail = new Grid({
        dataSource: transformedData,
        columns: [
            { field: 'fileProperties', headerText: 'Dateigröße'},
            { field: 'errorCode', headerText: 'Fehler Code' },
            { field: 'errorMessage', headerText: 'Fehlergrund'}
        ]
    });
    detail.appendTo(e.detailElement.querySelector('.additionalRowForFiles-grid'));
  }

  //#endregion

  //#region Button toggle
  toggleEditingMode(value: boolean) {
    this.editingMode = value;
    if (value) {
      this.unsavedChanges = true;
    }
  }

  saveChanges() {
    // Code für speichern in DB über API (Befehle)

    // Änderungen speichern =>
    // Daten in this.jobDetails aktualisieren oder eine separate Variable verwenden,
    // um die bearbeiteten Daten zu speichern.

    const updateJobCommand = {
      id: this.selectedJobInfos?.id,
      consecutiveNumber: this.selectedJobInfos?.consecutiveNumber,
      title: this.selectedJobInfos?.title,
      deliveryDate: this.selectedJobInfos?.deliveryDate,
      orderDate: this.selectedJobInfos?.orderDate,
      switchJobId: this.selectedJobInfos?.switchJobId,
      jobInfo: this.selectedJobInfos?.jobInfo,
      orderType: this.selectedJobInfos?.orderType,
      project: this.selectedJobInfos?.project,
      easyJob: this.selectedJobInfos?.easyJob,
      billingOption: this.selectedJobInfos?.billingOption,
      status: this.selectedJobInfos?.status,
      numberOfFiles: this.selectedJobInfos?.numberOfFiles,
      customer: this.selectedJobInfos?.customer
    };

    this.http.put<JobReadModel>(`/api/jobs/${this.selectedJobInfos?.id}`, updateJobCommand)
      .subscribe(
        updatedJob => {
          // Die Antwort vom Backend enthält die aktualisierten Daten
          // Aktualisiere deine jobDetails oder eine separate Variable, um die neuen Daten zu speichern
          this.selectedJobInfos = updatedJob;
        },
        error => {
          console.error('Fehler beim Speichern der Daten: ', error);
        }
      );

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

  constructor(private route: ActivatedRoute, private overviewService: OverviewService, private http : HttpClient) {
    super();

    this.setNewSubscription = overviewService.jobdetailsFiles.subscribe((jobdetailsFiles) => {
      this.jobdetailsFilesList = jobdetailsFiles;
    });

    this.setNewSubscription = overviewService.jobdetailsHistory.subscribe((jobdetailsHistory) => {
      this.jobdetailsHistoryList = jobdetailsHistory;
    });

    this.setNewSubscription = overviewService.selectedJob.subscribe((jobInfos) => {
      this.selectedJobInfos = jobInfos;
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

  getBillingOption(status: number): string {
    switch (status) {
      case 0:
        return 'Cash';
      case 1:
        return 'CreditCard';
      case 2:
        return 'DebitCard';
      case 3:
        return 'Checks';
      default:
        return 'Unbekannte Zahlungsart';
    }
  }
}
