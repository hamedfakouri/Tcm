import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MajorComponent } from './pages/list/major-list.component';
import { MajorRoutingModule } from './major-routing.module';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [MajorComponent],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    MajorRoutingModule,
    
  ],
  providers: []
})
export class MajorModule {
  
  constructor() {
    console.log("-------------------majorModule-------------------")
    
  }
 }
