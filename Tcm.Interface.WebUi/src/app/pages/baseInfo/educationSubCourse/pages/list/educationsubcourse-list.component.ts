import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

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
