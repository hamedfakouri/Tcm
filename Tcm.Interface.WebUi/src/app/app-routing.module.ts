import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { AuthGuardService } from './authentication/services';



export const routes: Routes = [
  {path:'educationLevel',loadChildren:'./pages/baseInfo/educationLevel/education-level.module#EducationLevelModule'},
  {path:'account',loadChildren:'./pages/account/account.module#AccountModule'},

  { path: '', pathMatch: 'full', component: DashboardComponent, canActivate: [AuthGuardService] },
  { path: 'home', component: DashboardComponent, canActivate: [AuthGuardService] },

];

