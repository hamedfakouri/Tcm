import { Component, OnInit } from '@angular/core';
import { Corporate } from '../../models/corporate';
import { AuthService } from 'src/app/authentication/services';
import { CorporateService } from '../../services';

@Component({
  selector: 'app-corporate-add',
  templateUrl: './corporate-add.component.html'
})
export class CorporateAddComponent implements OnInit {

  constructor(private corporateService:CorporateService) { }

  model = new Corporate();

    ngOnInit() {


  }

  AddFormSubmit(){

this.corporateService.add(this.model).subscribe();

  }
}
