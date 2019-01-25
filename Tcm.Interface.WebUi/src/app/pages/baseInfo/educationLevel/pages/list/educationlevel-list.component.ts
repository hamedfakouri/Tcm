import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { EducationLevel } from '../../models/educationlevel';
import { EducationLevelService } from '../../services/educationlevel.service';


@Component({
  selector: 'app-educationLevel',
  templateUrl: 'educationlevel-list.component.html',
  styleUrls: ['educationlevel-list.component.css']
})

export class EducationLevelComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  educationLevelItem: EducationLevel = { Id: 0, Name: '' };
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public items: EducationLevel[] = [];
  public subject: string = "educationlevel";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private educationLevelService: EducationLevelService) { }

  ngOnInit() {

    this.dictionary = this.educationLevelService.GetDictionary();
    this.get();
  }

  get() {

    this.educationLevelService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<EducationLevel>) => {

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

      if (this.educationLevelItem.Id == 0) {
        this.educationLevelService.add(this.educationLevelItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );

      }
      else {
        this.educationLevelService.update(this.educationLevelItem.Id, this.educationLevelItem).subscribe(
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


  edit(item: EducationLevel) {

    this.educationLevelService.get(item.Id).subscribe(
      (res: EducationLevel) => {
        this.educationLevelItem = res;
      }
    );
  }

  remove(item: EducationLevel) {

    this.educationLevelService.delete(item.Id).subscribe(
      () => {
        this.get();
        this.alertify.success(Message.deleteSuccess);
      },
      err => {
        this.alertify.error(err);
      }
    );
    //this.alertify.deleteConfirm(Message.actionConfirm, this.deleteItem,this.educationLevelItem, this.clearForm);

  }

  sort(event: Pagination) {
    let sort = event;
    this.get();
  }

  clearForm() {
    this.educationLevelItem.Id = 0;
    this.educationLevelItem.Name = '';
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
