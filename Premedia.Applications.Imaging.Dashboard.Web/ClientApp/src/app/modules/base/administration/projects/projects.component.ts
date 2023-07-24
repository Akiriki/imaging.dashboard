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

  //@ViewChild('listbox') listbox!: ListBoxComponent;

  btnclick() {
    if (this.newInputValue.trim() !== '') {
      const newItems = this.newInputValue
        .split(',') // Split input into individual items using commas as the separator
        .map(item => item.trim()) // Trim whitespace from each item
        .filter(item => item !== ''); // Remove empty items

      this.data.push(...newItems.map(text => ({ text })));
      this.newInputValue = '';
    }
   /*if(this.listbox){
    let addItem: { [key: string]: Object }[] = [
      { text: this.newInputValue}
    ];
      this.listbox.addItems(addItem);
   }
   console.log(this.newInputValue);
   this.newInputValue = '';
   */
  }
}

