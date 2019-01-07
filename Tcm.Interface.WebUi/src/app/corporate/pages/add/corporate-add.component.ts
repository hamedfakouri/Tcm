import { Component, OnInit } from '@angular/core';
import { Corporate } from '../../models/corporate';

@Component({
  selector: 'app-corporate-add',
  templateUrl: './corporate-add.component.html'
})
export class CorporateAddComponent implements OnInit {

  constructor() { }

  model = new Corporate('',0);

  ngOnInit() {
  }

  AddFormSubmit(){

  }
}
