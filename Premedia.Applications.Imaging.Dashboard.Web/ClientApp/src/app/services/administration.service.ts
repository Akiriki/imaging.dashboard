import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';

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
  public pageSettings : PageSettingsModel = { pageSize : 5 };

  activitiesContent = new BehaviorSubject<DataClient.ActivityReadModel[]>([]);

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

  constructor(private activitiesDataClient: DataClient.ActivityClient){

  }

  loadActivities(){
    this.activitiesDataClient.getAllActivities().subscribe(result => {
      this.activitiesContent.next(result);
    }, error => console.error(error))
  }

  loadCustomerMappingList(){
    this.customerMappingContent.next(this.customerMappingList);
  }

  loadProjectDeclaration(){
    this.projectDeclarationContent.next(this.projectDeclarationList);
  }

  createActivity(createActivityCommand: DataClient.CreateActivityCommand) {
    return this.activitiesDataClient.createActivity(createActivityCommand);
  }

  updateActivity(updateActivityCommand: DataClient.UpdateActivityCommand) {
    return this.activitiesDataClient.updateActivity(updateActivityCommand);
  }

  deleteActivity(activityId: string) {
    return this.activitiesDataClient.deleteActivity(activityId);
  }
}
