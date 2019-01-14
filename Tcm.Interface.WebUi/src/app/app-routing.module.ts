import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';
import { LoginComponent } from './pages/Auth/login/login.component';
import { RegisterComponent } from './pages/Auth/register/register.component';


export const routes: Routes = [
  { path: '',component: DashboardComponent },
  { path: 'Auth/Login',component:LoginComponent  },
  { path: 'Auth/Register',component:RegisterComponent },
];

