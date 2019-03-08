import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EducationYearComponent } from './pages/list/educationYear-list.component';
import { EducationYearRoutingModule } from './educationYear-routing.module';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { EducationYearService } from './services/educationYear.service';

@NgModule({
  declarations: [EducationYearComponent],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    EducationYearRoutingModule,
    
  ],
  providers: [
    EducationYearService
  ]
})
export class EducationYearModule {

  constructor() {
    console.log("-------------------educationYearModule-------------------")
    
  }
 }
