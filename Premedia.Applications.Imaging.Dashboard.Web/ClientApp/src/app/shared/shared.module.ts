import {NgModule} from "@angular/core";
import {AppRoutingModule} from '../app-routing.module';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {DestroySubscriptionsComponent} from './destroy-subscriptions/destroy-subscriptions.component';
import { GridModule } from "@syncfusion/ej2-angular-grids";
import { DropDownButtonModule } from "@syncfusion/ej2-angular-splitbuttons";
import { ButtonModule } from "@syncfusion/ej2-angular-buttons";

@NgModule({
  declarations: [DestroySubscriptionsComponent],
  imports: [AppRoutingModule, FormsModule, CommonModule, GridModule, DropDownButtonModule, ButtonModule],
  exports: [AppRoutingModule, FormsModule, CommonModule, GridModule, DropDownButtonModule, ButtonModule]
})

export class SharedModule {}
