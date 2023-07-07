import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import {BaseModule} from "./modules/base/base.module";
import {AppRoutingModule} from "./app-routing.module";
import {environment} from '../environments/environment';
import {API_BASE_URL} from './core/NSwagDataClient';
import {FetchDataService} from './services/fetch-data.service';
import { GridModule, PagerModule, PageService, SortService, FilterService } from '@syncfusion/ej2-angular-grids';
import { OverviewModule } from './modules/overview/overview.module';
import { AllCorruptedFilesComponent } from './modules/overview/overview/all-corrupted-files/all-corrupted-files.component';
import { OverviewService } from './services/overview.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    BaseModule,
    AppRoutingModule,
    BrowserModule,
    GridModule
  ],
  providers: [
    HttpClientModule,
    FetchDataService,
    {
      provide: API_BASE_URL,
      useValue: environment.apiRoot
    },
    OverviewService,
    PageService,
    SortService,
    FilterService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
