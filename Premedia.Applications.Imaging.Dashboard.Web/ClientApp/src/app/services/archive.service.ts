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

@Injectable()
export class ArchiveService{

}
