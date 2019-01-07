import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CorporateRoutingModule } from './corporate-routing.module';
import { CorporateComponent } from './component/corporate.component';
import { CorporateServiceModule } from './services/corporate-service.module';
import { CorporateAddComponent } from './pages';
import { SharedModule } from '../shared/shared.module';




@NgModule({
  imports: [
    CommonModule,
    CorporateRoutingModule,
    CorporateServiceModule,
    FormsModule,
    SharedModule
  ],
  declarations: [CorporateComponent, CorporateAddComponent]
})
export class CorporateModule {
  constructor(){
    console.log("--------------------------------CorporateModule-------------------------------")
  }
 }
