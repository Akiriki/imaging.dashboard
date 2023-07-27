import {NgModule} from "@angular/core";
import {AppRoutingModule} from '../app-routing.module';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {DestroySubscriptionsComponent} from './destroy-subscriptions/destroy-subscriptions.component';
import { GridModule } from "@syncfusion/ej2-angular-grids";
import { DropDownButtonAllModule, DropDownButtonModule } from "@syncfusion/ej2-angular-splitbuttons";
import { ButtonModule } from "@syncfusion/ej2-angular-buttons";
import { BrowserModule } from '@angular/platform-browser';
import { ListBoxModule } from '@syncfusion/ej2-angular-dropdowns';
import { DialogModule } from '@syncfusion/ej2-angular-popups';

@NgModule({
  declarations: [DestroySubscriptionsComponent],
  imports: [AppRoutingModule, FormsModule, CommonModule, GridModule, DropDownButtonModule, DropDownButtonAllModule, BrowserModule, ListBoxModule, DialogModule],
  exports: [AppRoutingModule, FormsModule, CommonModule, GridModule, DropDownButtonModule, ButtonModule, BrowserModule, ListBoxModule, DialogModule]
})

export class SharedModule {}
