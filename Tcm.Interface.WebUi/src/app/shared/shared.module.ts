import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedRoutingModule } from './shared-routing.module';
import { FormInputComponent } from './components';
import { InputErrorDirective,PermissionDirective } from './directive';
import { GetErrorPipe } from './pipe';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppGridComponent } from './components/appGrid/app-grid.component';


console.log("--------------------------------SharedModulebundled----------------")


@NgModule({
  imports: [
    CommonModule,
    SharedRoutingModule,
    NgbModule
  ]
  ,
  declarations: [
    InputErrorDirective,
    PermissionDirective,
    FormInputComponent,
    GetErrorPipe,
    AppGridComponent,
    ]
  ,
  exports:[
    InputErrorDirective,
    PermissionDirective,
    FormInputComponent,
    AppGridComponent,
    NgbModule
  ],
  providers:[NgbModule]
})


export class SharedModule { 
  constructor()
  {
    console.log("--------------------------------SharedModule-------------------------------")
  }
}
