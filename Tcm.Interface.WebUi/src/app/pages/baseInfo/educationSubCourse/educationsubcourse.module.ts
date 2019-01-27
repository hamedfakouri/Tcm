import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { EducationSubCourseComponent } from './pages/list/educationsubcourse-list.component';
import { EducationSubCourseRoutingModule } from './educationsubcourse-routing.module';

@NgModule({
  declarations: [
    EducationSubCourseComponent
  ],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    EducationSubCourseRoutingModule,
    
  ],
  providers: []
})
export class EducationSubCourseModule {

  constructor() {
    console.log("-------------------educationSubCourseModule-------------------")

  }
}
