import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';


// JOB - DETAILS
export type JobFiles = {
  id : string
  consecutiveNumber : number
  error : string
  originalFileName : string
  editedFileName : string
  action : string
  storageLocation : string
  filingPath : string
  activity : string
  status : string
}

export type HistoryInfo = {
  id : string
  consecutiveNumber : number
  date : Date
  title : string
  editor : string
}

@Injectable()
export class OverviewService {
  // Objekte für Daten Startseite
  openJobs = new BehaviorSubject<DataClient.JobReadModel[]>([]);
  myTasks = new BehaviorSubject<DataClient.JobReadModel[]>([]);
  colleaguesTasks = new BehaviorSubject<DataClient.JobReadModel[]>([]);
  partnerFiles = new BehaviorSubject<DataClient.JobFileReadModel[]>([]);

  // Objekte für Jobdetailansicht


  // Property zum setzen: wie viele Datensätze in der Syncfusion Tabelle angezeigt werden sollten
  public pageSettings : PageSettingsModel = { pageSize : 5 };

  jobFiles = new BehaviorSubject<JobFiles[]>([]);

  private jobFileList : JobFiles[] = [
    {id : '632c3f68-0c90-4799-8a66-6c2e5e71d123', consecutiveNumber : 1, error : 'ok', originalFileName: '82271267-F01.tif', editedFileName : '', action : 'Speichern', storageLocation : 'Artikelstruktur', filingPath : '?', activity : 'Bearbeitung MQ', status : 'In Bearbeitung'},
    {id : '265f6f8e-d272-458f-b9e4-9223ff0f6456', consecutiveNumber : 2, error : 'ok', originalFileName: '82271267-F02.tif', editedFileName : '', action : 'Clippen', storageLocation : 'Artikelstruktur', filingPath : '?', activity : 'Bearbeitung MQ', status : 'Bei Partner'},
    {id : '57b978e7-02ac-4cfd-85c1-28d240c99789', consecutiveNumber : 3, error : 'nicht ok', originalFileName: '82271267-F03.tif', editedFileName : '', action : 'Speichern', storageLocation : 'Artikelstruktur', filingPath : '?', activity : 'Bearbeitung MQ', status : 'In Bearbeitung'}
  ]

  history = new BehaviorSubject<HistoryInfo[]>([]);

  private historyList : HistoryInfo[] = [
    {id : '632c3f68-0c90-4799-8a66-6c2e5e71d123', consecutiveNumber : 1, date : new Date('10.11.2023 11:30'), title : 'Aufgabe erstellt', editor : 'System'},
    {id : '632c3f68-0c90-4799-8a66-6c2e5e71d456', consecutiveNumber : 2, date : new Date('11.14.2023 09:10'), title : 'Werte geändert', editor : 'KRA'},
    {id : '632c3f68-0c90-4799-8a66-6c2e5e71d789', consecutiveNumber : 3, date : new Date('12.1.2023 16:50'), title : 'File Status geändert', editor : 'KRA'}
  ]

  constructor(private dataClient: DataClient.JobClient) {
  }

  //Hier werden die Daten aus dem Backend geladen:

  loadOpenJobs() {
    this.dataClient.getNewJobs().subscribe(result => {
      this.openJobs.next(result);
    }, error => console.error(error));
  }

  loadMyTasks(){
      this.dataClient.getJobsByEditorId('0296b2b2-94b4-4870-897a-c96311ac9df6').subscribe(result => {
      this.myTasks.next(result);
    }, error => console.error(error));

  }

  loadColleaguesTasks(){
      this.dataClient.getColleagueJobs('0296b2b2-94b4-4870-897a-c96311ac9df6').subscribe(result => {
      this.colleaguesTasks.next(result);
    }, error => console.error(error));

  }

  loadAllPartnerFiles(){
      this.dataClient.getTransferredJobs().subscribe(result => {
      this.partnerFiles.next(result);
    }, error => console.error(error));
  }

  // Mockdaten geladen siehe oben:

  loadJobFiles(){
    this.jobFiles.next(this.jobFileList)
  }

  loadHistory(){
    this.history.next(this.historyList)
  }
}
