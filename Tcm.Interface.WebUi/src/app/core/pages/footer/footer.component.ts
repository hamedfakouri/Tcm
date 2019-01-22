import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/authentication/services';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html'
})
export class FooterComponent implements OnInit {

  constructor(private authservice:AuthService) { }

  ngOnInit() {


    
  }

}
