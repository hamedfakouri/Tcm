import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { CorporateRoutingModule } from './corporate-routing.module';
import { CorporateServiceModule } from './services/corporate-service.module';
import { CorporateAddComponent ,CorporateListComponent} from './pages';
import { SharedModule } from '../../shared/shared.module';

console.log("--------------------------------CorporateModulebundled-----------------")


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    CorporateRoutingModule,
    CorporateServiceModule,
    SharedModule   
  ],
  declarations: [ CorporateAddComponent,CorporateListComponent ]
})
export class CorporateModule {
  constructor(){
    console.log("--------------------------------CorporateModule-------------------------------")
  }
 }
