import { Component } from '@angular/core';
import { OverviewService } from 'src/app/services/overview.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.scss']
})
export class OverviewComponent extends DestroySubscriptionsComponent{

  refreshInterval : any

  constructor(public overviewService : OverviewService){
    super();
  }

  ngOnInit(){
    // für das Refreshing der Tabellen
    this.refreshInterval = setInterval(() => {
      this.refreshTables();
    }, 500); // alle 0,5 Sekunden
  }

  refreshTables(){
    this.overviewService.loadOpenJobs();
    this.overviewService.loadMyTasks();
    this.overviewService.loadColleaguesTasks();
    this.overviewService.loadAllPartnerFiles();
  }

}
