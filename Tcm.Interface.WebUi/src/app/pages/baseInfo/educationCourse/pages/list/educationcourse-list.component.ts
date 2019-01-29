import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { EducationCourseService } from '../../services/educationcourse.service';
import { EducationLevelService } from '../../../educationLevel/services/educationlevel.service';
import { EducationLevel } from '../../../educationLevel/models';
import { EducationCourse } from '../../models/educationcourse';


@Component({
  selector: 'app-educationCourse',
  templateUrl: 'educationcourse-list.component.html',
  styleUrls: ['educationcourse-list.component.css']
})

export class EducationCourseComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  educationCourseItem: EducationCourse = { Id: 0, Name: '', EducationLevelId: 0 , EducationLevelName: '',AllowAssignMajor: false };
  public items: EducationCourse[] = [];
  public educationLevelItems: Observable<EducationLevel[]>;
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public subject: string = "educationcourse";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private educationcourseService: EducationCourseService, private educationLevelService: EducationLevelService) { }

  ngOnInit() {

    this.dictionary = this.educationcourseService.GetDictionary();
    this.getEducationLevelItems();
    this.get();

  }

  getEducationLevelItems() {
    
    this.educationLevelItems = this.educationLevelService.getAll();

  }

  get() {

    this.educationcourseService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<EducationCourse>) => {

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

    if (this.educationCourseItem.EducationLevelId == 0){
      this.alertify.error("انتخاب مقطع تحصیلی الزامیست.");
      return;
    }

     console.log(this.educationCourseItem);
    // return;
    if (this.form.valid) {

      if (this.educationCourseItem.Id == 0) {
        this.educationcourseService.add(this.educationCourseItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );

      }
      else {
        this.educationcourseService.update(this.educationCourseItem.Id, this.educationCourseItem).subscribe(
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


  edit(item: EducationCourse) {

    this.educationcourseService.get(item.Id).subscribe(
      (res: EducationCourse) => {
        this.educationCourseItem = res;
      }
    );
  }

  remove(item: EducationCourse) {

    this.educationcourseService.delete(item.Id).subscribe(
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
    this.educationCourseItem.Id = 0;
    this.educationCourseItem.Name = '';
    this.educationCourseItem.EducationLevelId = 0;
    this.educationCourseItem.EducationLevelName = '';
    this.educationCourseItem.AllowAssignMajor = false;
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
