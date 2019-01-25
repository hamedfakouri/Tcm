import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {EducationLevelComponent} from './pages/list/educationlevel-list.component';
import { EducationLevelRoutingModule } from './education-level-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [EducationLevelComponent],
  imports: [
    CommonModule,
    EducationLevelRoutingModule,
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
