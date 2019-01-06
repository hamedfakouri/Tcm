import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {AuthGuardService} from './../authentication/services';
import { ProtectedComponent } from './pages';

const routes: Routes = [
  
  {
      path: 'protected',
      component: ProtectedComponent,    
     
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CoreRoutingModule { }
