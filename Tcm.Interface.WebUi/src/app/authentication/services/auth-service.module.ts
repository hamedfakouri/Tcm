import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {AuthService,AuthInterceptor,AuthInterceptorProviderService,AuthResolve,AuthGuardService} from './index'
import { HttpService } from '../../core/services';
import { UserService } from 'src/app/user/services';




@NgModule({
  imports: [CommonModule],
  declarations: [],
  providers:[HttpService,AuthService,AuthGuardService,AuthInterceptor,AuthInterceptorProviderService,AuthResolve,UserService
  ]
})
export class AuthServiceModule {
  constructor(){
    console.log("------------------------AuthServiceModule-------------")
  }
 }
