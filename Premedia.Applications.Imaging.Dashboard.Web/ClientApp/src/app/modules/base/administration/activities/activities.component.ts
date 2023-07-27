import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { EmitType } from '@syncfusion/ej2-base';
import { Activities, AdministrationService } from 'src/app/services/administration.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.scss']
})

export class ActivitiesComponent extends DestroySubscriptionsComponent implements OnInit {
  activitiesList : Activities[] = [];
  pageSettings: PageSettingsModel;

  constructor(public administrationService : AdministrationService) {
    super();
    this.setNewSubscription = administrationService.activitiesContent.subscribe((activitiesContent) => {
      this.activitiesList = activitiesContent
    })
    this.pageSettings = {pageSize : administrationService.pageSettings.pageSize}
    administrationService.loadActivities();

  }
  @ViewChild('ejDialog') ejDialog: DialogComponent | any;

  @ViewChild('container', { read: ElementRef }) container: ElementRef |any;



  public targetElement?: HTMLElement;
  public defaultCustomer = '';
  public defaultServiceType = '';
  public defaultQuality = '';
  public edit = false;

  ngOnInit() {
  }

  ngAfterViewInit() {
    this.initializeTarget();
  }

  public initializeTarget: EmitType<object> = () => {
    this.targetElement = this.container.nativeElement.parentElement;
  }


  public hideDialog: EmitType<object> = () => {
      this.ejDialog.hide();
  }
  public buttons: Object = [
    {
      'click': this.hideDialog.bind(this),
        buttonModel:{
        content:'Abbrechen',
        isPrimary:false
      }
    },
      {
        'click': this.saveData.bind(this),
          buttonModel:{
          content:'Speichern',
          isPrimary:true
        }
      }

  ];
  public onOpenDialog(): void {
    this.edit=false;
    this.ejDialog.show();
  }
  public saveData(): void {
    const customer = (<HTMLInputElement>document.getElementById('customer')).value;
    const serviceType = (<HTMLInputElement>document.getElementById('serviceType')).value;
    const quality = (<HTMLInputElement>document.getElementById('quality')).value;

    if(this.edit){
      //UpdateActivity
    }
    else{
      //CreateActivity
    }

    console.log('Customer:', customer);
    console.log('Service Type:', serviceType);
    console.log('Quality:', quality);
    this.ejDialog.hide();

  }

  public editActivities(): void {
    this.edit=true;
    this.defaultCustomer = 'XXLAT';
    this.defaultServiceType = 'Bearbeitung HQ eciRGB v2';
    this.defaultQuality = 'HQ';
    if (this.ejDialog) {
      this.ejDialog.show();
    }
  }

}
