import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';

export type OpenJobs =  {
  id : string
  consecutiveNumber : number
  title : string
  customer: string
  date : Date
  numberOfFiles : number
}

export type MyTasks =  {
  id : string
  consecutiveNumber : number
  jobNumber : string
  title: string
  customer: string
  date : Date
  status : string
}

export type ColleaguesTasks = {
  id : string
  consecutiveNumber : number
  jobNumber : string
  title: string
  customer: string
  date : Date
  editor : string
  status : string
}

export type AllPartnerFiles = {
  id : string
  consecutiveNumber : number
  jobNumber : string
  fileName: string
  customer: string
  date : Date
  editor : string
  fileAction : string
}

export type AllCorruptedFiles = {
  id : string
  consecutiveNumber : number
  jobNumber : string
  fileName: string
  customer: string
  date : Date
  editor : string
  status : string
}

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
  openJobs = new BehaviorSubject<OpenJobs[]>([]);
  public pageSettings : PageSettingsModel = { pageSize : 5 };

  private openJobList : OpenJobs[] = [
    {id : '632c3f68-0c90-4799-8a66-6c2e5e71d639', consecutiveNumber : 1, title : 'Anna Mauder', customer: 'XXLDE', date : new Date('10.06.2023'), numberOfFiles : 12},
    {id : '265f6f8e-d272-458f-b9e4-9223ff0f6030', consecutiveNumber : 2, title : 'Berta Mauder', customer: 'XXLAT', date : new Date('10.03.2023'), numberOfFiles : 9},
    {id : '57b978e7-02ac-4cfd-85c1-28d240c99688', consecutiveNumber : 3, title : 'Claudia Mauder', customer: 'XXLAT', date : new Date('10.01.2023'), numberOfFiles : 6},
    {id : 'dc448ab6-00d7-46b9-9a2f-8a7b011216c4', consecutiveNumber : 4, title : 'Doris Mauder', customer: 'XXLAT', date : new Date('10.04.2023'), numberOfFiles : 2},
    {id : '54c2d31e-7465-4295-92ea-70dd8d49f609', consecutiveNumber : 5, title : 'Emilia Mauder', customer: 'XXLDE', date : new Date('10.09.2023'), numberOfFiles : 4},
    {id : '7c3ecdb1-4d90-4d94-9e4a-819f9358bd7f', consecutiveNumber : 6, title : 'Franziska Mauder', customer: 'XXLAT', date : new Date('10.02.2023'), numberOfFiles : 21},
    {id : '46d1c2b5-5fcb-4b9e-a432-a26f398b6850', consecutiveNumber : 7, title : 'Gertrude Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), numberOfFiles : 3}
  ]

  myTasks = new BehaviorSubject<MyTasks[]>([]);

  private myTaskList : MyTasks[] = [
    {id : 'ef7d7fb7-96c3-4b71-b367-ca195fa133c3', consecutiveNumber : 1, jobNumber : 'Job Test 01', title : 'Felix Mauder', customer: 'XXLDE', date : new Date('10.06.2023'), status : 'offen'},
    {id : '265f6f8e-d272-458f-b9e4-9223ff0f6030', consecutiveNumber : 2, jobNumber : 'Job Test 02', title : 'Verene Mauder', customer: 'XXLAT', date : new Date('10.30.2023'), status : 'offen'},
    {id : '57b978e7-02ac-4cfd-85c1-28d240c99688', consecutiveNumber : 3, jobNumber : 'Job Test 03', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.25.2023'), status : 'offen'},
    {id : 'dc448ab6-00d7-46b9-9a2f-8jaa7b011216', consecutiveNumber : 4, jobNumber : 'Job Test 04', title : 'Niklas Mauder', customer: 'XXLAT', date : new Date('10.15.2023'), status : 'offen'},
    {id : '54c2d31e-7465-4295-92ea-70dd8d49f609', consecutiveNumber : 5, jobNumber : 'Job Test 05', title : 'Christoph Mauder', customer: 'XXLAT', date : new Date('10.04.2023'), status : 'offen'},
    {id : '7c3ecdb1-4d90-4d94-9e4a-819f9358bd7f', consecutiveNumber : 6, jobNumber : 'Job Test 06', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), status : 'offen'},
    {id : '46d1c2b5-5fcb-4b9e-a432-a26f398b6850', consecutiveNumber : 7, jobNumber : 'Job Test 07', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.01.2023'), status : 'offen'},
  ]

  colleaguesTasks = new BehaviorSubject<ColleaguesTasks[]>([]);

  private colleaguesTasksList : ColleaguesTasks[] = [
    {id : '1b4e3b5c-9cd9-448a-baf3-8c2aaac78b11', consecutiveNumber : 1, jobNumber : 'Job Test 01', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.07.2022'), editor : 'Christoph', status : 'offen'},
    {id : '1795252d-e9e5-4e2c-b780-9dcd04b4b8af', consecutiveNumber : 2, jobNumber : 'Job Test 02', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.06.2022'), editor : 'Ich' ,status : 'offen'},
    {id : '009ed960-8135-413b-9b9f-b92d594c7b16', consecutiveNumber : 3, jobNumber : 'Job Test 03', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : 'cdf4e2b8-2113-4e8f-8bc0-78d7eda642a6', consecutiveNumber : 4, jobNumber : 'Job Test 04', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.04.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '349798b9-0491-424b-895a-735cf643ee13', consecutiveNumber : 5, jobNumber : 'Job Test 05', title : 'Felix Mauder', customer: 'XXLDE', date : new Date('10.03.2022'), editor : 'Christoph' , status : 'offen'},
    {id : 'ec882530-9f1a-4112-b53b-f2eff1635e2e', consecutiveNumber : 6, jobNumber : 'Job Test 06', title : 'Niklas Mauder', customer: 'XXLDE', date : new Date('10.02.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '9c0f5459-a859-494c-a0ed-96cb7f85ed62', consecutiveNumber : 7, jobNumber : 'Job Test 07', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.01.2022'), editor : 'Christoph' , status : 'offen'}
  ]

  allPartnerFiles = new BehaviorSubject<AllPartnerFiles[]>([]);

  private allPartnerFilesList : AllPartnerFiles[] = [
    {id : 'ff5d6e23-37bd-4f9a-b677-6383a8650eee', consecutiveNumber : 1, jobNumber : 'Job Test 01', fileName : 'test1', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , fileAction : 'PC clipping'},
    {id : '8964354a-5010-4ef2-b86b-77aae59ba89d', consecutiveNumber : 2, jobNumber : 'Job Test 02', fileName : 'test2', customer: 'XXLDE', date : new Date('11.05.2022'), editor : 'Christoph' , fileAction : 'PC clipping'},
    {id : 'a4a43228-a7aa-43a8-9e84-c8a441030b34', consecutiveNumber : 3, jobNumber : 'Job Test 03', fileName : 'test3', customer: 'XXLAT', date : new Date('12.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'},
    {id : '51b04f78-5a12-4120-ab85-0ebd6dc6e0b2', consecutiveNumber : 4, jobNumber : 'Job Test 04', fileName : 'test4', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Felix' , fileAction : 'PC clipping'},
    {id : '7ea5799a-70a7-43c5-840e-3b0e22fbb887', consecutiveNumber : 5, jobNumber : 'Job Test 05', fileName : 'test5', customer: 'XXLAT', date : new Date('10.9.2022'), editor : 'Ich' , fileAction : 'PC clipping'},
    {id : '7affc682-54ba-4072-a9c9-80a15ad30add', consecutiveNumber : 6, jobNumber : 'Job Test 06', fileName : 'test6', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Niklas' , fileAction : 'PC clipping'},
    {id : '38e94776-0903-42c1-bd85-95cfec090c5b', consecutiveNumber : 7, jobNumber : 'Job Test 07', fileName : 'test7', customer: 'XXLAT', date : new Date('10.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'}
  ]

  allCorruptedFiles = new BehaviorSubject<AllCorruptedFiles[]>([]);

  private allCorruptedFilesList : AllCorruptedFiles[] = [
    {id : '1', consecutiveNumber : 1, jobNumber : 'Job Test 01', fileName : 'test1', customer: 'XXLDE', date : new Date('10.30.2022'), editor : 'Ich', status : 'offen'},
    {id : '2', consecutiveNumber : 2, jobNumber : 'Job Test 02', fileName : 'test2', customer: 'XXLAT', date : new Date('10.27.2022'), editor : 'Christoph', status : 'offen'},
    {id : '3', consecutiveNumber : 3, jobNumber : 'Job Test 03', fileName : 'test3', customer: 'XXLDE', date : new Date('10.24.2022'), editor : 'Ich', status : 'offen'},
    {id : '4', consecutiveNumber : 4, jobNumber : 'Job Test 04', fileName : 'test4', customer: 'XXLAT', date : new Date('10.21.2022'), editor : 'Christoph', status : 'offen'},
    {id : '5', consecutiveNumber : 5, jobNumber : 'Job Test 05', fileName : 'test5', customer: 'XXLDE', date : new Date('10.19.2022'), editor : 'Ich', status : 'offen'},
    {id : '6', consecutiveNumber : 5, jobNumber : 'Job Test 06', fileName : 'test6', customer: 'XXLAT', date : new Date('10.03.2022'), editor : 'Ich', status : 'offen'},
    {id : '7', consecutiveNumber : 7, jobNumber : 'Job Test 07', fileName : 'test7', customer: 'XXLDE', date : new Date('10.01.2022'), editor : 'Christoph', status : 'offen'}
  ]

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

  constructor(private dataClient: DataClient.WeatherForecastClient) {
  }

  //Hier werden die Daten aus dem Backend geladen
  loadOpenJobs() {
    /*this.dataClient.get().subscribe(result => {
      this.weatherForecasts.next(result);
    }, error => console.error(error));*/

    this.openJobs.next(this.openJobList);
  }

  loadMyTasks(){
    this.myTasks.next(this.myTaskList);
  }

  loadAllPartnerFiles(){
    this.allPartnerFiles.next(this.allPartnerFilesList)
  }

  loadColleaguesTasks(){
    this.colleaguesTasks.next(this.colleaguesTasksList)
  }

  loadAllCorruptedFiles(){
    this.allCorruptedFiles.next(this.allCorruptedFilesList)
  }

  loadJobFiles(){
    this.jobFiles.next(this.jobFileList)
  }

  loadHistory(){
    this.history.next(this.historyList)
  }
}
