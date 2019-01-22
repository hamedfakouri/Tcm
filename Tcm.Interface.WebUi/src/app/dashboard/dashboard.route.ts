import { Routes, RouterModule } from "@angular/router";
import { DashboardAdminComponent } from "./page";
import { NgModule } from "@angular/core";
import { SubjectType } from "../core/models/subject-type.enum";
import { TaskType } from "../core/models/task-type.enum";
import { AuthGuardService } from "../authentication/services";
import { RoleType } from "../core/models/role-type.enum";

const dashboardRoute :  Routes =[
{
    path:'admin',
    component : DashboardAdminComponent,
    data: {title:' ادمین', permission:{ subject: SubjectType.corporate , task:TaskType.add} } 
}
]

  
@NgModule({
    imports: [
      RouterModule.forChild(
        dashboardRoute,      
      )
      
    ]
  })
  export class DashboardRouteModule { 
    constructor(){
        console.log("----------------------------DashboardRouteModule--------------------------")
      }
  }