import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EducationLevelComponent } from './pages/list/educationlevel-list.component';

const routes: Routes = [
  {path:'list',component:EducationLevelComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EducationLevelRoutingModule { }
