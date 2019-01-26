import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EducationCourseComponent } from './pages/list/educationcourse-list.component';

const routes: Routes = [
  {path:'',component:EducationCourseComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EducationCourseRoutingModule { }
