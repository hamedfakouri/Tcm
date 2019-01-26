import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRouteModule } from './dashboard.route';
import { SharedModule } from 'src/app/shared/shared.module';
import { DashboardComponent } from './pages/dashboard.component';
console.log("--------------------------------DashboardModulebundled--------------------")

@NgModule({
  imports: [
    CommonModule,
    DashboardRouteModule,
    SharedModule
  ],
  declarations: [DashboardComponent]
})
export class DashboardModule { 
  constructor(){
    console.log("--------------------------------DashboardModule-------------------------------")
  }
}
