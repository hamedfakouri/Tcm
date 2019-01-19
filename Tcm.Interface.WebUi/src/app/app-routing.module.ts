import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/Auth/login/login.component';
import { RegisterComponent } from './pages/Auth/register/register.component';
import { RequestPasswordComponent } from './pages/auth/request-password/request-password.component';
import { EducationCourseComponent } from './pages/baseInfo/educationCourse/educationCourse.component';


export const routes: Routes = [
  { path: '',component: DashboardComponent },
  { path: 'home',component: DashboardComponent },
  { path: 'Auth/Login',component:LoginComponent  },
  { path: 'Auth/Register',component:RegisterComponent },
  { path: 'Auth/RequestPassword',component:RequestPasswordComponent },
  { path: 'BaseInfo/EducationCourse',component:EducationCourseComponent },
];

