import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { EducationSubCourse } from '../../models/educationsubcourse';
import { EducationSubCourseService } from '../../services/educationsubcourse.service';
import { EducationCourse } from '../../../educationCourse/models/educationcourse';
import { EducationCourseService } from '../../../educationCourse/services/educationcourse.service';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-educationSubCourse',
  templateUrl: 'educationsubcourse-list.component.html',
  styleUrls: ['educationsubcourse-list.component.css']
})

export class EducationSubCourseComponent extends CrudComponent<EducationSubCourse> implements OnInit {


 

  public educationCourseItems: Observable<EducationCourse[]>;

  public subject: string = "educationsubcourse";

  constructor(private educationSubCourseService: EducationSubCourseService, 
    private educationCourseService: EducationCourseService,route: ActivatedRoute,
    router: Router) {
      super(educationSubCourseService,route,router);
     }

  ngOnInit() {

    this.dictionary = this.educationSubCourseService.GetDictionary();
    this.items = new  Array<EducationSubCourse>();
    this.item =new EducationSubCourse();
    this.geteducationCourseItem();
    this.getَAll();
    this.getQueryString();

  }

  geteducationCourseItem() {
    
     this.educationCourseItems = this.educationCourseService.getAll();

  }

 

}
