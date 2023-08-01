import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  Input,
  OnInit,
  ViewChild,
} from '@angular/core';
import {
  EditSettingsModel,
  PageSettingsModel,
  SaveEventArgs,
} from '@syncfusion/ej2-angular-grids';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { EmitType } from '@syncfusion/ej2-base';
import {
  ActivityReadModel,
  CreateActivityCommand,
  JobReadModel,
  UpdateActivityCommand,
} from 'src/app/core/NSwagDataClient';
import { AdministrationService } from 'src/app/services/administration.service';
import { DestroySubscriptionsComponent } from 'src/app/shared/destroy-subscriptions/destroy-subscriptions.component';
import { GridComponent } from '@syncfusion/ej2-angular-grids';

interface ActivityData {
  id: string;
  customer: string;
  serviceType: string;
  quality: string;
}

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.scss'],
})
export class ActivitiesComponent
  extends DestroySubscriptionsComponent
  implements OnInit
{
  [x: string]: any;
  activitiesList: ActivityReadModel[] = [];
  pageSettings: PageSettingsModel;

  constructor(
    public administrationService: AdministrationService,
    private changeDetector: ChangeDetectorRef
  ) {
    console.log('const');
    super();
    this.edit = false;
    this.setNewSubscription = administrationService.activitiesContent.subscribe(
      (activitiesContent) => {
        this.activitiesList = activitiesContent;
      }
    );
    this.pageSettings = {
      pageSize: administrationService.pageSettings.pageSize,
    };
    administrationService.loadActivities();
  }
  @ViewChild('ejDialog') ejDialog: DialogComponent | any;

  @ViewChild('container', { read: ElementRef }) container: ElementRef | any;

  @ViewChild('grid')
  public grid: GridComponent | undefined;


  public targetElement?: HTMLElement;
  public dialogVisible: boolean = false;
  public dialogWidth: string = '500px';
  public defaultCustomer = '';
  public defaultServiceType = '';
  public defaultQuality = '';
  public index: string = '';
  public edit;

  ngOnInit() {}

  ngAfterViewInit() {
    this.initializeTarget();
  }

  public initializeTarget: EmitType<object> = () => {
    this.targetElement = this.container.nativeElement.parentElement;
  };

  public hideDialog: EmitType<object> = () => {
    this.dialogVisible = false;
    this.ejDialog.hide();
  };
  public buttons: Object = [
    {
      click: this.hideDialog.bind(this),
      buttonModel: {
        content: 'Abbrechen',
        isPrimary: false,
      },
    },
    {
      click: this.saveData.bind(this),
      buttonModel: {
        content: 'Speichern',
        isPrimary: true,
        cssClass: 'saveButton',
      },
    },
  ];
  public onOpenDialog(): void {
    this.edit = false;
    this.dialogVisible = true;
    this.ejDialog.show();
  }
  public saveData(): void {
    const customer = (<HTMLInputElement>document.getElementById('customer'))
      .value;
    const serviceType = (<HTMLInputElement>(
      document.getElementById('serviceType')
    )).value;
    const quality = (<HTMLInputElement>document.getElementById('quality'))
      .value;

    if (this.edit) {
      if (this.index) {
        console.log(this.selectedData);
        const updateActivityCommand: UpdateActivityCommand =
          new UpdateActivityCommand();
        updateActivityCommand.id = this.index;
        updateActivityCommand.customer = customer;
        updateActivityCommand.serviceType = serviceType;
        updateActivityCommand.quality = quality;
        this.administrationService
          .updateActivity(updateActivityCommand)
          .subscribe(
            (updatedActivity) => {
              console.log(updatedActivity);
              this.activitiesList.map((x) => {
                if (x.id === this.index) {
                  x.customer = updateActivityCommand.customer;
                  x.serviceType = updateActivityCommand.serviceType;
                  x.quality = updateActivityCommand.quality;
                }

                return x;
              });
              console.log(this.activitiesList);
              this.activitiesList = [...this.activitiesList]
              this.changeDetector.markForCheck();
            },
            (error) => {
              console.error('Fehler beim Ändern der Aktivität: ', error);
            }
          );
      }
    } else {
      const createActivityCommand: CreateActivityCommand =
        new CreateActivityCommand();
      createActivityCommand.id = crypto.randomUUID();
      createActivityCommand.customer = customer;
      createActivityCommand.serviceType = serviceType;
      createActivityCommand.quality = quality;
      this.administrationService
        .createActivity(createActivityCommand)
        .subscribe(
          (createdActivity) => {
            this.activitiesList.push(createdActivity);
          },
          (error) => {
            console.error('Fehler beim Erstellen der Aktivität: ', error);
          }
        );
    }

    console.log('Customer:', customer);
    console.log('Service Type:', serviceType);
    console.log('Quality:', quality);
    this.ejDialog.hide();
  }

  public editActivities(data: ActivityReadModel): void {
    console.log(data);
    this.index = data.id ?? '';

    this.edit = true;
    this.defaultCustomer = data.customer??"";
    this.defaultServiceType = data.serviceType??"";
    this.defaultQuality = data.quality??"";

    if (this.ejDialog) {
      this.ejDialog.show();
    }
  }

  public removeActivity(data: ActivityReadModel): void{
    this.index = data.id ?? '';

    this.administrationService.deleteActivity(this.index).subscribe(
      () => {
        console.log(this.index);
        this.activitiesList = this.activitiesList.filter(
          (activity) => activity.id !== this.index
        );
        console.log(this.index);
        this.activitiesList = [...this.activitiesList];
        this.changeDetector.markForCheck();
      },
      (error) => {
        console.error('Fehler beim Löschen der Aktivität: ', error);
      }
    );

  }


}
