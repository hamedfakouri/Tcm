import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardAdminComponent } from './page';
import { DashboardRouteModule } from './dashboard.route';

@NgModule({
  imports: [
    CommonModule,
    DashboardRouteModule

  ],
  declarations: [DashboardAdminComponent]
})
export class DashboardModule { 
  constructor(){
    console.log("--------------------------------DashboardModule-------------------------------")
  }
}
