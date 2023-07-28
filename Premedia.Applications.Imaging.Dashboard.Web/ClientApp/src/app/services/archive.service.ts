import * as DataClient from '../core/NSwagDataClient';
import {Injectable} from '@angular/core';
import { DataResult, PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import {BehaviorSubject} from 'rxjs';

@Injectable()
export class ArchiveService{

  archiveContent = new BehaviorSubject<DataClient.JobReadModel[]>([]);

  public pageSettings : PageSettingsModel = { pageSize : 10 };

  constructor(private jobDataClient : DataClient.JobClient){ }

  loadArchive(){
    this.jobDataClient.getDoneJobs().subscribe(result => {
      this.archiveContent.next(result);
    }, error => console.error(error));
  }
}
