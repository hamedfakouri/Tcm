import { Injectable, OnInit } from '@angular/core';
// import { UserManager, UserManagerSettings, User } from 'oidc-client';
import { UserInfo } from 'src/app/user/models/User'
import { UserService } from './../../user/services/user.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { tokenGetter } from 'src/app/app.module';

@Injectable()
export class AuthService {

  // private manager: UserManager = new UserManager(getClientSettings());
  // public user: User = null;
  public userInfo: UserInfo = new UserInfo();
  // public postBackRedirect: string;

  jwtHelper = new JwtHelperService();
  
  constructor(private userService: UserService) {
    // this.manager.getUser().then(user=> this.user = user); 
    localStorage.setItem('token', this.getAuthorizationHeaderValue());
  }

  decodedToken(){
    return this.jwtHelper.decodeToken(this.getAuthorizationHeaderValue());
  }

  isLoggedIn(): boolean {
    // return this.user != null && !this.user.expired;
    return !this.jwtHelper.isTokenExpired(this.getAuthorizationHeaderValue());
  }

  getClaims(): any {
    return this.decodedToken().Role;
  }

  getAuthorizationHeaderValue(): string {

    if(localStorage.getItem('token') == null)
      return '';

    return localStorage.getItem('token');
  }
  
  setAuthorizationHeaderValue(token:string):void{
    localStorage.setItem('token',token);
    this.decodedToken = this.jwtHelper.decodeToken(token);
  }

  getRole() {

    //return this.user.profile.role;
    return this.decodedToken().Role;
  }


  signOut(): void {

    localStorage.removeItem('token');

  }


}

// export function getClientSettings(): UserManagerSettings {
//   return {
//     authority: 'http://localhost:5000/',
//     client_id: 'angular_spa',
//     redirect_uri: 'http://localhost:4300/auth-callback',
//     post_logout_redirect_uri: 'http://localhost:4300/logout',
//     response_type: "id_token token",
//     scope: "openid profile api1",
//     filterProtocolClaims: true,
//     loadUserInfo: false,
//     automaticSilentRenew: false,
//     silent_redirect_uri: 'http://localhost:4300/silent-refresh.html'
//   };
// }
