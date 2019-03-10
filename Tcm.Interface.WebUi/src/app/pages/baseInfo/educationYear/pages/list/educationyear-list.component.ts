import { Component, OnInit } from '@angular/core';

import { EducationYear } from '../../models/educationYear';
import { EducationYearService } from '../../services/educationYear.service';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-educationYear',
  templateUrl: 'educationYear-list.component.html',
  styleUrls: ['educationYear-list.component.css']
})

export class EducationYearComponent extends CrudComponent<EducationYear> implements OnInit {
 
  public subject: string = "educationyear";

  constructor(private educationYearService: EducationYearService, route: ActivatedRoute,
    router: Router) { 
    super(educationYearService,route,router);
    this.dictionary = this.educationYearService.GetDictionary();
    this.items = new Array<EducationYear>();

  }

  ngOnInit() {
    this.item =new EducationYear();   
    this.getَAll();
    this.getQueryString();
  
  }
}
