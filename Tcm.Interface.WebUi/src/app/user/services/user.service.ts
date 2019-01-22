import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


import { UserInfo } from '../models/User';
import { AuthService } from 'src/app/authentication/services';
import { HttpService } from 'src/app/shared/services';


@Injectable()
export class UserService extends HttpService<UserInfo> {
  

  userInfo:UserInfo;
  constructor(private httpClient :HttpClient,private authService:AuthService){
       super(httpClient);
       this.endpoint = "/api/users/";
       this.userInfo = new UserInfo();
       
  } 


  saveCurrentUser():Promise<UserInfo>{

    
    let userdata = this.authService.getClaims();
    this.userInfo = new UserInfo(userdata.sub,userdata.given_name);

     return  this.add(this.userInfo).toPromise();

  }

   

  
}