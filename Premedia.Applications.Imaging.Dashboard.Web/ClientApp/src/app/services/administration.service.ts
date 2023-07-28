import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';

export type Activities =  {
  id : string
  customer: string
  serviceType : string
  quality : string
}

export type CustomerMapping = {
  id : string
  name : string
  customer : string
  projectType : string
  erpCustomer : string
  erpProduct : string
  erpContact : string
}


export type ProjectDeclaration = {
  id : string
  name : string
}


@Injectable()
export class AdministrationService{

  // how many records are displayed in the table
  public pageSettings : PageSettingsModel = { pageSize : 20 };

  activitiesContent = new BehaviorSubject<Activities[]>([]);

  private activitiesList : Activities[] = [
    {id : '1', customer : 'XXLAT', serviceType : 'Bearbeitung HQ eciRGB v2', quality: 'HQ'},
    {id : '2', customer : 'XXLAT', serviceType : 'Bearbeitung HQ eciRGB v2', quality: 'HQ'},
    {id : '3', customer : 'XXLAT', serviceType : 'Bearbeitung HQ eciRGB v2', quality: 'LQ'},
    {id : '4', customer : 'XXLAT', serviceType : 'Bearbeitung HQ eciRGB v2', quality: 'HQ'},
    {id : '5', customer : 'XXLAT', serviceType : 'Bearbeitung HQ eciRGB v2', quality: 'LQ'},
    {id : '6', customer : 'XXLAT', serviceType : 'Bearbeitung HQ eciRGB v2', quality: 'MQ'},
    {id : '7', customer : 'XXLAT', serviceType : 'Bearbeitung HQ eciRGB v2', quality: 'HQ'}
  ]

  customerMappingContent = new BehaviorSubject<CustomerMapping[]>([]);

  private customerMappingList : CustomerMapping[] = [
    {id : '1', name : 'Lutz EBV', customer : 'XXLAT', projectType : 'FLAT ULAT PLAT XLAT', erpCustomer: 'XXLutz KG', erpProduct : 'XXXLutz EBV', erpContact : 'Rober Auinger'},
    {id : '2', name : 'Lutz EBV', customer : 'XXLAT', projectType : 'FLAT ULAT PLAT XLAT', erpCustomer: 'XXLutz CZ', erpProduct : 'XXXLutz CZ EBV', erpContact : 'Rober Auinger'},
    {id : '3', name : 'Lutz EBV', customer : 'XXLAT', projectType : 'FLAT ULAT PLAT XLAT', erpCustomer: 'XXLutz CZ', erpProduct : 'XXXLutz CZ EBV', erpContact : 'Rober Auinger'},
    {id : '4', name : 'Lutz EBV', customer : 'XXLAT', projectType : 'FLAT ULAT PLAT XLAT', erpCustomer: 'XXLutz KG', erpProduct : 'XXXLutz CZ EBV', erpContact : 'Rober Auinger'},
    {id : '5', name : 'Lutz EBV', customer : 'XXLAT', projectType : 'FLAT ULAT PLAT XLAT', erpCustomer: 'XXLutz AT', erpProduct : 'XXXLutz AT EBV', erpContact : 'Rober Auinger'},
    {id : '6', name : 'Lutz EBV', customer : 'XXLAT', projectType : 'FLAT ULAT PLAT XLAT', erpCustomer: 'XXLutz CH', erpProduct : 'XXXLutz CH EBV', erpContact : 'Rober Auinger'},
    {id : '7', name : 'Lutz EBV', customer : 'XXLAT', projectType : 'FLAT ULAT PLAT XLAT', erpCustomer: 'XXLutz CH', erpProduct : 'XXXLutz CH EBV', erpContact : 'Rober Auinger'},
  ]

  projectDeclarationContent = new BehaviorSubject<ProjectDeclaration[]>([]);

  private projectDeclarationList : ProjectDeclaration[] = [
    {id : '1', name : 'VHU8-2-a'},
    {id : '2', name : 'VAT08-2-a'},
    {id : '3', name : 'VHU8-2-b'},
    {id : '4', name : 'VHU8-2-x'}
  ]

  loadActivities(){
    this.activitiesContent.next(this.activitiesList);
  }

  loadCustomerMappingList(){
    this.customerMappingContent.next(this.customerMappingList);
  }

  loadProjectDeclaration(){
    this.projectDeclarationContent.next(this.projectDeclarationList);
  }
}
