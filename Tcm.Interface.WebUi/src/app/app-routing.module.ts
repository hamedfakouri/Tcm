import { Routes } from '@angular/router';
import { AuthGuardService } from './authentication/services';


export const routes: Routes = [

  { path: 'Account/login', loadChildren: './pages/account/account.module#AccountModule' },

  { path: '', loadChildren: './pages/dashboard/dashboard.module#DashboardModule', canActivate: [AuthGuardService] },
  { path: 'EducationLevel', loadChildren: './pages/baseInfo/educationLevel/educationlevel.module#EducationLevelModule' },
  { path: 'EducationCourse', loadChildren: './pages/baseInfo/educationCourse/educationcourse.module#EducationCourseModule' },
  { path: 'EducationSubCourse', loadChildren: './pages/baseInfo/educationSubCourse/educationsubcourse.module#EducationSubCourseModule' },
  { path: 'Major', loadChildren: './pages/baseInfo/major/major.module#MajorModule' },

];

