import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SchoolListComponent } from './pages/list/school-list.component';
import { SchoolRoutingModule } from './school-routing.module';
import { SchoolAddComponent } from './pages/add/school-add.component';
import { AngularMultiSelectModule } from 'src/app/shared/directive/angular4-multiselect-dropdown';

@NgModule({
  declarations: [
    SchoolListComponent,
    SchoolAddComponent
  ],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    SchoolRoutingModule,
    AngularMultiSelectModule
  ],
  providers: []
})
export class SchoolModule {

  constructor() {
    console.log("-------------------schoolModule-------------------")

  }
}
