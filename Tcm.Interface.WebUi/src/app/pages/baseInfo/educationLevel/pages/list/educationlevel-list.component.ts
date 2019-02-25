import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { EducationLevel } from '../../models/educationlevel';
import { EducationLevelService } from '../../services/educationlevel.service';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-educationLevel',
  templateUrl: 'educationlevel-list.component.html',
  styleUrls: ['educationlevel-list.component.css']
})

export class EducationLevelComponent extends CrudComponent<EducationLevel> implements OnInit {


 
  public subject: string = "educationlevel";
 

  constructor(private educationLevelService: EducationLevelService, route: ActivatedRoute,
    router: Router) { 
    super(educationLevelService,route,router);
    this.dictionary = this.educationLevelService.GetDictionary();
    this.items = new Array<EducationLevel>();
    

  }

  ngOnInit() {
    this.item =new EducationLevel();   
    this.getَAll();
    this.getQueryString();

  
  }



}
