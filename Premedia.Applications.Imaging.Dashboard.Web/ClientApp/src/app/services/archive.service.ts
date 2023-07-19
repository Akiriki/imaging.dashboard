import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';

export type Archiv =  {
  id : string
  jobNumber : string
  title : string
  customer: string
  date : Date
  editor : string
  status : string
}

@Injectable()
export class ArchiveService{

  archiveContent = new BehaviorSubject<Archiv[]>([]);
  public pageSettings : PageSettingsModel = { pageSize : 10 };

  private archiveList : Archiv[] = [
    {id : '1', jobNumber : 'Job Test 01', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph', status : 'offen'},
    {id : '2', jobNumber : 'Job Test 02', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' , status : 'offen'},
    {id : '3', jobNumber : 'Job Test 03', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '4', jobNumber : 'Job Test 04', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '5', jobNumber : 'Job Test 05', title : 'Felix Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '6', jobNumber : 'Job Test 06', title : 'Niklas Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '7', jobNumber : 'Job Test 07', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '8', jobNumber : 'Job Test 08', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph', status : 'offen'},
    {id : '9', jobNumber : 'Job Test 09', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Ich' , status : 'offen'},
    {id : '10', jobNumber : 'Job Test 10', title : 'Christoph Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '11', jobNumber : 'Job Test 11', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '12', jobNumber : 'Job Test 12', title : 'Felix Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '13', jobNumber : 'Job Test 13', title : 'Niklas Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'},
    {id : '14', jobNumber : 'Job Test 14', title : 'Verene Mauder', customer: 'XXLDE', date : new Date('10.05.2022'), editor : 'Christoph' , status : 'offen'}
  ]

  loadArchive(){
    this.archiveContent.next(this.archiveList);
  }
}
