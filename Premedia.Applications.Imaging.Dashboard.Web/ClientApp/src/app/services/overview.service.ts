import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';

export type OpenJobs =  {
  id : string
  title : string
  customer: string
  date : Date
  numberOfFiles : number
}

export type MyTasks =  {
  id : string
  jobNumber : string
  title: string
  customer: string
  date : Date
  status : string
}

export type ColleaguesTasks = {
  id : string
  jobNumber : string
  title: string
  customer: string
  date : Date
  editor : string
  status : string
}

export type AllPartnerFiles = {
  id : string
  jobNumber : string
  fileName: string
  customer: string
  date : Date
  editor : string
  fileAction : string
}

export type AllCorruptedFiles = {
  id : string
  jobNumber : string
  fileName: string
  customer: string
  date : Date
  editor : string
  status : string
}

@Injectable()
export class OverviewService {
  openJobs = new BehaviorSubject<OpenJobs[]>([]);
  public pageSettings : PageSettingsModel = { pageSize : 5 };

  private openJobList : OpenJobs[] = [
    {id : '1', title : 'Anna Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), numberOfFiles : 12},
    {id : '2', title : 'Berta Mauder', customer: 'XXLAT', date : new Date('10.05.2023'), numberOfFiles : 9},
    {id : '3', title : 'Claudia Mauder', customer: 'XXLAT', date : new Date('10.05.2023'), numberOfFiles : 6},
    {id : '4', title : 'Doris Mauder', customer: 'XXLAT', date : new Date('10.05.2023'), numberOfFiles : 2},
    {id : '5', title : 'Emilia Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), numberOfFiles : 4},
    {id : '6', title : 'Franziska Mauder', customer: 'XXLAT', date : new Date('10.05.2023'), numberOfFiles : 21},
    {id : '7', title : 'Gertrude Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), numberOfFiles : 3}
  ]

  myTasks = new BehaviorSubject<MyTasks[]>([]);

  private myTaskList : MyTasks[] = [
    {id : '1', jobNumber : 'Job Test 01', title : 'Felix Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), status : 'offen'},
    {id : '2', jobNumber : 'Job Test 02', title : 'Verene Mauder', customer: 'XXLAT', date : new Date('10.05.2023'), status : 'offen'},
    {id : '3', jobNumber : 'Job Test 03', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), status : 'offen'},
    {id : '4', jobNumber : 'Job Test 04', title : 'Niklas Mauder', customer: 'XXLAT', date : new Date('10.05.2023'), status : 'offen'},
    {id : '5', jobNumber : 'Job Test 05', title : 'Christoph Mauder', customer: 'XXLAT', date : new Date('10.05.2023'), status : 'offen'},
    {id : '6', jobNumber : 'Job Test 06', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), status : 'offen'},
    {id : '7', jobNumber : 'Job Test 07', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2023'), status : 'offen'},
  ]

  colleaguesTasks = new BehaviorSubject<ColleaguesTasks[]>([]);

  private colleaguesTasksList : ColleaguesTasks[] = [
    {id : '1', jobNumber : 'Job Test 01', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph', status : 'offen'},
    {id : '2', jobNumber : 'Job Test 02', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' ,status : 'offen'},
    {id : '3', jobNumber : 'Job Test 03', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '4', jobNumber : 'Job Test 04', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '5', jobNumber : 'Job Test 05', title : 'Felix Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '6', jobNumber : 'Job Test 06', title : 'Niklas Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '7', jobNumber : 'Job Test 07', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'}
  ]

  allPartnerFiles = new BehaviorSubject<AllPartnerFiles[]>([]);

  private allPartnerFilesList : AllPartnerFiles[] = [
    {id : '1', jobNumber : 'Job Test 01', fileName : 'test1', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , fileAction : 'PC clipping'},
    {id : '2', jobNumber : 'Job Test 02', fileName : 'test2', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , fileAction : 'PC clipping'},
    {id : '3', jobNumber : 'Job Test 03', fileName : 'test3', customer: 'XXLAT', date : new Date('10.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'},
    {id : '4', jobNumber : 'Job Test 04', fileName : 'test4', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Felix' , fileAction : 'PC clipping'},
    {id : '5', jobNumber : 'Job Test 05', fileName : 'test5', customer: 'XXLAT', date : new Date('10.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'},
    {id : '6', jobNumber : 'Job Test 06', fileName : 'test6', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Niklas' , fileAction : 'PC clipping'},
    {id : '7', jobNumber : 'Job Test 07', fileName : 'test7', customer: 'XXLAT', date : new Date('10.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'}
  ]

  allCorruptedFiles = new BehaviorSubject<AllCorruptedFiles[]>([]);

  private allCorruptedFilesList : AllCorruptedFiles[] = [
    {id : '1', jobNumber : 'Job Test 01', fileName : 'test1', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'},
    {id : '2', jobNumber : 'Job Test 02', fileName : 'test2', customer: 'XXLAT', date : new Date('10.05.2022'), editor : 'Christoph', status : 'offen'},
    {id : '3', jobNumber : 'Job Test 03', fileName : 'test3', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'},
    {id : '4', jobNumber : 'Job Test 04', fileName : 'test4', customer: 'XXLAT', date : new Date('10.05.2022'), editor : 'Christoph', status : 'offen'},
    {id : '5', jobNumber : 'Job Test 05', fileName : 'test5', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'},
    {id : '6', jobNumber : 'Job Test 06', fileName : 'test6', customer: 'XXLAT', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'},
    {id : '7', jobNumber : 'Job Test 07', fileName : 'test7', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph', status : 'offen'}
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
}
