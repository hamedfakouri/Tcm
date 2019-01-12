import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/authentication/services';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {


  authenticated:boolean =false;
  name : string='';
  constructor(private authService:AuthService) { 
   
  }

  ngOnInit() {
    if(this.authService.isLoggedIn()){
      this.name = this.authService.decodedToken().GivenName;
    }
  }

  login():void{
    const token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE1NDcwNjY1NTgsImV4cCI6MTU3ODYwMjU1OCwiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.5RdRE874nH0JtqZsEXfCykovED_bPmnuq4lVpAIg5WY";
    this.authService.setAuthorizationHeaderValue(token);
    //this.name = this.authService.decodedToken().GivenName;
    console.log(this.authService);
    console.log(this.authService.decodedToken);
  }

  isAdmin():boolean{

    return false;
  }

  isloggedIn(): boolean{
    return this.authService.isLoggedIn();
  }
  

  logout():void{
    this.authService.signOut();
  }
}
