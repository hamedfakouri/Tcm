import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { SchoolType } from '../../models/schooltype';
import { SchoolTypeService } from '../../services/schooltype.service';


@Component({
  selector: 'app-schoolType',
  templateUrl: 'schoolType-list.component.html',
  styleUrls: ['schooltype-list.component.css']
})

export class SchoolTypeComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  schoolTypeItem: SchoolType = { Id: 0, Name: '' };
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public items: SchoolType[] = [];
  public subject: string = "schooltype";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private schoolTypeService: SchoolTypeService) { }

  ngOnInit() {

    this.dictionary = this.schoolTypeService.GetDictionary();
    this.get();
  }

  get() {

    this.schoolTypeService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<SchoolType>) => {

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

      if (this.schoolTypeItem.Id == 0) {
        this.schoolTypeService.add(this.schoolTypeItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );

      }
      else {
        this.schoolTypeService.update(this.schoolTypeItem.Id, this.schoolTypeItem).subscribe(
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
    console.log(this.pagination.currentPage);
    this.get();
  }


  edit(item: SchoolType) {

    this.schoolTypeService.get(item.Id).subscribe(
      (item: SchoolType) => {
        this.schoolTypeItem = item;
      }
    );
  }

  remove(item: SchoolType) {

    this.schoolTypeService.delete(item.Id).subscribe(
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
    this.schoolTypeItem.Id = 0;
    this.schoolTypeItem.Name = '';
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
