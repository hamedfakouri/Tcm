import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SchoolListComponent } from './pages/list/school-list.component';
import { SchoolAddComponent } from './pages/add/school-add.component';

const routes: Routes = [
  {path:'',component: SchoolListComponent},
  {path:'Add/:id',component: SchoolAddComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchoolRoutingModule { }
