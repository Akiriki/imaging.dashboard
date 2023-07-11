import {RouterModule, Routes} from "@angular/router";
import {HomeComponent} from "./modules/base/home/home.component";
import {CounterComponent} from "./modules/base/counter/counter.component";
import {FetchDataComponent} from "./modules/base/fetch-data/fetch-data.component";
import {NgModule} from "@angular/core";
import {RoutingConstants} from "./core/constants/routing.constants";
import { OverviewComponent } from "./modules/overview/overview/overview.component";
import { ArchiveComponent } from "./modules/base/archive/archive.component";
import { AdministrationComponent } from "./modules/base/administration/administration.component";

export const routes: Routes = [
  { path: RoutingConstants.BASE.HOME, component: OverviewComponent, pathMatch: 'full' },
  { path: RoutingConstants.BASE.COUNTER, component: CounterComponent },
  { path: RoutingConstants.BASE.FETCH_DATA, component: FetchDataComponent },
  { path: RoutingConstants.BASE.ARCHIVE, component: ArchiveComponent},
  { path: RoutingConstants.BASE.ADMINISTRATION, component: AdministrationComponent}
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
