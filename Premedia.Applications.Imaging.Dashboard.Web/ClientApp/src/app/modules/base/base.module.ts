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
import { ActivitiesComponent } from './administration/activities/activities.component';
import { CustomerMappingComponent } from './administration/customer-mapping/customer-mapping.component';
import { ProjectsComponent } from './administration/projects/projects.component';
import { AdministrationActionsComponent } from './buttons/administration-actions/administration-actions.component';
import { AlphaChannelComponent } from './buttons/alpha-channel/alpha-channel.component';

@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    CounterComponent,
    ArchiveComponent,
    UserActionsComponent,
    AcceptOrderComponent,
    ActivitiesComponent,
    CustomerMappingComponent,
    ProjectsComponent,
    AdministrationActionsComponent,
    AlphaChannelComponent
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
