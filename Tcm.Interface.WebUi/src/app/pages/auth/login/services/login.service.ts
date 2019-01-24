import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserForLogin } from '../models/userforlogin';
import { HttpService } from 'src/app/shared/services';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends HttpService<UserForLogin>  {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "/api/account/";
  }


  login(user:UserForLogin) : Observable<any>{
    return this.httpClient.post(this.baseUrl + this.endpoint + "login" , user);
  }
}

