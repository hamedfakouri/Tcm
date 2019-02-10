import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { SchoolType } from '../../models/schooltype';
import { SchoolTypeService } from '../../services/schooltype.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';


@Component({
  selector: 'app-schoolType',
  templateUrl: 'schoolType-list.component.html',
  styleUrls: ['schooltype-list.component.css']
})

export class SchoolTypeComponent extends CrudComponent<SchoolType> implements OnInit, OnDestroy {



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
