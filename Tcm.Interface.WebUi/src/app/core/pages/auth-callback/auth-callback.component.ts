import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/authentication/services';

console.log("AuthCallbackComponent bundled")

@Component({
  selector: 'page-auth-callback',
  templateUrl: './auth-callback.component.html'
})
export class AuthCallbackComponent implements OnInit {

  constructor(private authService: AuthService,private router :Router) { 

    console.log("--------------------AuthCallbackComponent-------------------------")
  }

    ngOnInit() {
    //  this.authService.completeAuthentication();
     
    //  this.router.navigate([this.authService.getPostBackRedirect()]);

  }
}
