import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CorporateAddComponent} from './pages'
const routes: Routes = [

  { path:'add', component: CorporateAddComponent , data:{title:'بررسی وضعیت کاربر'} }, 

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CorporateRoutingModule { }
