import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EducationSubCourseComponent } from './pages/list/educationsubcourse-list.component';

const routes: Routes = [
  {path:'',component:EducationSubCourseComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EducationSubCourseRoutingModule { }
