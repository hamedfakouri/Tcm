import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SchoolSubTypeComponent } from './pages/list/schoolsubtype-list.component';
import { SchoolSubTypeRoutingModule } from './schoolsubtype-routing.module';

@NgModule({
  declarations: [
    SchoolSubTypeComponent
  ],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    SchoolSubTypeRoutingModule,
    
  ],
  providers: []
})
export class SchoolSubTypeModule {

  constructor() {
    console.log("-------------------schoolSubTypeModule-------------------")

  }
}
