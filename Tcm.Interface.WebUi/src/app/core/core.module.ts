import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreServiceModule } from './services/core-service.module';
import { SharedModule } from '../shared/shared.module';

console.log("-----------------------CoreModulebundled-----------------")


@NgModule({
  imports: [
    CommonModule,
    CoreServiceModule,
    SharedModule
    
  ],
  declarations: [
    
      ],
  exports:[ 
   
  ],
  providers:[CoreServiceModule]
})
export class CoreModule  { 

constructor(){
  console.log("--------------------------------CoreModule-------------------------------")
}

}
