import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { EducationSubCourse } from '../../models/educationsubcourse';
import { EducationSubCourseService } from '../../services/educationsubcourse.service';
import { EducationCourse } from '../../../educationCourse/models/educationcourse';
import { EducationCourseService } from '../../../educationCourse/services/educationcourse.service';


@Component({
  selector: 'app-educationSubCourse',
  templateUrl: 'educationsubcourse-list.component.html',
  styleUrls: ['educationsubcourse-list.component.css']
})

export class EducationSubCourseComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  educationSubCourseItem: EducationSubCourse = { Id: 0, Name: '', EducationCourseId: 0 , EducationCourseName: ''};
  public items: EducationSubCourse[] = [];
  public educationCourseItems: EducationCourse[] = [];
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public subject: string = "educationsubcourse";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private educationSubCourseService: EducationSubCourseService, 
    private educationCourseService: EducationCourseService) { }

  ngOnInit() {

    this.dictionary = this.educationSubCourseService.GetDictionary();
    this.geteducationCourseItem();
    this.get();

  }

  geteducationCourseItem() {
    
    this.educationCourseService.GetAllForGrid(this.pagination).subscribe((res: PaginationResult<EducationCourse>) => {

      if (res.result) {
        this.educationCourseItems = res.result
      }
    });

  }

  get() {

    this.educationSubCourseService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<EducationSubCourse>) => {

        if (res.result) {
          this.items = res.result
        }
        else {
          this.items = [];
        }
        this.pagination = res.pagination;
      }, err => {
        console.log(err);
      });
  }

  submitForm(): void {

    if (this.educationSubCourseItem.EducationCourseId == 0){
      this.alertify.error("انتخاب دوره تحصیلی الزامیست.");
      return;
    }

     console.log(this.educationSubCourseItem);
    // return;
    if (this.form.valid) {

      if (this.educationSubCourseItem.Id == 0) {
        this.educationSubCourseService.add(this.educationSubCourseItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );

      }
      else {
        this.educationSubCourseService.update(this.educationSubCourseItem.Id, this.educationSubCourseItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );
      }
    }
  }


  pageChanged(event: any): void {
    this.pagination.currentPage = event;

    this.get();
  }


  edit(item: EducationSubCourse) {

    this.educationSubCourseService.get(item.Id).subscribe(
      (res: EducationSubCourse) => {
        this.educationSubCourseItem = res;
      }
    );
  }

  remove(item: EducationSubCourse) {

    this.educationSubCourseService.delete(item.Id).subscribe(
      () => {
        this.get();
        this.clearForm();
        this.alertify.success(Message.deleteSuccess);
      },
      err => {
        this.alertify.error(err);
      }
    );

  }

  sort(event: Pagination) {
    let sort = event;
    this.get();
  }

  clearForm() {
    this.educationSubCourseItem.Id = 0;
    this.educationSubCourseItem.Name = '';
    this.educationSubCourseItem.EducationCourseId = 0;
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
