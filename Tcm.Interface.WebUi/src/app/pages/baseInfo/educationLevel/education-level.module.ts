import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {EducationLevelComponent} from './pages/list/educationlevel-list.component';
import { EducationLevelRoutingModule } from './education-level-routing.module';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [EducationLevelComponent],
  imports: [
    CommonModule,
    EducationLevelRoutingModule,
    ThemeModule,
    SharedModule
    
  ]
})
export class EducationLevelModule {
  /**
   *
   */
  constructor() {
    console.log("-------------------educationLevelModule-------------------")
    
  }
 }
