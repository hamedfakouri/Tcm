import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreRoutingModule } from './core-routing.module';
import { CoreServiceModule } from './services/core-service.module';
import {HomeComponent,LoginComponent,ProtectedComponent, FooterComponent, HeaderComponent,SliderComponent, AuthCallbackComponent} from './pages';
import { LogoutComponent } from './pages/logout/logout.component';
import { SharedModule } from '../shared/shared.module';
import { BreadCrumbComponent } from './components';

console.log("-----------------------CoreModulebundled-----------------")


@NgModule({
  imports: [
    CommonModule,
    CoreRoutingModule,
    CoreServiceModule,
    SharedModule
    
  ],
  declarations: [
     ProtectedComponent,
     HomeComponent,
     LoginComponent,
     LogoutComponent,
     FooterComponent,
     HeaderComponent,
     LoginComponent,
     SliderComponent,
     AuthCallbackComponent,
     BreadCrumbComponent
      ],
  exports:[ 
    ProtectedComponent,
    HomeComponent,
    LoginComponent,
    LogoutComponent,
    FooterComponent,
    HeaderComponent,
    LoginComponent,
    SliderComponent,
    AuthCallbackComponent,
    BreadCrumbComponent
  ],
  providers:[CoreServiceModule]
})
export class CoreModule  { 

constructor(){
  console.log("--------------------------------CoreModule-------------------------------")
}

}
