import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MajorComponent } from './pages/list/major-list.component';

const routes: Routes = [
  {path:'',component:MajorComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MajorRoutingModule { }
