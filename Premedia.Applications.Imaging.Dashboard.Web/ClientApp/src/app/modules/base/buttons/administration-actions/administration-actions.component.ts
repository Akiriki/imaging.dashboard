import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { ItemModel, MenuEventArgs } from '@syncfusion/ej2-angular-splitbuttons';

@Component({
  selector: 'app-administration-actions',
  templateUrl: './administration-actions.component.html',
  styleUrls: ['./administration-actions.component.scss'],
  providers: [
    { provide: 'sourceFiles', useValue: { files: ['administration-actions.component.scss'] } }
  ]
})
export class AdministrationActionsComponent {
  constructor(
    private router : Router,
    @Inject('sourceFiles') private sourceFiles: any
    )
    { sourceFiles.files = ['administration-actions.component.scss']; }

    public items: ItemModel[] = [
    {
        text: 'Aktivitäten',
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

    public select (args: MenuEventArgs) {
      if (args.item.text === 'Aktivitäten') {
        this.router.navigate(['/activities'])
      }
      else if (args.item.text === 'Kunden-Mapping') {
        this.router.navigate(['/customer-mapping'])
      }
      else if (args.item.text === 'Projektanlage') {
        this.router.navigate(['/projects'])
      }
    }
}
