import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot,CanActivateChild } from '@angular/router';


import { AuthService } from './auth.service'
import { Permission } from 'src/app/core/models';
import { PermissionService } from './permission.service';


console.log("AuthGuardService bundled------------------------------------------");

@Injectable()
export class AuthGuardService implements CanActivate , CanActivateChild{
  

  private permission:Permission= new Permission();
  constructor(private authService: AuthService ,private permissionService:PermissionService) { 
    
  }
  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean  {


      if(this.authService.isLoggedIn()) { 
        return true;
      }      
      
       return false;
     
  }
  canActivateChild(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean  {
          
   
    if(route.data.permission){
      this.permission.subject = route.data.permission.subject;
      this.permission.task = route.data.permission.task;
      return this.permissionService.HasPermission(this.permission.subject,this.permission.task);   
    }

    return false;
       
  
}

}
