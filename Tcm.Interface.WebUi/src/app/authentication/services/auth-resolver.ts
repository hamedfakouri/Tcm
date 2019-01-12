import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class AuthResolve implements Resolve<string> {

  constructor(private auth: AuthService) {}

  resolve(route: ActivatedRouteSnapshot) {
    //return this.auth.user;
    return "";
  }
}