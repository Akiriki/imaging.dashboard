import {NgModule} from "@angular/core";
import {NavMenuComponent} from "./nav-menu/nav-menu.component";
import {HomeComponent} from "./home/home.component";
import {FetchDataComponent} from "./fetch-data/fetch-data.component";
import {CounterComponent} from "./counter/counter.component";
import {SharedModule} from "../../shared/shared.module";
import {RouterLink, RouterLinkActive} from '@angular/router';
import {NgClass, NgIf} from '@angular/common';
import { ArchiveComponent } from './archive/archive.component';
import { UserActionsComponent } from './buttons/user-actions/user-actions.component';
import { AcceptOrderComponent } from './buttons/accept-order/accept-order.component';
import { AdministrationComponent } from "./administration/administration.component";
import { ActivitiesComponent } from './administration/activities/activities.component';
import { CustomerMappingComponent } from './administration/customer-mapping/customer-mapping.component';

@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    CounterComponent,
    ArchiveComponent,
    AdministrationComponent,
    UserActionsComponent,
    AcceptOrderComponent,
    ActivitiesComponent,
    CustomerMappingComponent
  ],
  imports: [
    SharedModule
  ],
  exports: [
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    CounterComponent
  ]
})
export class BaseModule {}
