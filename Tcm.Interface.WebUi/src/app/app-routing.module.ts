import { Routes } from '@angular/router';
import { AuthGuardService } from './authentication/services';


export const routes: Routes = [

  { path: 'account', loadChildren: './pages/account/account.module#AccountModule' },

  { path: '', loadChildren: './pages/dashboard/dashboard.module#DashboardModule', canActivate: [AuthGuardService] },
  { path: 'educationYear', loadChildren: './pages/baseInfo/educationYear/educationyear.module#EducationYearModule', canActivate: [AuthGuardService] },
  { path: 'educationLevel', loadChildren: './pages/baseInfo/educationLevel/educationlevel.module#EducationLevelModule', canActivate: [AuthGuardService] },
  { path: 'EducationCourse', loadChildren: './pages/baseInfo/educationCourse/educationcourse.module#EducationCourseModule', canActivate: [AuthGuardService] },
  { path: 'EducationSubCourse', loadChildren: './pages/baseInfo/educationSubCourse/educationsubcourse.module#EducationSubCourseModule', canActivate: [AuthGuardService] },
  { path: 'Major', loadChildren: './pages/baseInfo/major/major.module#MajorModule' , canActivate: [AuthGuardService]},
  { path: 'SchoolType', loadChildren: './pages/baseInfo/schoolType/schooltype.module#SchoolTypeModule' , canActivate: [AuthGuardService]},
  { path: 'SchoolSubType', loadChildren: './pages/baseInfo/schoolSubType/schoolsubtype.module#SchoolSubTypeModule' , canActivate: [AuthGuardService]},
  { path: 'School', loadChildren: './pages/school/school.module#SchoolModule', canActivate: [AuthGuardService] },
  { path: 'ClassRoom', loadChildren: './pages/class/classroom/classroom.module#ClassRoomModule' , canActivate: [AuthGuardService]},
];

