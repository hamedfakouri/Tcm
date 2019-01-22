import { Injectable  } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { AuthService } from './auth.service';
import { User } from 'src/app/core/models';



console.log("AuthResolve bundled------------------------------------------")

@Injectable({
  providedIn: 'root',

})
export class AuthResolve implements Resolve<User> {

  constructor(private auth: AuthService) {}

  resolve(route: ActivatedRouteSnapshot) {
    return "";
  }
}