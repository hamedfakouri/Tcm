import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ClassRoomListComponent } from './pages/classroom-list/classroom-list.component';
import { ClassRoomAddComponent } from './pages/classroom-add/classroom-add.component';

const routes: Routes = [
  {path:'',component: ClassRoomListComponent },
  {path:'edit/:id',component: ClassRoomAddComponent},
  {path:'add',component: ClassRoomAddComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ClassRoomRoutingModule { }
