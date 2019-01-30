import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';


import { AuthServiceModule } from 'src/app/authentication/services/auth-service.module';
import { ProvinceService } from './province.service';

console.log("-----------------------CoreServiceModulebundled-----------------")

@NgModule({
  imports: [
    CommonModule, 
    AuthServiceModule.forRoot(),
  ],
  declarations: [],
  providers:[AuthServiceModule, ProvinceService]
})
export class CoreServiceModule { 
  constructor(){
    console.log("------------------------CoreServiceModule-------------------------------")
  }
  
}
