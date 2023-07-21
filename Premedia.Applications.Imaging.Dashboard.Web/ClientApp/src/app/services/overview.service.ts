import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';

@Injectable()
export class OverviewService {
  // Objekte für Daten Startseite
  openJobs = new BehaviorSubject<DataClient.JobReadModel[]>([]);
  myTasks = new BehaviorSubject<DataClient.JobReadModel[]>([]);
  colleaguesTasks = new BehaviorSubject<DataClient.JobReadModel[]>([]);
  partnerFiles = new BehaviorSubject<DataClient.JobFileReadModel[]>([]);

  // Objekt für Jobdetailansicht (Tabelle Job-Files & History)
  jobdetailsFiles = new BehaviorSubject<DataClient.JobFileReadModel[]>([]);
  jobdetailsHistory = new BehaviorSubject<DataClient.HistoryReadModel[]>([]);

  // Property zum setzen: wie viele Datensätze in der Syncfusion Tabelle angezeigt werden sollten
  public pageSettings : PageSettingsModel = { pageSize : 5 };

  constructor(private jobDataClient: DataClient.JobClient, private jobFileDataClient : DataClient.JobFileClient, private historyDataClient : DataClient.HistoryClient) {
  }

  //Hier werden die Daten aus dem Backend geladen:

  loadOpenJobs() {
    this.jobDataClient.getNewJobs().subscribe(result => {
      this.openJobs.next(result);
    }, error => console.error(error));
  }

  loadMyTasks(){
      this.jobDataClient.getJobsByEditorId('0296b2b2-94b4-4870-897a-c96311ac9df6').subscribe(result => {
      this.myTasks.next(result);
    }, error => console.error(error));

  }

  loadColleaguesTasks(){
      this.jobDataClient.getColleagueJobs('0296b2b2-94b4-4870-897a-c96311ac9df6').subscribe(result => {
      this.colleaguesTasks.next(result);
    }, error => console.error(error));
  }

  // TO-DO Endpoint Backend (sollte mit Niklas Pull Request da sein)
  loadAllPartnerFiles(){
      this.jobFileDataClient.getTransferredJobFiles().subscribe(result => {
      this.partnerFiles.next(result);
    }, error => console.error(error));
  }

  // TO-DO Endpoint Backend (sollte mit Niklas Pull Request da sein)
  loadJobFileDetails(){
    this.jobFileDataClient.getJobFilesById('0296b2b2-94b4-4870-897a-c96311ac9df6').subscribe(result => {
      this.jobdetailsFiles.next(result);
    }, error => console.error(error))
  }

  // TO-DO Endpoint Backend (sollte mit Niklas Pull Request da sein)
  loadHistoryFileDetails(){
    this.historyDataClient.getHistoryById('0296b2b2-94b4-4870-897a-c96311ac9df6').subscribe(result => {
      this.jobdetailsHistory.next(result);
    }, error => console.error(error))
  }
}
