import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';

import { AuthService } from './auth.service'
import { Observable } from "rxjs";

@Injectable()
export class AuthGuardService implements CanActivate {
  
  constructor(private authService: AuthService) { }
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {


      if(this.authService.isLoggedIn()) {

         return true;

      }

      this.authService.savePostBackRedirect(state.url);
      this.authService.startAuthentication();
      return false;
  }
}
