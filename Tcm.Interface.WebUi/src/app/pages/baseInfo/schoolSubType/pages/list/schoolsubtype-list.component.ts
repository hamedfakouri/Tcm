import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { SchoolSubType } from '../../models/schoolsubtype';
import { SchoolType } from '../../../schoolType/models/schooltype';
import { SchoolTypeService } from '../../../schoolType/services/schooltype.service';
import { SchoolSubTypeService } from '../../services/schoolsubtype.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';


@Component({
  selector: 'app-schoolSubType',
  templateUrl: 'schoolsubtype-list.component.html',
  styleUrls: ['schoolsubtype-list.component.css']
})

export class SchoolSubTypeComponent extends CrudComponent<SchoolSubType> implements OnInit, OnDestroy {


  public subject: string = "schoolsubtype";
  schoolTypeItems: Observable<SchoolType[]>;


  constructor( private schoolSubTypeService: SchoolSubTypeService, 
    private schoolTypeService: SchoolTypeService,route: ActivatedRoute,
    router: Router) {
      super(schoolSubTypeService,route,router);
     }

  ngOnInit() {

    this.dictionary = this.schoolSubTypeService.GetDictionary();
    this.items = new  Array<SchoolSubType>();
    this.item =new SchoolSubType();
    this.getschoolTypeItems();
    this.getَAll();
    this.getQueryString();

  }

  getschoolTypeItems() {
    
    this.schoolTypeItems = this.schoolTypeService.getAll();

  }

 

}
