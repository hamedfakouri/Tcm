import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SchoolSubTypeComponent } from './pages/list/schoolsubtype-list.component';

const routes: Routes = [
  {path:'',component:SchoolSubTypeComponent},
  {path:'edit/:id',component:SchoolSubTypeComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchoolSubTypeRoutingModule { }
