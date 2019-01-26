import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { Message } from 'src/app/core/models/message.enum';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { Major } from '../../models/major';
import { MajorService } from '../../services/major.service';


@Component({
  selector: 'app-Major',
  templateUrl: 'major-list.component.html',
  styleUrls: ['major-list.component.css']
})

export class MajorComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  majorItem: Major = { Id: 0, Name: '' };
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public items: Major[] = [];
  public subject: string = "major";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private majorService: MajorService) { }

  ngOnInit() {

    this.dictionary = this.majorService.GetDictionary();
    this.get();
  }

  get() {

    this.majorService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<Major>) => {

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

      if (this.majorItem.Id == 0) {
        this.majorService.add(this.majorItem).subscribe(
          () => {
            this.get();
            this.clearForm();
            this.alertify.success(Message.saveSuccess);
          }
        );

      }
      else {
        this.majorService.update(this.majorItem.Id, this.majorItem).subscribe(
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


  edit(item: Major) {

    this.majorService.get(item.Id).subscribe(
      (item: Major) => {
        this.majorItem = item;
      }
    );
  }

  remove(item: Major) {

    this.majorService.delete(item.Id).subscribe(
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
    this.majorItem.Id = 0;
    this.majorItem.Name = '';
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
