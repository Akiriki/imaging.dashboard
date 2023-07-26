import { Component, ViewChild } from '@angular/core';
import { getInstance } from '@syncfusion/ej2-base';
import { ListBox } from '@syncfusion/ej2-dropdowns';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { AdministrationService, ProjectDeclaration } from 'src/app/services/administration.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';
import { ListBoxComponent } from '@syncfusion/ej2-angular-dropdowns';

@Component({
  selector: 'app-container',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.scss']
})
export class ProjectsComponent extends DestroySubscriptionsComponent{
  public data: { [key: string]: Object }[] = [];
  public newInputValue: string = '';

  addItems() {
    if (this.newInputValue.trim() !== '') {
      const newItems = this.newInputValue
        .split(/\r?\n/)
        .map(item => item.trim())
        .filter(item => item !== '');

      this.data.push(...newItems.map(text => ({ text })));
      this.newInputValue = '';
    }

    console.log(this.data);

  }
}

