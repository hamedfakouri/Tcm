import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/authentication/services';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {


  authenticated:boolean =false;
  constructor(private authService:AuthService) { }

  ngOnInit() {

    if(this.authService.isLoggedIn()){
      this.authenticated= true;
    }
  }

  login():void{
this.authService.startAuthentication();
  }

  isAdmin():boolean{

    return false;
  }
  

  logout():void{
    this.authService.signOut();
  }
}
