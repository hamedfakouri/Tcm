import { Component, OnInit } from '@angular/core';

import { SchoolType } from '../../models/schooltype';
import { SchoolTypeService } from '../../services/schooltype.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';

@Component({
  selector: 'app-schoolType',
  templateUrl: 'schoolType-list.component.html',
  styleUrls: ['schooltype-list.component.css']
})

export class SchoolTypeComponent extends CrudComponent<SchoolType> implements OnInit {

  public subject: string = "schooltype";
  constructor(
    private schoolTypeService: SchoolTypeService,route: ActivatedRoute,
    router: Router) {
      super(schoolTypeService,route,router);
     }

  ngOnInit() {

    this.item = new SchoolType();
    this.items = new Array<SchoolType>();
    this.dictionary = this.schoolTypeService.GetDictionary();
    this.getَAll();
    this.getQueryString();
  }
}
