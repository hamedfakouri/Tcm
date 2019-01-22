import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/authentication/services';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'page-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  ngOnInit(): void {

  } 
  constructor(private authService:AuthService) {
  }
 
 getCars():any{

    //this.httpService.getAll().subscribe();

    // this.httpService.add(Object).subscribe(function(res){
    //   console.log(res);
    // });
    //this.httpService.get(41).subscribe(res=> this.car = res);
    //this.httpService.update(41,this.car).subscribe();
  }

  logOut():any{
    this.authService.signOut();
  }
  getClaims():any{
   let item= this.authService.getClaims();
   console.log(item);

  }

}
