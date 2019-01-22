import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/authentication/services';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {


  
  constructor(private authService:AuthService) { }

  ngOnInit() {

  
  }

get authenticated(){
return this.authService.isLoggedIn();

}

  login():void{

  }

  isAdmin():boolean{

    return false;
  }
  

  logout():void{
    
  }
}
