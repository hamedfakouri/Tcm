import { Component, OnInit } from '@angular/core';
import { User } from '../../models/login';
import { AccountService } from '../../services/account.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})


export class RegisterComponent extends CrudComponent<User> implements  OnInit {


  public subject: string = "account";
  public roles:Array<Role> = new Array<Role>();
  constructor( private service: AccountService,route: ActivatedRoute,
  router: Router) {
    super(service,route,router);
   }

  ngOnInit() {

    this.item = new User();
    this.getRoles();
   

    this.route.params.subscribe(params => {
      if(params){
        this.Id = +params['id'];
      }});

    if(this.Id==2){
      this.item.roleName ="Student";
      this.Id=0;
    }
  }

  getRoles(){
    this.service.getRoles().subscribe(res=> this.roles = res);

  }

 

}
