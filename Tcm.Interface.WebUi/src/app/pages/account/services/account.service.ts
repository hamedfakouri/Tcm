import { Injectable } from '@angular/core';
import { Login } from '../models/login';
import { HttpService } from 'src/app/shared/services';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class AccountService extends HttpService<Login>  {

  constructor(private httpClient: HttpClient) {
    super(httpClient);
    this.endpoint = "/api/account/";
  }


  login(user:Login) : Observable<any>{
    return this.httpClient.post(this.baseUrl + this.endpoint + "login" , user);
  }
}
