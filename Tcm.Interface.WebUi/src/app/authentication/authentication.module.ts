import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthenticationRoutingModule } from './authentication-routing.module';
import { AuthCallbackComponent } from './components/auth-callback/auth-callback.component';
import { AuthServiceModule } from './services/auth-service.module';
import { UserServiceModule } from '../user/services/user-service.module';

@NgModule({
  imports: [
    CommonModule,
    AuthenticationRoutingModule,
    AuthServiceModule,
    UserServiceModule
  ],
  declarations: [AuthCallbackComponent]
})
export class AuthenticationModule {

  constructor(){
    console.log("-----------------------AuthenticationModule---------------------------")
  }
 }
