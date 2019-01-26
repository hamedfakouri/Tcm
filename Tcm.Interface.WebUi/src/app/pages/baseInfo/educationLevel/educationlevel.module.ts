import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {EducationLevelComponent} from './pages/list/educationlevel-list.component';
import { EducationLevelRoutingModule } from './educationlevel-routing.module';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { EducationLevelService } from './services/educationlevel.service';

@NgModule({
  declarations: [EducationLevelComponent],
  imports: [
    CommonModule,
    EducationLevelRoutingModule,
    ThemeModule,
    SharedModule
  ],
  providers: [EducationLevelService]
})
export class EducationLevelModule {
  /**
   *
   */
  constructor() {
    console.log("-------------------educationLevelModule-------------------")
    
  }
 }
