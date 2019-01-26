import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { EducationCourse } from '../../models/educationcoure';
import { EducationCourseService } from '../../services/educationcourse.service';


@Component({
  selector: 'app-educationCourse',
  templateUrl: 'educationcourse-list.component.html',
  styleUrls: ['educationcourse-list.component.css']
})

export class EducationCourseComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  educationCourseItem: EducationCourse = { Id: 0, Name: '' };
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public items: EducationCourse[] = [];
  public subject: string = "educationcourse";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private educationcourseService: EducationCourseService) { }

  ngOnInit() {

    this.dictionary = this.educationcourseService.GetDictionary();
    this.get();
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
        this.alertify.success(Message.deleteSuccess);
      },
      err => {
        this.alertify.error(err);
      }
    );
    //this.alertify.deleteConfirm(Message.actionConfirm, this.deleteItem,this.educationCourseItem, this.clearForm);

  }

  sort(event: Pagination) {
    let sort = event;
    this.get();
  }

  clearForm() {
    this.educationCourseItem.Id = 0;
    this.educationCourseItem.Name = '';
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
