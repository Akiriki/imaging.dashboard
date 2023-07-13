import { Component } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { AdministrationService, CustomerMapping } from 'src/app/services/administration.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-customer-mapping',
  templateUrl: './customer-mapping.component.html',
  styleUrls: ['./customer-mapping.component.scss']
})
export class CustomerMappingComponent extends DestroySubscriptionsComponent{
  customerMappingList : CustomerMapping[] = [];
  pageSettings: PageSettingsModel;

  constructor(public administrationService : AdministrationService) {
    super();
    this.setNewSubscription = administrationService.customerMappingContent.subscribe((customerMappingContent) => {
      this.customerMappingList = customerMappingContent
    })
    this.pageSettings = {pageSize : administrationService.pageSettings.pageSize}
    administrationService.loadCustomerMappingList();
  }
}
