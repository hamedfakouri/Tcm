import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardAdminComponent } from './page';
import { DashboardRouteModule } from './dashboard.route';
import { SharedModule } from '../shared/shared.module';
console.log("--------------------------------DashboardModulebundled--------------------")

@NgModule({
  imports: [
    CommonModule,
    DashboardRouteModule,
    SharedModule
  ],
  declarations: [DashboardAdminComponent]
})
export class DashboardModule { 
  constructor(){
    console.log("--------------------------------DashboardModule-------------------------------")
  }
}
