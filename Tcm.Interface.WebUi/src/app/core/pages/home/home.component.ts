import { Component, OnInit } from '@angular/core';

import { AuthService } from 'src/app/authentication/services';
import { CorporateService } from 'src/app/corporate/services';


@Component({
  selector: 'page-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  ngOnInit(): void {

  }


  constructor(private httpService: CorporateService, private authService: AuthService) {


  }

  getCars(): any {

    //this.httpService.getAll().subscribe();

    this.httpService.add(Object).subscribe(function (res) {
      console.log(res);
    });

    //this.httpService.get(41).subscribe(res=> this.car = res);
    //this.httpService.update(41,this.car).subscribe();
  }

  isLoggedIn(): boolean{
    return this.authService.isLoggedIn();
  }

  logOut(): any {
    this.authService.signOut();
  }
  getClaims(): any {
    let item = this.authService.getClaims();
    console.log(item);

  }

}
