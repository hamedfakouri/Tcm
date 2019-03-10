import { Injectable } from '@angular/core';
import { User } from '../models/login';
import { HttpService } from 'src/app/shared/services';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class AccountService extends HttpService<User>  {

  constructor(private httpClient :HttpClient){
    super(httpClient);
    this.endpoint = "Account";
    this.url = this.baseUrl + "/api/" + this.endpoint+"/"

}

  login(user:User) : Observable<any>{
    return this.httpClient.post(this.url+"login", user);
  }

  getRoles():Observable<any>{
    return this.httpClient.get(this.url+"GetRoles");
  }
}
