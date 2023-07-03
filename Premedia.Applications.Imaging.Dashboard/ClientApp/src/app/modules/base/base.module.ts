import {NgModule} from "@angular/core";
import {NavMenuComponent} from "./nav-menu/nav-menu.component";
import {HomeComponent} from "./home/home.component";
import {FetchDataComponent} from "./fetch-data/fetch-data.component";
import {CounterComponent} from "./counter/counter.component";
import {SharedModule} from "../../shared/shared.module";
import {RouterLink, RouterLinkActive} from '@angular/router';
import {NgClass, NgIf} from '@angular/common';

@NgModule({
  declarations: [
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    CounterComponent
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
