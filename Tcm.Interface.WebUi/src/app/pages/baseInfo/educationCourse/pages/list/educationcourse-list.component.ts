import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';

import { EducationCourseService } from '../../services/educationcourse.service';
import { EducationLevelService } from '../../../educationLevel/services/educationlevel.service';
import { EducationLevel } from '../../../educationLevel/models';
import { EducationCourse } from '../../models/educationcourse';
import { CrudComponent } from 'src/app/shared/components/Crud/crud.component';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-educationCourse',
  templateUrl: 'educationcourse-list.component.html',
  styleUrls: ['educationcourse-list.component.css']
})

export class EducationCourseComponent extends CrudComponent<EducationCourse> implements OnInit {

  public educationLevelItems: Observable<EducationLevel[]>;

  public subject: string = "educationcourse";

  constructor(private educationcourseService: EducationCourseService, private educationLevelService: EducationLevelService,route: ActivatedRoute,
    router: Router) {
    super(educationcourseService,route,router);
   }

  ngOnInit() {

    this.dictionary = this.educationcourseService.GetDictionary();
    this.items = new  Array<EducationCourse>();
    this.item =new EducationCourse();
    this.getEducationLevelItems();
    this.getَAll();

    this.getQueryString();
  }

  getEducationLevelItems() {
    
    this.educationLevelItems = this.educationLevelService.getAll();

  }

}
