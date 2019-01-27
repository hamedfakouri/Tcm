import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { SchoolSubType } from '../../models/schoolsubtype';
import { SchoolType } from '../../../schoolType/models/schooltype';
import { SchoolTypeService } from '../../../schoolType/services/schooltype.service';
import { SchoolSubTypeService } from '../../services/schoolsubtype.service';


@Component({
  selector: 'app-schoolSubType',
  templateUrl: 'schoolsubtype-list.component.html',
  styleUrls: ['schoolsubtype-list.component.css']
})

export class SchoolSubTypeComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  schoolSubTypeItem: SchoolSubType = { Id: 0, Name: '', SchoolTypeId: 0 , SchoolTypeName: '' };
  public items: SchoolSubType[] = [];
  public schoolTypeItems: SchoolType[] = [];
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public subject: string = "schoolsubtype";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private schoolSubTypeService: SchoolSubTypeService, 
    private schoolTypeService: SchoolTypeService) { }

  ngOnInit() {

    this.dictionary = this.schoolSubTypeService.GetDictionary();
    this.getschoolTypeItems();
    this.get();

  }

  getschoolTypeItems() {
    
    this.schoolTypeService.GetAllForGrid(this.pagination).subscribe((res: PaginationResult<SchoolType>) => {

      if (res.result) {
        this.schoolTypeItems = res.result
      }
    });

  }

  get() {

    this.schoolSubTypeService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<SchoolSubType>) => {

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

    if (this.schoolSubTypeItem.SchoolTypeId == 0){
      this.alertify.error("انتخاب نوع مدرسه الزامیست.");
      return;
    }

    if (this.form.valid) {

      if (this.schoolSubTypeItem.Id == 0) {
        this.schoolSubTypeService.add(this.schoolSubTypeItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );

      }
      else {
        this.schoolSubTypeService.update(this.schoolSubTypeItem.Id, this.schoolSubTypeItem).subscribe(
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


  edit(item: SchoolSubType) {

    this.schoolSubTypeService.get(item.Id).subscribe(
      (res: SchoolSubType) => {
        this.schoolSubTypeItem = res;
      }
    );
  }

  remove(item: SchoolSubType) {

    this.schoolSubTypeService.delete(item.Id).subscribe(
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
    this.schoolSubTypeItem.Id = 0;
    this.schoolSubTypeItem.Name = '';
    this.schoolSubTypeItem.SchoolTypeId = 0;
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
