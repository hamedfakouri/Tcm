import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormInputComponent } from './components';
import { InputErrorDirective,PermissionDirective } from './directive';
import { GetErrorPipe } from './pipe';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppGridComponent,BreadCrumbComponent } from './components';


console.log("--------------------------------SharedModulebundled----------------")


@NgModule({
  imports: [
    CommonModule,
    NgbModule
  ]
  ,
  declarations: [
    InputErrorDirective,
    PermissionDirective,
    FormInputComponent,
    GetErrorPipe,
    AppGridComponent,
    BreadCrumbComponent
    ]
  ,
  exports:[
    InputErrorDirective,
    PermissionDirective,
    FormInputComponent,
    BreadCrumbComponent,

    AppGridComponent,
    NgbModule,
  ],
  providers:[NgbModule]
})


export class SharedModule { 
  constructor()
  {
    console.log("--------------------------------SharedModule-------------------------------")
  }
}
