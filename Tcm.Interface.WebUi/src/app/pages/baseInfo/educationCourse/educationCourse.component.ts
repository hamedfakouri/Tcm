import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { AlertifyService } from 'src/app/shared/services/alertify.service';
import { Message } from 'src/app/shared/mocks/message.enum';
import { EducationcourseService } from './services/educationcourse.service';
import { Educationcourse } from './models/educationcourse';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-educationCourse',
  templateUrl: './educationCourse.component.html',
  styleUrls: ['./educationCourse.component.css']
})
export class EducationCourseComponent implements OnInit, OnDestroy {

  subscriptions: Subscription[] = [];

  educationCourseItem: Educationcourse = { Id: 0, name: '' };
  educationCourseList: Educationcourse[] = [];
  @ViewChild('f') form: any;

  constructor(private alertify: AlertifyService, private educationCourseService: EducationcourseService) { }

  ngOnInit() {
    this.getList();
  }

  getList() {
    this.subscriptions.push(this.educationCourseService.getAll().subscribe(
      (item: Educationcourse[]) => {
        this.educationCourseList = item;
      }
    ));
  }

  submitForm(): void {

    if (this.form.valid) {

      if (this.educationCourseItem.Id == 0) {
        this.subscriptions.push(this.educationCourseService.update(this.educationCourseItem.Id, this.educationCourseItem).subscribe(
          () => {
            this.getList();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        ));
      }
      else {
        this.subscriptions.push(this.educationCourseService.add(this.educationCourseItem).subscribe(
          () => {
            this.getList();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        ));
      }
    }
  }

  getItem(id: number) {
    this.subscriptions.push(this.educationCourseService.get(id).subscribe(
      (item: Educationcourse) => {
        this.educationCourseItem = item;
      }
    ));
  }

  confirmDelete(item: Educationcourse) {

    this.educationCourseItem = item;
    this.alertify.deleteConfirm(Message.actionConfirm, this.deleteItem, this.clearForm);

  }

  deleteItem() {

    this.subscriptions.push(this.educationCourseService.delete(this.educationCourseItem).subscribe(
      () => {
        this.getList();
        this.clearForm();
        this.alertify.success(Message.deleteSuccess);
      },
      err => {
        this.alertify.error(err);
      }
    ));
  }

  clearForm() {
    this.educationCourseItem.Id = 0;
    this.educationCourseItem.name = '';
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(s => s.unsubscribe());
  }

}
