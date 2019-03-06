import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register.component';
import { AuthGuardService } from 'src/app/authentication/services';

const routes: Routes = [
  {path:'',component :LoginComponent},
  {path:'login',component :LoginComponent},
  {path:'register/:id',component :RegisterComponent , canActivate: [AuthGuardService]},
  {path:'register',component :RegisterComponent , canActivate: [AuthGuardService]}



];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
