import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { Major } from '../../models/major';
import { MajorService } from '../../services/major.service';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-Major',
  templateUrl: 'major-list.component.html'
})

export class MajorComponent extends CrudComponent<Major> implements  OnInit, OnDestroy {


  public subject: string = "major";
  constructor( private majorService: MajorService,route: ActivatedRoute,
  router: Router) {
    super(majorService,route,router);
   }

  ngOnInit() {

    this.item = new Major();
    this.items = new Array<Major>();
    this.dictionary = this.majorService.GetDictionary();
    this.getَAll();
    this.getQueryString();
    
  }

 

}
