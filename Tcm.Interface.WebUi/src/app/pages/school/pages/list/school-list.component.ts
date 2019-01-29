import { Component, OnInit, ViewChild, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';

import { AlertifyService } from 'src/app/shared/services';

import { Pagination, PaginationResult } from 'src/app/core/models/pagination';
import { Pair } from 'src/app/core/models';
import { School } from '../../models/school';
import { SchoolService } from '../../services/school.service';
import { Message } from 'src/app/core/models/message.enum';
import { Router } from '@angular/router';


@Component({
  selector: 'app-school-list',
  templateUrl: 'school-list.component.html',
  styleUrls: ['school-list.component.css']
})

export class SchoolListComponent implements OnInit, OnDestroy {

  //subscriptions: Subscription[] = [];

  public items: School[] = [];
  @ViewChild('f') form: any;

  public pagination = new Pagination(1, 10);
  public subject: string = "schoollist";
  public dictionary: Array<Pair>;
  userParams: any = {};

  constructor(private alertify: AlertifyService, private schoolService: SchoolService, private router: Router) { }

  ngOnInit() {

    this.dictionary = this.schoolService.GetDictionary();
    this.get();

  }

  get() {

    this.schoolService.GetAllForGrid(this.pagination)
      .subscribe((res: PaginationResult<School>) => {

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

  edit(item: School) {
    this.router.navigate(['School/Add' , item.Id ]);
  }

  remove(item: School) {

    this.schoolService.delete(item.Id).subscribe(
      () => {
        this.get();
        this.alertify.success(Message.deleteSuccess);
      },
      err => {
        this.alertify.error(err);
      }
    );
  }

  pageChanged(event: any): void {

    this.pagination.currentPage = event;

    this.get();
  }

  sort(event: Pagination) {
    let sort = event;
    this.get();
  }

  ngOnDestroy(): void {
    //this.subscriptions.forEach(s => s.unsubscribe());
  }

}
