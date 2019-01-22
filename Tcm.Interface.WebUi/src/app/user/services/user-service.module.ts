import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserService } from './user.service';
import { CoreServiceModule } from 'src/app/core/services';

@NgModule({
  imports: [
    CommonModule,
    CoreServiceModule,

  ],
  declarations: [],
  providers:[UserService]
})
export class UserServiceModule { 
  /**
   *
   */
  constructor() {
    console.log("--------------------------------UserServiceModule------------------------------------")    
  }
}
