import { Component, OnInit } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { Router, Route } from '@angular/router';
@Component({
  selector: 'app-dashboard-admin',
  templateUrl: './dashboard-admin.component.html'
})
export class DashboardAdminComponent implements OnInit {

  constructor(private router:Router) 
  {
    var routes= this.router.config;
    console.log(routes);
   }

  ngOnInit() {
  }

}
