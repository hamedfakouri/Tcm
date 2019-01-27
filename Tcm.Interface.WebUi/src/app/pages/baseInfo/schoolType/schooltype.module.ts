import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { SchoolTypeComponent } from './pages/list/schooltype-list.component';
import { SchoolTypeRoutingModule } from './schooltype-routing.module';

@NgModule({
  declarations: [SchoolTypeComponent],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    SchoolTypeRoutingModule,
    
  ],
  providers: []
})
export class SchoolTypeModule {

  constructor() {
    console.log("-------------------schoolTypeModule-------------------")
    
  }
 }
