import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';
import { EducationLevelService } from './services/educationlevel.service';
import { AlertifyService } from 'src/app/shared/services';
import { EducationLevel } from './models/educationlevel';
import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';


@Component({
  selector: 'app-educationLevel',
  templateUrl: './educationLevel.component.html',
  styleUrls: ['./educationLevel.component.css']
})
export class EducationLevelComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  educationLevelItem: EducationLevel = { Id: 0, name: '' };
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
        debugger;
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
    debugger;
    if (this.form.valid) {

      if (this.educationLevelItem.Id == 0) {
        this.educationLevelService.update(this.educationLevelItem.Id, this.educationLevelItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );

      }
      else {
        this.educationLevelService.add(this.educationLevelItem).subscribe(
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


  edit(item: EducationLevel) {

    this.educationLevelService.get(item.Id).subscribe(
      (item: EducationLevel) => {
        this.educationLevelItem = item;
      }
    );
  }

  remove(item: EducationLevel) {

    this.educationLevelItem = item;
    this.alertify.deleteConfirm(Message.actionConfirm, this.deleteItem, this.clearForm);

  }

  deleteItem() {

    this.educationLevelService.delete(this.educationLevelItem).subscribe(
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
    this.educationLevelItem.Id = 0;
    this.educationLevelItem.name = '';
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
