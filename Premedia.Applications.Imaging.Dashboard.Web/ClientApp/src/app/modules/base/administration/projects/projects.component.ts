import { Component } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { AdministrationService, ProjectDeclaration } from 'src/app/services/administration.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent extends DestroySubscriptionsComponent{
  projectDeclarationList : ProjectDeclaration[] = [];
  pageSettings: PageSettingsModel;

  constructor(public administrationService : AdministrationService) {
    super();
    this.setNewSubscription = administrationService.projectDeclarationContent.subscribe((projectDeclarationContent) => {
      this.projectDeclarationList = projectDeclarationContent
    })
    this.pageSettings = {pageSize : administrationService.pageSettings.pageSize}
    administrationService.loadProjectDeclaration();
  }
}
