import { Routes, RouterModule } from "@angular/router";
import { DashboardAdminComponent } from "./page";
import { NgModule } from "@angular/core";

const dashboardRoute :  Routes =[
{
    path:'',
    component : DashboardAdminComponent
}

]


  
@NgModule({
    imports: [
      RouterModule.forChild(
        dashboardRoute,
      
      )
      // other imports here
    ]
  })
  export class DashboardRouteModule { 
    constructor(){
        console.log("--------------------------------DashboardRouteModule-------------------------------")
      }
  }