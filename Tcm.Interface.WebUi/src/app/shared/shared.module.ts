import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormInputComponent } from './components';
import { InputErrorDirective,PermissionDirective } from './directive';
import { GetErrorPipe } from './pipe';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { AppGridComponent,BreadCrumbComponent } from './components';
import { ThemeModule } from '../theme/theme.module';
import { SharedServiceModule } from './services/shared-service.module';


console.log("--------------------------------SharedModulebundled----------------")


@NgModule({
  imports: [
    CommonModule,
    ThemeModule,
    SharedServiceModule
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
    ThemeModule,
    SharedServiceModule
  ],
  providers:[NgbModule]
})


export class SharedModule { 
  constructor()
  {
    console.log("--------------------------------SharedModule-------------------------------")
  }
}
