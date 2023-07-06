import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
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

  private openJobList : OpenJobs[] = [
    {id : '1', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), numberOfFiles : 2},
    {id : '2', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), numberOfFiles : 2},
    {id : '3', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), numberOfFiles : 2}
  ]

  myTasks = new BehaviorSubject<MyTasks[]>([]);

  private myTaskList : MyTasks[] = [
    {id : '1', jobNumber : 'A', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), status : 'offen'},
    {id : '2', jobNumber : 'B', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), status : 'offen'},
    {id : '3', jobNumber : 'C', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), status : 'offen'}
  ]

  colleaguesTasks = new BehaviorSubject<ColleaguesTasks[]>([]);

  private colleaguesTasksList : ColleaguesTasks[] = [
    {id : '1', jobNumber : 'A', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'},
    {id : '2', jobNumber : 'B', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' ,status : 'offen'},
    {id : '3', jobNumber : 'C', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' , status : 'offen'}
  ]

  allPartnerFiles = new BehaviorSubject<AllPartnerFiles[]>([]);

  private allPartnerFilesList : AllPartnerFiles[] = [
    {id : '1', jobNumber : 'A', fileName : 'test', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'},
    {id : '2', jobNumber : 'B', fileName : 'test', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'},
    {id : '3', jobNumber : 'C', fileName : 'test', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' , fileAction : 'PC clipping'}
  ]

  allCorruptedFiles = new BehaviorSubject<AllCorruptedFiles[]>([]);

  private allCorruptedFilesList : AllCorruptedFiles[] = [
    {id : '1', jobNumber : 'A', fileName : 'test', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'},
    {id : '2', jobNumber : 'B', fileName : 'test', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'},
    {id : '3', jobNumber : 'C', fileName : 'test', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich', status : 'offen'}
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
