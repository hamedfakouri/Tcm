import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { EducationCourseComponent } from './pages/list/educationcourse-list.component';
import { EducationCourseService } from './services/educationcourse.service';
import { EducationCourseRoutingModule } from './educationcourse-routing.module';

@NgModule({
  declarations: [
    EducationCourseComponent
  ],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    EducationCourseRoutingModule,
    
  ],
  providers: []
})
export class EducationCourseModule {

  constructor() {
    console.log("-------------------educationLevelModule-------------------")

  }
}
