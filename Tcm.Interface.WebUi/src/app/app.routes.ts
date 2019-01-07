import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { AuthGuardService } from './authentication/services';
import {AppComponent} from './app.component'
import { HomeComponent,LogoutComponent } from './core/pages';
const appRoutes: Routes = [
    {
      path: 'home',
      component: HomeComponent,
      data: { title: 'Heroes List' }
    }
   ,
    {
        path: 'dashboard',
        loadChildren:'./dashboard/dashboard.module#DashboardModule',
        canActivate:[AuthGuardService]
    }
    ,
    {
      path:'auth-callback',
      loadChildren:'./authentication/authentication.module#AuthenticationModule'
    }
    ,
    {
      path:'corporate',
      loadChildren:'./corporate/corporate.module#CorporateModule'
    }
    ,
    {
      path:'logout',
      component :LogoutComponent
    }
  ];
  
  @NgModule({
    imports: [
      RouterModule.forRoot(
        appRoutes,
        { enableTracing: true } // <-- debugging purposes only
      )
      // other imports here
    ]
  })
  export class AppRouteModule { }

