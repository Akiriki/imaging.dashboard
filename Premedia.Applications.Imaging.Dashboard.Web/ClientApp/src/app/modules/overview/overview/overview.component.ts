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
  firstLoadCompleted : boolean = true;

  constructor(public overviewService : OverviewService){
    super();
  }

  ngOnInit(){
    this.loadData();
  }

  ngOnDestroy() {
    clearInterval(this.refreshInterval);
  }

  // Methode zum Laden der Daten
  loadData(){
    // daten manuell laden
    this.refreshTables();

    this.refreshInterval = setInterval(() => {
      this.refreshTables();
    }, 10000); // 10 Sekunden (10000 Millisekunden)
  }

  refreshTables(){
    // Startseite
    this.overviewService.loadOpenJobs();
    this.overviewService.loadMyTasks();
    this.overviewService.loadColleaguesTasks();
    this.overviewService.loadAllPartnerFiles();

    console.log('refreshing...');
  }
}
