import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedRoutingModule } from './shared-routing.module';
import { FooterComponent,HeaderComponent,LoginComponent,FormInputComponent } from './component';
import { InputErrorDirective } from './directive/input-error.directive';
import { GetErrorPipe } from './pipe';


@NgModule({
  imports: [
    CommonModule,
    SharedRoutingModule
  ],
  declarations: [
    FooterComponent,
     HeaderComponent,
      LoginComponent,
       InputErrorDirective,
        FormInputComponent,GetErrorPipe]
  ,exports:[
    FooterComponent,HeaderComponent,InputErrorDirective,FormInputComponent
  ],
  providers:[]
})


export class SharedModule { 
  constructor(){
    console.log("--------------------------------SharedModule-------------------------------")
  }
}
