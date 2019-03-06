import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ThemeModule } from 'src/app/theme/theme.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ClassRoomListComponent } from './pages/classroom-list/classroom-list.component';
import { ClassRoomAddComponent } from './pages/classroom-add/classroom-add.component';
import { ClassRoomRoutingModule } from './classroom-routing.module';
import { ClassRoomService } from './services/classroom.service';
import { SchoolEducationSubCourseService } from '../../school/services/schooleducationsubcourse.service';

@NgModule({
  declarations: [
    ClassRoomListComponent,
    ClassRoomAddComponent
  ],
  imports: [
    CommonModule,
    ThemeModule,
    SharedModule,
    ClassRoomRoutingModule,
    
  ],
  providers: [
    ClassRoomService,
    SchoolEducationSubCourseService
  ]
})
export class ClassRoomModule {

  constructor() {
    console.log("-------------------classroomModule-------------------")

  }
}
