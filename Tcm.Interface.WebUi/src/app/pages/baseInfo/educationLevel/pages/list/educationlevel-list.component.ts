import { Component, OnInit } from '@angular/core';

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
