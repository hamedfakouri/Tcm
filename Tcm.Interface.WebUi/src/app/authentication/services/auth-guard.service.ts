import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';

import { AuthService } from './auth.service'
import { Observable } from "rxjs";

@Injectable()
export class AuthGuardService implements CanActivate {

  constructor(private authService: AuthService,private router: Router) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | Observable<boolean> | Promise<boolean> {

    // if (this.authService.isLoggedIn())
    //   return true;

    // this.router.navigate(['Auth/Login']);
    // return false;

    return true;
  }
}
