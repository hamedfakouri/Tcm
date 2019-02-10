import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SchoolTypeComponent } from './pages/list/schooltype-list.component';

const routes: Routes = [
  {path:'',component:SchoolTypeComponent},
  {path:'edit/:id',component:SchoolTypeComponent}

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SchoolTypeRoutingModule { }
