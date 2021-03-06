import { NgModule, ModuleWithProviders, SkipSelf, Optional } from '@angular/core';
import{AuthService,AuthInterceptor,AuthInterceptorProviderService,AuthResolve,AuthGuardService} from './index'
import { PermissionService } from './permission.service';

console.log("AuthServiceModule bundled------")


@NgModule({
  providers:[AuthService,AuthGuardService,AuthInterceptor,AuthInterceptorProviderService,AuthResolve,PermissionService]
})
export class AuthServiceModule {
  constructor (@Optional() @SkipSelf() parentModule: AuthServiceModule) {
    console.log("---------------------AuthenticationModule------------------------")

    if (parentModule) {
      throw new Error(
        'AuthenticationModule is already loaded. Import it in the AppModule only');
    }
  }

  static forRoot(): ModuleWithProviders  {
    return {
      ngModule: AuthServiceModule,
      providers: [      
      ]
    };
  }
 }

 
