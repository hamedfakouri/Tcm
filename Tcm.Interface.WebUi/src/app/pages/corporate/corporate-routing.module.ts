import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CorporateAddComponent, CorporateListComponent} from './pages'
const routes: Routes = [

  { path:'add', component: CorporateAddComponent , data:{title:'ثبت جدید'} }, 
  { path:'list', component: CorporateListComponent , data:{title:'لیست شرکت بیمه'} }, 
  { path:'update/:id', component: CorporateAddComponent , data:{title:'ویرایش'} }, 


];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CorporateRoutingModule { }
