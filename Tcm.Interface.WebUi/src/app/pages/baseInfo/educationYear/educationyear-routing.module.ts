import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EducationYearComponent } from './pages/list/educationYear-list.component';

const routes: Routes = [
  {path:'',component:EducationYearComponent},
  {path:'edit/:id',component:EducationYearComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EducationYearRoutingModule { }
