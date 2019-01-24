import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/Auth/login/login.component';
import { EducationCourseComponent } from './pages/baseInfo/educationCourse/educationCourse.component';
import { AuthGuardService } from './authentication/services';
import { CorporateListComponent } from './pages/corporate/pages';
import { EducationLevelComponent } from './pages/baseInfo/educationLevel/educationlevel.component';


export const routes: Routes = [
  { path: 'Auth/Login', component: LoginComponent },

  { path: '', pathMatch: 'full', component: DashboardComponent, canActivate: [AuthGuardService] },
  { path: 'home', component: DashboardComponent, canActivate: [AuthGuardService] },
  { path: 'BaseInfo/EducationCourse', component: EducationCourseComponent, canActivate: [AuthGuardService] },
  { path: 'BaseInfo/EducationLevel', component: EducationLevelComponent, canActivate: [AuthGuardService] },
  { path: 'corporate/list', component: CorporateListComponent },

];

