import { Component, Inject } from '@angular/core';
import { ItemModel, MenuEventArgs } from '@syncfusion/ej2-angular-splitbuttons';

@Component({
  selector: 'app-user-actions',
  templateUrl: './user-actions.component.html',
  styleUrls: ['./user-actions.component.scss'],
  providers: [
    { provide: 'sourceFiles', useValue: { files: ['user-actions.component.scss'] } }
  ]
})
export class UserActionsComponent {
  constructor(@Inject('sourceFiles') private sourceFiles: any) {
    sourceFiles.files = ['user-actions.component.scss'];
}

//DropDownButton items definition
public items: ItemModel[] = [
   {
       text: 'Dashboard',
       iconCss: 'e-ddb-icons e-dashboard'
   },
   /*{
       text: 'Notifications',
       iconCss: 'e-ddb-icons e-notifications',
   }, */
   {
       text: 'User Settings',
       iconCss: 'e-ddb-icons e-settings',
   },
   {
       text: 'Log Out',
       iconCss: 'e-ddb-icons e-logout'
   }];
}
