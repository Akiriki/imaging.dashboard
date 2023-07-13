import { Component, Inject } from '@angular/core';
import { ItemModel } from '@syncfusion/ej2-angular-splitbuttons';

@Component({
  selector: 'app-administration-actions',
  templateUrl: './administration-actions.component.html',
  styleUrls: ['./administration-actions.component.scss'],
  providers: [
    { provide: 'sourceFiles', useValue: { files: ['administration-actions.component.scss'] } }
  ]
})
export class AdministrationActionsComponent {
  constructor(@Inject('sourceFiles') private sourceFiles: any) {
    sourceFiles.files = ['administration-actions.component.scss'];
}

//DropDownButton items definition
public items: ItemModel[] = [
   {
       text: 'Aktivitäten'
       //iconCss: 'e-ddb-icons e-dashboard'
   },
   {
       text: 'Kunden-Mapping'
       //iconCss: 'e-ddb-icons e-settings',
   },
   {
       text: 'Projektanlage'
       //iconCss: 'e-ddb-icons e-logout'
   }];
}
