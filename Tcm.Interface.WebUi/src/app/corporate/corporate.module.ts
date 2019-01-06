import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CorporateRoutingModule } from './corporate-routing.module';
import { CorporateComponent } from './component/corporate.component';
import { CorporateServiceModule } from './services/corporate-service.module';
import { CorporateAddComponent } from './pages';




@NgModule({
  imports: [
    CommonModule,
    CorporateRoutingModule,
    CorporateServiceModule
  ],
  declarations: [CorporateComponent, CorporateAddComponent]
})
export class CorporateModule {
  constructor(){
    console.log("--------------------------------CorporateModule-------------------------------")
  }
 }
