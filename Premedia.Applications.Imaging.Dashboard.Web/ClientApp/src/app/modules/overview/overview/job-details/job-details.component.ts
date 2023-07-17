import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { HistoryInfo, JobFiles, OverviewService } from 'src/app/services/overview.service';

@Component({
  selector: 'app-job-details',
  templateUrl: './job-details.component.html',
  styleUrls: ['./job-details.component.scss']
})
export class JobDetailsComponent {
  jobID : string | undefined;
  jobFilesList : JobFiles[] = [];
  historyList : HistoryInfo[] = [];
  pageSettings: PageSettingsModel;

  constructor(private route : ActivatedRoute, overviewService : OverviewService){
    overviewService.jobFiles.subscribe((jobFiles) => {
      this.jobFilesList = jobFiles
    })

    overviewService.history.subscribe((history) => {
      this.historyList = history
    })

    this.pageSettings = { pageSize : overviewService.pageSettings.pageSize}

    overviewService.loadJobFiles();
    overviewService.loadHistory();
   }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.jobID = params['id'];
      console.log('Job ID:', this.jobID);
    });
  }
}
