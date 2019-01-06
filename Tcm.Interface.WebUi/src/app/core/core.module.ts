import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoreRoutingModule } from './core-routing.module';


import { CoreServiceModule } from './services/core-service.module';
import {HomeComponent,LoginComponent,ProtectedComponent} from './pages';
import { LogoutComponent } from './pages/logout/logout.component';

@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    CoreServiceModule,
    
    
  ],
  declarations: [ ProtectedComponent,HomeComponent, LoginComponent, LogoutComponent],
  exports:[ ProtectedComponent,HomeComponent],
  providers:[]
})
export class CoreModule { 

constructor(){
  console.log("--------------------------------CoreModule-------------------------------")
}

}
