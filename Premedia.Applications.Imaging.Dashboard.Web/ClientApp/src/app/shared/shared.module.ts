import {NgModule} from "@angular/core";
import {AppRoutingModule} from '../app-routing.module';
import {FormsModule} from '@angular/forms';
import {CommonModule} from '@angular/common';
import {DestroySubscriptionsComponent} from './destroy-subscriptions/destroy-subscriptions.component';
import { GridModule } from "@syncfusion/ej2-angular-grids";

@NgModule({
  declarations: [DestroySubscriptionsComponent],
  imports: [AppRoutingModule, FormsModule, CommonModule, GridModule],
  exports: [AppRoutingModule, FormsModule, CommonModule]
})

export class SharedModule {}
