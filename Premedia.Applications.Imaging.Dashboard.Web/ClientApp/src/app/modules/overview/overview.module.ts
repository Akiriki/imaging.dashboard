import {NgModule} from "@angular/core";
import {SharedModule} from "../../shared/shared.module";
import {RouterLink, RouterLinkActive} from '@angular/router';
import {NgClass, NgIf} from '@angular/common';
import { OverviewComponent } from './overview/overview.component';
import { OpenJobsComponent } from './overview/open-jobs/open-jobs.component';
import { MyTasksComponent } from './overview/my-tasks/my-tasks.component';
import { ColleaguesTasksComponent } from './overview/colleagues-tasks/colleagues-tasks.component';
import { AllPartnerFilesComponent } from './overview/all-partner-files/all-partner-files.component';
import { AllCorruptedFilesComponent } from './overview/all-corrupted-files/all-corrupted-files.component';
import { OverviewService } from "src/app/services/overview.service";

@NgModule({
  declarations: [
    OverviewComponent,
    OpenJobsComponent,
    MyTasksComponent,
    ColleaguesTasksComponent,
    AllPartnerFilesComponent,
    AllCorruptedFilesComponent
  ],
  imports: [
    SharedModule
  ],
  exports: [

  ]
})
export class OverviewModule {}
